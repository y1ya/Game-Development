using Mono.Cecil.Cil;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class DragDropClick : MonoBehaviour
{
    Vector3 mousePosition;
    RaycastHit2D raycastHit2D;
    Transform prevHoverObject, nextHoverObject;

    private GameObject clickObject;
    public GameObject origObjectGoyaCandy;
    public GameObject origObjectMentos;
    public GameObject origObjectWhiteRabbit;
    private GameObject draggedObject;

    public GameObject 
        riceObject, soySauceObject, vinegarObject,
        joyObject, surfObject,
        paylessXtraBigObject, luckyMeObject, cupNoodleObject,
        colgateObject, rexonaObject, sunsilkObject,
        chippyObject, novaObject, piattosObject,
        cokeObject, pepsiObject, royalObject,
        zestoAppleObject, zestoGrapeObject, zestoOrangeObject,
        adoboObject, afritadaObject, flakesInOilObject,
        cheeseSpreadObject, nescafeObject, peanutButterObject,
        artisanObject, gardeniaObject;

    public GameObject itemsListUI;

    public GameObject goyaJarObject, mentosJarObject,
        whiteRabbitJarObject;

    public Texture2D defaultCursor;
    public Texture2D dragCursor;

    public GameObject[] objectsToDisable;

    public OrderScript orderScript;
    public ItemsLeft itemsLeft;
    public NEWItemInCartScript itemsInCart;
    public RefrigeratorScript refrigeratorScript;

    private float mouseHoldTime;
    public float holdThreshold;
    private bool isDragging = false;

    private List<string> itemsRequest;
    private List<int> quantityItemRequest;

    private Dictionary<string, (GameObject prefab, Vector3 scale, bool hasChildren)> itemPrefabMap;
    private Dictionary<string, System.Action> itemDecreaseMap;
    
    private Vector3 originalCartPosition; // Store original cart position for returning

    // Popup text settings

    public Text itemAdded;
    public Canvas uiCanvas;
    public Font popupFont;
    public int popupFontSize = 24;
    public Color popupTextColor = Color.white;
    public float popupDuration = 1.5f;
    public float popupFloatHeight = 100f;

    private Coroutine popupCoroutine;

    void Start()
    {
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
        InitializeItemPrefabMap();
        InitializeItemDecreaseMap();
        GetItemListRequestAndQuantity();
    }

    private void InitializeItemPrefabMap()
    {
        itemPrefabMap = new Dictionary<string, (GameObject, Vector3, bool)>
        {
            { "Goya Candy", (origObjectGoyaCandy, new Vector3(0.08f, 0.08f, 0f), false) },
            { "Mentos", (origObjectMentos, new Vector3(0.08f, 0.08f, 0f), false) },
            { "White Rabbit", (origObjectWhiteRabbit, new Vector3(0.08f, 0.08f, 0f), false) },
            { "Rice", (riceObject, new Vector3(0.08f, 0.08f, 0f), false) },
            { "Soy Sauce", (soySauceObject, new Vector3(0.08f, 0.08f, 0f), false) },
            { "Vinegar", (vinegarObject, new Vector3(0.08f, 0.08f, 0f), false) },
            { "Joy", (joyObject, new Vector3(0.08f, 0.08f, 0f), true) },
            { "Surf", (surfObject, new Vector3(0.08f, 0.08f, 0f), true) },
            { "Payless Xtra Big", (paylessXtraBigObject, new Vector3(0.08f, 0.08f, 0f), true) },
            { "Lucky Me", (luckyMeObject, new Vector3(0.08f, 0.08f, 0f), true) },
            { "Cup Noodle", (cupNoodleObject, new Vector3(0.08f, 0.08f, 0f), true) },
            { "Colgate", (colgateObject, new Vector3(0.08f, 0.08f, 0f), true) },
            { "Rexona", (rexonaObject, new Vector3(0.08f, 0.08f, 0f), true) },
            { "Sunsilk", (sunsilkObject, new Vector3(0.08f, 0.08f, 0f), true) },
            { "Chippy", (chippyObject, new Vector3(0.08f, 0.08f, 0f), true) },
            { "Nova", (novaObject, new Vector3(0.08f, 0.08f, 0f), true) },
            { "Piattos", (piattosObject, new Vector3(0.08f, 0.08f, 0f), true) },
            { "Coke", (cokeObject, new Vector3(0.08f, 0.08f, 0f), true) },
            { "Pepsi", (pepsiObject, new Vector3(0.08f, 0.08f, 0f), true) },
            { "Royal", (royalObject, new Vector3(0.08f, 0.08f, 0f), true) },
            { "Zesto Apple", (zestoAppleObject, new Vector3(0.08f, 0.08f, 0f), true) },
            { "Zesto Grape", (zestoGrapeObject, new Vector3(0.08f, 0.08f, 0f), true) },
            { "Zesto Orange", (zestoOrangeObject, new Vector3(0.08f, 0.08f, 0f), true) },
            { "Adobo", (adoboObject, new Vector3(0.20f, 0.20f, 0.20f), true) },
            { "Afritada", (afritadaObject, new Vector3(0.08f, 0.08f, 0f), true) },
            { "Flakes in Oil", (flakesInOilObject, new Vector3(0.08f, 0.08f, 0f), true) },
            { "Cheese Spread", (cheeseSpreadObject, new Vector3(0.08f, 0.08f, 0f), true) },
            { "Nescafe", (nescafeObject, new Vector3(0.08f, 0.08f, 0f), true) },
            { "Peanut Butter", (peanutButterObject, new Vector3(0.08f, 0.08f, 0f), true) },
            { "Artisan", (artisanObject, new Vector3(0.08f, 0.08f, 0f), true) },
            { "Gardenia", (gardeniaObject, new Vector3(0.08f, 0.08f, 0f), true) }
        };
    }

    private void InitializeItemDecreaseMap()
    {
        itemDecreaseMap = new Dictionary<string, System.Action>
        {
            { "Goya Candy", () => itemsLeft.DecreaseGoyaCandy() },
            { "Mentos", () => itemsLeft.DecreaseMentos() },
            { "White Rabbit", () => itemsLeft.DecreaseWhiteRabbit() },
            { "Rice", () => itemsLeft.DecreaseRice() },
            { "Soy Sauce", () => itemsLeft.DecreaseSoySauce() },
            { "Vinegar", () => itemsLeft.DecreaseVinegar() },
            { "Joy", () => itemsLeft.DecreaseJoy() },
            { "Surf", () => itemsLeft.DecreaseSurf() },
            { "Payless Xtra Big", () => itemsLeft.DecreasePaylessXtraBig() },
            { "Lucky Me", () => itemsLeft.DecreaseLuckyMe() },
            { "Cup Noodle", () => itemsLeft.DecreaseCupNoodle() },
            { "Colgate", () => itemsLeft.DecreaseColgate() },
            { "Rexona", () => itemsLeft.DecreaseRexona() },
            { "Sunsilk", () => itemsLeft.DecreaseSunsilk() },
            { "Chippy", () => itemsLeft.DecreaseChippy() },
            { "Nova", () => itemsLeft.DecreaseNova() },
            { "Piattos", () => itemsLeft.DecreasePiattos() },
            { "Coke", () => itemsLeft.DecreaseCoke() },
            { "Pepsi", () => itemsLeft.DecreasePepsi() },
            { "Royal", () => itemsLeft.DecreaseRoyal() },
            { "Zesto Apple", () => itemsLeft.DecreaseZestoApple() },
            { "Zesto Grape", () => itemsLeft.DecreaseZestoGrape() },
            { "Zesto Orange", () => itemsLeft.DecreaseZestoOrange() },
            { "Adobo", () => itemsLeft.DecreaseAdobo() },
            { "Afritada", () => itemsLeft.DecreaseAfritada() },
            { "Flakes in Oil", () => itemsLeft.DecreaseFlakesInOil() },
            { "Cheese Spread", () => itemsLeft.DecreaseCheeseSpread() },
            { "Nescafe", () => itemsLeft.DecreaseNescafe() },
            { "Peanut Butter", () => itemsLeft.DecreasePeanutButter() },
            { "Artisan", () => itemsLeft.DecreaseArtisan() },
            { "Gardenia", () => itemsLeft.DecreaseGardenia() }
        };
    }

    private GameObject InstantiateDraggedObject(string itemName, Vector3 position)
    {
        // Special case for cart - instantiate a clone for dragging
        if (itemName.Equals("Cart") || itemName.Contains("Cart"))
        {
            Debug.Log("[MOUSEDOWN] Dragging cart clone...");
            GameObject cartClone = Instantiate(clickObject, position, Quaternion.identity);
            cartClone.name = "Cart";
            cartClone.tag = "Cart";
            return cartClone;
        }

        if (!itemPrefabMap.TryGetValue(itemName, out var itemData))
        {
            Debug.LogWarning($"[MOUSEDOWN] Unknown item: {itemName}");
            return null;
        }

        GameObject prefab = itemData.prefab;
        Vector3 scale = itemData.scale;
        bool hasChildren = itemData.hasChildren;

        GameObject draggedObj = Instantiate(prefab, position, Quaternion.identity);
        draggedObj.transform.localScale = scale;

        if (hasChildren)
        {
            foreach (Transform child in draggedObj.transform)
            {
                Destroy(child.gameObject);
            }
        }

        return draggedObj;
    }

    private void AddItemToCartAndDecrease(string itemName)
    {
        itemsInCart.AddItem(itemName);
        
        if (itemDecreaseMap.TryGetValue(itemName, out var decreaseAction))
        {
            decreaseAction();
        }

        // Show popup text when item is added
        ShowAddToCartPopup(itemName);
    }

    private void ShowAddToCartPopup(string itemName)
    {
        // Don't show popup for refrigerator or other non-cart items
        if (itemAdded == null || itemName.Equals("Refrigerator") || itemName.Contains("Refrigerator"))
            return;

        if (popupCoroutine != null)
        {
            StopCoroutine(popupCoroutine);
        }

        // Get current quantity of this item in cart
        List<string> cartItems = itemsInCart.GetCartItems();
        int itemCount = cartItems.Count(item => item == itemName);

        itemAdded.text = itemName + " Added x" + itemCount;

        // Position the popup at the mouse location
        RectTransform rectTransform = itemAdded.GetComponent<RectTransform>();

        // Convert screen space to canvas space
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            itemAdded.canvas.GetComponent<RectTransform>(),
            Input.mousePosition,
            itemAdded.canvas.worldCamera,
            out Vector2 canvasPosition
        );

        rectTransform.anchoredPosition = canvasPosition;

        // Make sure the text is visible
        itemAdded.gameObject.SetActive(true);
        itemAdded.color = new Color(itemAdded.color.r, itemAdded.color.g, itemAdded.color.b, 1f);

        // Start coroutine to animate and destroy
        popupCoroutine = StartCoroutine(AnimatePopup(rectTransform));
    }

    private IEnumerator AnimatePopup(RectTransform rectTransform)
    {
        Vector2 startPos = rectTransform.anchoredPosition;
        Vector2 endPos = startPos + Vector2.up * popupFloatHeight;
        float elapsedTime = 0f;

        // Reset color to full opacity before starting animation
        itemAdded.color = new Color(itemAdded.color.r, itemAdded.color.g, itemAdded.color.b, 1f);
        Color endColor = new Color(itemAdded.color.r, itemAdded.color.g, itemAdded.color.b, 0f);

        while (elapsedTime < popupDuration)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / popupDuration;

            // Move up
            rectTransform.anchoredPosition = Vector2.Lerp(startPos, endPos, progress);

            // Fade out
            itemAdded.color = Color.Lerp(new Color(itemAdded.color.r, itemAdded.color.g, itemAdded.color.b, 1f), endColor, progress);

            yield return null;
        }

        // Just ensure it's fully transparent, keep it active for next use
        itemAdded.color = new Color(itemAdded.color.r, itemAdded.color.g, itemAdded.color.b, 0f);
    }

    private void ToggleCartDisplay()
    {
        if (itemsListUI != null)
        {
            itemsListUI.SetActive(!itemsListUI.activeSelf);
            Debug.Log($"[CART] Items list toggled: {itemsListUI.activeSelf}");

            foreach (GameObject obj in objectsToDisable)
            {
                Collider2D col2D = obj.GetComponent<Collider2D>();
                if (col2D != null) col2D.enabled = false;
            }

            if (itemsListUI.activeSelf == false)
            {
                foreach (GameObject obj in objectsToDisable)
                {
                    Collider2D col2D = obj.GetComponent<Collider2D>();
                    if (col2D != null) col2D.enabled = true;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;

        mousePosition = Input.mousePosition;

        Ray mouseRay = Camera.main.ScreenPointToRay(mousePosition);

        prevHoverObject = nextHoverObject;

        raycastHit2D = Physics2D.Raycast(mouseWorldPos, Vector2.zero);
        nextHoverObject = raycastHit2D ? raycastHit2D.collider.transform : null;

        // Handle mouse click to start dragging
        if (Input.GetMouseButtonDown(0))
        {            
            raycastHit2D = Physics2D.Raycast(mouseRay.origin, mouseRay.direction);

            if (raycastHit2D.collider != null)
            {
                clickObject = raycastHit2D.collider.gameObject;

                if (clickObject.CompareTag("Draggable") || clickObject.CompareTag("Cart"))
                {
                    mouseHoldTime = 0f;
                    isDragging = false;

                    draggedObject = InstantiateDraggedObject(clickObject.name, mouseWorldPos);
                    
                    if (draggedObject != null)
                    {
                        draggedObject.SetActive(false);
                        Debug.Log("[MOUSEDOWN] Started dragging clone of: " + clickObject.name);
                    }
                    else
                    {
                        Debug.LogWarning("[MOUSEDOWN] Failed to instantiate object: " + clickObject.name);
                    }
                }
                else if (clickObject.CompareTag("Refrigerator"))
                {
                    refrigeratorScript.ToggleRefrigerator();
                }
            }

            if (clickObject != null)
            { Debug.Log("Clicked on object: " + clickObject.name); }
        }

        // While dragging, move the clone with the mouse
        if (Input.GetMouseButton(0) && draggedObject != null)
        {
            string cleanDraggedName = draggedObject.name.Replace("(Clone)", "").Trim();
            Debug.Log($"[HOLDMOUSE] Dragged Object: {cleanDraggedName}");

            if (mouseHoldTime >= holdThreshold)
            {
                isDragging = true;
                draggedObject.SetActive(true);
                Cursor.SetCursor(dragCursor, Vector2.zero, CursorMode.Auto);
            }
            else
            {
                mouseHoldTime += Time.deltaTime;
                isDragging = false;
            }

            Debug.Log($"[HOLDMOUSE] Mouse hold time: {mouseHoldTime:F2} seconds, IsDragging: {isDragging}");

            if (isDragging)
            {
                draggedObject.SetActive(true);
                draggedObject.transform.position = mouseWorldPos;

                SpriteRenderer spriteRenderer = draggedObject.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    spriteRenderer.sortingOrder = 100; // Higher than typical UI layers
                }

                Debug.Log($"[HOLDMOUSE] Hovering over: {(nextHoverObject != null ? nextHoverObject.name : "nothing")}");

                if (nextHoverObject != null)
                {
                    int indexOfQuantity = -1;
                    if (itemsRequest.Contains(cleanDraggedName))
                    {
                        int indexOf = itemsRequest.IndexOf(cleanDraggedName);
                        Debug.Log($"[HOLDMOUSE] Position of {cleanDraggedName}: {indexOf}");

                        indexOfQuantity = quantityItemRequest[indexOf];
                    }
                    

                    if (nextHoverObject.CompareTag("GiveOrder") && itemsRequest.Contains(cleanDraggedName) && 
                        indexOfQuantity > 0)
                    {
                        ChangeSprite cs = nextHoverObject.GetComponent<ChangeSprite>();
                        if (cs != null)
                        {
                            cs.HighlightSprite();
                        }
                    }
                    else
                    {
                        ChangeSprite cs = nextHoverObject.GetComponent<ChangeSprite>();
                        if (cs != null)
                        {
                            cs.noAcceptItemSprite();
                        }
                    }
                }
                else
                {
                    // If nothing is hovered, reset the previous Cat Eat
                    if (prevHoverObject != null && prevHoverObject.CompareTag("GiveOrder"))
                    {
                        ChangeSprite csPrev = prevHoverObject.GetComponent<ChangeSprite>();
                        if (csPrev != null)
                        {
                            csPrev.ResetSprite();
                        }
                    }
                }
            }
        }


        // Mouse released
        if (Input.GetMouseButtonUp(0))
        {
            bool isCartDrag = draggedObject != null && draggedObject.CompareTag("Cart");

            // Drag cart to GiveOrder (cat) to give items
            if (isCartDrag && nextHoverObject != null && nextHoverObject.CompareTag("GiveOrder"))
            {
                Debug.Log("[CART] Dragged cart to cat - giving all items...");
                GiveItemToCatFromCart();
                itemsInCart.ClearCart();
                ToggleCartDisplay();
            }
            // Drag item to cat to give single item
            else if (draggedObject != null && nextHoverObject != null && nextHoverObject.CompareTag("GiveOrder") && !isCartDrag)
            {
                ChangeSprite cs = nextHoverObject.GetComponent<ChangeSprite>();
                if (cs != null)
                {
                    string cleanDraggedName = draggedObject.name.Replace("(Clone)", "").Trim();
                    Debug.Log($"[MOUSEUP] Dragged Object: {cleanDraggedName}");

                    int indexOfQuantity = -1;
                    if (itemsRequest.Contains(cleanDraggedName))
                    {
                        int indexOf = itemsRequest.IndexOf(cleanDraggedName);
                        Debug.Log($"[HOLDMOUSE] Position of {cleanDraggedName}: {indexOf}");

                        indexOfQuantity = quantityItemRequest[indexOf];
                    }

                    if (itemsRequest.Contains(cleanDraggedName) && indexOfQuantity > 0)
                    {
                        itemsLeft.DecreaseItem(cleanDraggedName);

                        orderScript.DecreaseItemRequest(cleanDraggedName, 1);
                    }
                    
                    cs.ResetSprite();
                }
            }

            // If it was a click (not a drag), handle cart click
            if (!isDragging && (mouseHoldTime < holdThreshold))
            {
                if (clickObject != null)
                {
                    // Click on cart to toggle items list visibility
                    if (clickObject.CompareTag("Cart"))
                    {
                        ToggleCartDisplay();
                    }
                    else if (clickObject.CompareTag("Draggable"))
                    {
                        // Click on item to add to cart
                        AddItemToCartAndDecrease(clickObject.name);
                    }
                }
            }

            // Destroy dragged object (including cart clone)
            if (draggedObject != null)
            {
                Destroy(draggedObject);
            }
            
            draggedObject = null;
            clickObject = null;

            Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);

            CheckItemsLeft();
        }
    }
    void CheckItemsLeft()
    {
        int goyaCandyLeft = itemsLeft.GetGoyaCandyLeft();
        int mentosLeft = itemsLeft.GetMentosLeft();
        int whiteRabbitLeft = itemsLeft.GetWhiteRabbitLeft();
        int riceLeft = itemsLeft.GetRiceLeft();
        int soySauceLeft = itemsLeft.GetSoySauceLeft();
        int vinegarLeft = itemsLeft.GetVinegarLeft();
        int joyLeft = itemsLeft.GetJoyLeft();
        int surfLeft = itemsLeft.GetSurfLeft();
        int paylessXtraBigLeft = itemsLeft.GetPaylessXtraBigLeft();
        int luckyMeLeft = itemsLeft.GetLuckyMeLeft();
        int cupNoodleLeft = itemsLeft.GetCupNoodleLeft();
        int colgateLeft = itemsLeft.GetColgateLeft();
        int rexonaLeft = itemsLeft.GetRexonaLeft();
        int sunsilkLeft = itemsLeft.GetSunsilkLeft();
        int chippyLeft = itemsLeft.GetChippyLeft();
        int novaLeft = itemsLeft.GetNovaLeft();
        int piattosLeft = itemsLeft.GetPiattosLeft();
        int cokeLeft = itemsLeft.GetCokeLeft();
        int pepsiLeft = itemsLeft.GetPepsiLeft();
        int royalLeft = itemsLeft.GetRoyalLeft();
        int zestoAppleLeft = itemsLeft.GetZestoAppleLeft();
        int zestoGrapeLeft = itemsLeft.GetZestoGrapeLeft();
        int zestoOrangeLeft = itemsLeft.GetZestoOrangeLeft();
        int adoboLeft = itemsLeft.GetAdoboLeft();
        int afritadaLeft = itemsLeft.GetAfritadaLeft();
        int flakesInOilLeft = itemsLeft.GetFlakesInOilLeft();
        int cheeseSpreadLeft = itemsLeft.GetCheeseSpreadLeft();
        int nescafeLeft = itemsLeft.GetNescafeLeft();
        int peanutButterLeft = itemsLeft.GetPeanutButterLeft();
        int artisanLeft = itemsLeft.GetArtisanLeft();
        int gardeniaLeft = itemsLeft.GetGardeniaLeft();

        if (goyaCandyLeft == 0)
        { goyaJarObject.SetActive(false); }
        else {  goyaJarObject.SetActive(true); }

        if (mentosLeft == 0)
        { mentosJarObject.SetActive(false); }
        else { mentosJarObject.SetActive(true); }

        if (whiteRabbitLeft == 0)
        { whiteRabbitJarObject.SetActive(false); }
        else { whiteRabbitJarObject.SetActive(true); }

        if (riceLeft == 0)
        { riceObject.SetActive(false); }
        else { riceObject.SetActive(true); }

        if (soySauceLeft == 0)
        { soySauceObject.SetActive(false); }
        else { soySauceObject.SetActive(true); }

        if (vinegarLeft == 0)
        { vinegarObject.SetActive(false); }
        else { vinegarObject.SetActive(true); }

        if (joyLeft == 0)
        { joyObject.SetActive(false); }
        else
        {
            if (joyLeft == 9)
            { joyObject.transform.GetChild(8).gameObject.SetActive(false); }
            else if (joyLeft == 8)
            { joyObject.transform.GetChild(7).gameObject.SetActive(false); }
            else if (joyLeft == 7)
            { joyObject.transform.GetChild(6).gameObject.SetActive(false); }
            else if (joyLeft == 6)
            { joyObject.transform.GetChild(5).gameObject.SetActive(false); }
            else if (joyLeft == 5)
            { joyObject.transform.GetChild(4).gameObject.SetActive(false); }
            else if (joyLeft == 4)
            { joyObject.transform.GetChild(3).gameObject.SetActive(false); }
            else if (joyLeft == 3)
            { joyObject.transform.GetChild(2).gameObject.SetActive(false); }
            else if (joyLeft == 2)
            { joyObject.transform.GetChild(1).gameObject.SetActive(false); }
            else if (joyLeft == 1)
            { joyObject.transform.GetChild(0).gameObject.SetActive(false); }
            else
            {
                joyObject.SetActive(true);
                joyObject.transform.GetChild(0).gameObject.SetActive(true);
                joyObject.transform.GetChild(1).gameObject.SetActive(true);
                joyObject.transform.GetChild(2).gameObject.SetActive(true);
                joyObject.transform.GetChild(3).gameObject.SetActive(true);
                joyObject.transform.GetChild(4).gameObject.SetActive(true);
                joyObject.transform.GetChild(5).gameObject.SetActive(true);
                joyObject.transform.GetChild(6).gameObject.SetActive(true);
                joyObject.transform.GetChild(7).gameObject.SetActive(true);
                joyObject.transform.GetChild(8).gameObject.SetActive(true);
            }
        }

        if (surfLeft == 0)
        { surfObject.SetActive(false); }
        else
        {
            if (surfLeft == 9)
            { surfObject.transform.GetChild(8).gameObject.SetActive(false); }
            else if (surfLeft == 8)
            { surfObject.transform.GetChild(7).gameObject.SetActive(false); }
            else if (surfLeft == 7)
            { surfObject.transform.GetChild(6).gameObject.SetActive(false); }
            else if (surfLeft == 6)
            { surfObject.transform.GetChild(5).gameObject.SetActive(false); }
            else if (surfLeft == 5)
            { surfObject.transform.GetChild(4).gameObject.SetActive(false); }
            else if (surfLeft == 4)
            { surfObject.transform.GetChild(3).gameObject.SetActive(false); }
            else if (surfLeft == 3)
            { surfObject.transform.GetChild(2).gameObject.SetActive(false); }
            else if (surfLeft == 2)
            { surfObject.transform.GetChild(1).gameObject.SetActive(false); }
            else if (surfLeft == 1)
            { surfObject.transform.GetChild(0).gameObject.SetActive(false); }
            else
            {
                surfObject.SetActive(true);
                surfObject.transform.GetChild(0).gameObject.SetActive(true);
                surfObject.transform.GetChild(1).gameObject.SetActive(true);
                surfObject.transform.GetChild(2).gameObject.SetActive(true);
                surfObject.transform.GetChild(3).gameObject.SetActive(true);
                surfObject.transform.GetChild(4).gameObject.SetActive(true);
                surfObject.transform.GetChild(5).gameObject.SetActive(true);
                surfObject.transform.GetChild(6).gameObject.SetActive(true);
                surfObject.transform.GetChild(7).gameObject.SetActive(true);
                surfObject.transform.GetChild(8).gameObject.SetActive(true);
            }
        }

        if (paylessXtraBigLeft == 0)
        { paylessXtraBigObject.SetActive(false); }
        else 
        {
            if (paylessXtraBigLeft == 4)
            { paylessXtraBigObject.transform.GetChild(3).gameObject.SetActive(false); }
            else if (paylessXtraBigLeft == 3)
            { paylessXtraBigObject.transform.GetChild(2).gameObject.SetActive(false); }
            else if (paylessXtraBigLeft == 2)
            { paylessXtraBigObject.transform.GetChild(1).gameObject.SetActive(false); }
            else if (paylessXtraBigLeft == 1)
            { paylessXtraBigObject.transform.GetChild(0).gameObject.SetActive(false); }
            else
            {
                paylessXtraBigObject.SetActive(true);
                paylessXtraBigObject.transform.GetChild(0).gameObject.SetActive(true);
                paylessXtraBigObject.transform.GetChild(1).gameObject.SetActive(true);
                paylessXtraBigObject.transform.GetChild(2).gameObject.SetActive(true);
                paylessXtraBigObject.transform.GetChild(3).gameObject.SetActive(true);
            }
        }

        if (luckyMeLeft == 0)
        { luckyMeObject.SetActive(false); }
        else 
        {
            if (luckyMeLeft == 4)
            { luckyMeObject.transform.GetChild(3).gameObject.SetActive(false); }
            else if (luckyMeLeft == 3)
            { luckyMeObject.transform.GetChild(2).gameObject.SetActive(false); }
            else if (luckyMeLeft == 2)
            { luckyMeObject.transform.GetChild(1).gameObject.SetActive(false); }
            else if (luckyMeLeft == 1)
            { luckyMeObject.transform.GetChild(0).gameObject.SetActive(false); }
            else
            {
                luckyMeObject.SetActive(true);
                luckyMeObject.transform.GetChild(0).gameObject.SetActive(true);
                luckyMeObject.transform.GetChild(1).gameObject.SetActive(true);
                luckyMeObject.transform.GetChild(2).gameObject.SetActive(true);
                luckyMeObject.transform.GetChild(3).gameObject.SetActive(true);
            }
        }

        if (cupNoodleLeft == 0)
        { cupNoodleObject.SetActive(false); }
        else 
        {
            if (cupNoodleLeft == 4)
            { cupNoodleObject.transform.GetChild(3).gameObject.SetActive(false); }
            else if (cupNoodleLeft == 3)
            { cupNoodleObject.transform.GetChild(2).gameObject.SetActive(false); }
            else if (cupNoodleLeft == 2)
            { cupNoodleObject.transform.GetChild(1).gameObject.SetActive(false); }
            else if (cupNoodleLeft == 1)
            { cupNoodleObject.transform.GetChild(0).gameObject.SetActive(false); }
            else
            {
                cupNoodleObject.SetActive(true);
                cupNoodleObject.transform.GetChild(0).gameObject.SetActive(true);
                cupNoodleObject.transform.GetChild(1).gameObject.SetActive(true);
                cupNoodleObject.transform.GetChild(2).gameObject.SetActive(true);
                cupNoodleObject.transform.GetChild(3).gameObject.SetActive(true);
            }
        }

        if (colgateLeft == 0)
        { colgateObject.SetActive(false); }
        else 
        { 
            if (colgateLeft == 4)
            { colgateObject.transform.GetChild(3).gameObject.SetActive(false); }
            else if (colgateLeft == 3)
            { colgateObject.transform.GetChild(2).gameObject.SetActive(false); }
            else if (colgateLeft == 2)
            { colgateObject.transform.GetChild(1).gameObject.SetActive(false); }
            else if (colgateLeft == 1)
            { colgateObject.transform.GetChild(0).gameObject.SetActive(false); }
            else
            {
                colgateObject.SetActive(true);
                colgateObject.transform.GetChild(0).gameObject.SetActive(true);
                colgateObject.transform.GetChild(1).gameObject.SetActive(true);
                colgateObject.transform.GetChild(2).gameObject.SetActive(true);
                colgateObject.transform.GetChild(3).gameObject.SetActive(true);
            }
        }

        if (rexonaLeft == 0)
        { rexonaObject.SetActive(false); }
        else 
        { 
            if (rexonaLeft == 4)
            { rexonaObject.transform.GetChild(3).gameObject.SetActive(false); }
            else if (rexonaLeft == 3)
            { rexonaObject.transform.GetChild(2).gameObject.SetActive(false); }
            else if (rexonaLeft == 2)
            { rexonaObject.transform.GetChild(1).gameObject.SetActive(false); }
            else if (rexonaLeft == 1)
            { rexonaObject.transform.GetChild(0).gameObject.SetActive(false); }
            else
            {
                rexonaObject.SetActive(true);
                rexonaObject.transform.GetChild(0).gameObject.SetActive(true);
                rexonaObject.transform.GetChild(1).gameObject.SetActive(true);
                rexonaObject.transform.GetChild(2).gameObject.SetActive(true);
                rexonaObject.transform.GetChild(3).gameObject.SetActive(true);
            }
        }

        if (sunsilkLeft == 0)
        { sunsilkObject.SetActive(false); }
        else 
        {
            if (sunsilkLeft == 4)
            { sunsilkObject.transform.GetChild(3).gameObject.SetActive(false); }
            else if (sunsilkLeft == 3)
            { sunsilkObject.transform.GetChild(2).gameObject.SetActive(false); }
            else if (sunsilkLeft == 2)
            { sunsilkObject.transform.GetChild(1).gameObject.SetActive(false); }
            else if (sunsilkLeft == 1)
            { sunsilkObject.transform.GetChild(0).gameObject.SetActive(false); }
            else
            {
                sunsilkObject.SetActive(true);
                sunsilkObject.transform.GetChild(0).gameObject.SetActive(true);
                sunsilkObject.transform.GetChild(1).gameObject.SetActive(true);
                sunsilkObject.transform.GetChild(2).gameObject.SetActive(true);
                sunsilkObject.transform.GetChild(3).gameObject.SetActive(true);
            }
        }

        if (chippyLeft == 0)
        { chippyObject.SetActive(false); }
        else 
        {
            if (chippyLeft == 4)
            { chippyObject.transform.GetChild(3).gameObject.SetActive(false); }
            else if (chippyLeft == 3)
            { chippyObject.transform.GetChild(2).gameObject.SetActive(false); }
            else if (chippyLeft == 2)
            { chippyObject.transform.GetChild(1).gameObject.SetActive(false); }
            else if (chippyLeft == 1)
            { chippyObject.transform.GetChild(0).gameObject.SetActive(false); }
            else
            {
                chippyObject.SetActive(true);
                chippyObject.transform.GetChild(0).gameObject.SetActive(true);
                chippyObject.transform.GetChild(1).gameObject.SetActive(true);
                chippyObject.transform.GetChild(2).gameObject.SetActive(true);
                chippyObject.transform.GetChild(3).gameObject.SetActive(true);
            }
        }

        if (novaLeft == 0)
        { novaObject.SetActive(false); }
        else 
        { 
            if (novaLeft == 4)
            { novaObject.transform.GetChild(3).gameObject.SetActive(false); }
            else if (novaLeft == 3)
            { novaObject.transform.GetChild(2).gameObject.SetActive(false); }
            else if (novaLeft == 2)
            { novaObject.transform.GetChild(1).gameObject.SetActive(false); }
            else if (novaLeft == 1)
            { novaObject.transform.GetChild(0).gameObject.SetActive(false); }
            else
            {
                novaObject.SetActive(true);
                novaObject.transform.GetChild(0).gameObject.SetActive(true);
                novaObject.transform.GetChild(1).gameObject.SetActive(true);
                novaObject.transform.GetChild(2).gameObject.SetActive(true);
                novaObject.transform.GetChild(3).gameObject.SetActive(true);
            }
        }

        if (piattosLeft == 0)
        { piattosObject.SetActive(false); }
        else 
        { 
            if (piattosLeft == 4)
            { piattosObject.transform.GetChild(3).gameObject.SetActive(false); }
            else if (piattosLeft == 3)
            { piattosObject.transform.GetChild(2).gameObject.SetActive(false); }
            else if (piattosLeft == 2)
            { piattosObject.transform.GetChild(1).gameObject.SetActive(false); }
            else if (piattosLeft == 1)
            { piattosObject.transform.GetChild(0).gameObject.SetActive(false); }
            else
            {
                piattosObject.SetActive(true);
                piattosObject.transform.GetChild(0).gameObject.SetActive(true);
                piattosObject.transform.GetChild(1).gameObject.SetActive(true);
                piattosObject.transform.GetChild(2).gameObject.SetActive(true);
                piattosObject.transform.GetChild(3).gameObject.SetActive(true);
            }
        }

        if (cokeLeft == 0)
        { cokeObject.SetActive(false); }
        else
        {
            if (cokeLeft == 2)
            { cokeObject.transform.GetChild(1).gameObject.SetActive(false); }
            else if (cokeLeft == 1)
            { cokeObject.transform.GetChild(0).gameObject.SetActive(false); }
            else
            {
                cokeObject.SetActive(true);
                cokeObject.transform.GetChild(0).gameObject.SetActive(true);
                cokeObject.transform.GetChild(1).gameObject.SetActive(true);
            }
        }

        if (pepsiLeft == 0)
        { pepsiObject.SetActive(false); }
        else
        {
            if (pepsiLeft == 2)
            { pepsiObject.transform.GetChild(1).gameObject.SetActive(false); }
            else if (pepsiLeft == 1)
            { pepsiObject.transform.GetChild(0).gameObject.SetActive(false); }
            else
            {
                pepsiObject.SetActive(true);
                pepsiObject.transform.GetChild(0).gameObject.SetActive(true);
                pepsiObject.transform.GetChild(1).gameObject.SetActive(true);
            }
        }

        if (royalLeft == 0)
        { royalObject.SetActive(false); }
        else 
        {
            if (royalLeft == 2)
            { royalObject.transform.GetChild(1).gameObject.SetActive(false); }
            else if (royalLeft == 1)
            { royalObject.transform.GetChild(0).gameObject.SetActive(false); }
            else
            {
                royalObject.SetActive(true);
                royalObject.transform.GetChild(0).gameObject.SetActive(true);
                royalObject.transform.GetChild(1).gameObject.SetActive(true);
            }
        }

        if (zestoAppleLeft == 0)
        { zestoAppleObject.SetActive(false); }
        else
        {
            if (zestoAppleLeft == 2)
            { zestoAppleObject.transform.GetChild(1).gameObject.SetActive(false); }
            else if (zestoAppleLeft == 1)
            { zestoAppleObject.transform.GetChild(0).gameObject.SetActive(false); }
            else
            {
                zestoAppleObject.SetActive(true);
                zestoAppleObject.transform.GetChild(0).gameObject.SetActive(true);
                zestoAppleObject.transform.GetChild(1).gameObject.SetActive(true);
            }
        }

        if (zestoGrapeLeft == 0)
        { zestoGrapeObject.SetActive(false); }
        else 
        {
            if (zestoGrapeLeft == 2)
            { zestoGrapeObject.transform.GetChild(1).gameObject.SetActive(false); }
            else if (zestoGrapeLeft == 1)
            { zestoGrapeObject.transform.GetChild(0).gameObject.SetActive(false); }
            else
            {
                zestoGrapeObject.SetActive(true);
                zestoGrapeObject.transform.GetChild(0).gameObject.SetActive(true);
                zestoGrapeObject.transform.GetChild(1).gameObject.SetActive(true);
            }
        }

        if (zestoOrangeLeft == 0)
        { zestoOrangeObject.SetActive(false); }
        else 
        {
            if (zestoOrangeLeft == 2)
            { zestoOrangeObject.transform.GetChild(1).gameObject.SetActive(false); }
            else if (zestoOrangeLeft == 1)
            { zestoOrangeObject.transform.GetChild(0).gameObject.SetActive(false); }
            else
            {
                zestoOrangeObject.SetActive(true);
                zestoOrangeObject.transform.GetChild(0).gameObject.SetActive(true);
                zestoOrangeObject.transform.GetChild(1).gameObject.SetActive(true);
            }
        }

        if (adoboLeft == 0)
        { adoboObject.SetActive(true); }
        else
        {
            if (adoboLeft == 4)
            { adoboObject.transform.GetChild(3).gameObject.SetActive(false); }
            else if (adoboLeft == 3)
            { adoboObject.transform.GetChild(2).gameObject.SetActive(false); }
            else if (adoboLeft == 2)
            { adoboObject.transform.GetChild(1).gameObject.SetActive(false); }
            else if (adoboLeft == 1)
            { adoboObject.transform.GetChild(0).gameObject.SetActive(false); }
            else
            {
                adoboObject.SetActive(true);
                adoboObject.transform.GetChild(0).gameObject.SetActive(true);
                adoboObject.transform.GetChild(1).gameObject.SetActive(true);
                adoboObject.transform.GetChild(2).gameObject.SetActive(true);
                adoboObject.transform.GetChild(3).gameObject.SetActive(true);
            }
        }

        if (afritadaLeft == 0)
        { afritadaObject.SetActive(true); }
        else
        {
            if (afritadaLeft == 4)
            { afritadaObject.transform.GetChild(3).gameObject.SetActive(false); }
            else if (afritadaLeft == 3)
            { afritadaObject.transform.GetChild(2).gameObject.SetActive(false); }
            else if (afritadaLeft == 2)
            { afritadaObject.transform.GetChild(1).gameObject.SetActive(false); }
            else if (afritadaLeft == 1)
            { afritadaObject.transform.GetChild(0).gameObject.SetActive(false); }
            else
            {
                afritadaObject.SetActive(true);
                afritadaObject.transform.GetChild(0).gameObject.SetActive(true);
                afritadaObject.transform.GetChild(1).gameObject.SetActive(true);
                afritadaObject.transform.GetChild(2).gameObject.SetActive(true);
                afritadaObject.transform.GetChild(3).gameObject.SetActive(true);
            }
        }

        if (flakesInOilLeft == 0)
        { flakesInOilObject.SetActive(true); }
        else
        {
            if (flakesInOilLeft == 4)
            { flakesInOilObject.transform.GetChild(3).gameObject.SetActive(false); }
            else if (flakesInOilLeft == 3)
            { flakesInOilObject.transform.GetChild(2).gameObject.SetActive(false); }
            else if (flakesInOilLeft == 2)
            { flakesInOilObject.transform.GetChild(1).gameObject.SetActive(false); }
            else if (flakesInOilLeft == 1)
            { flakesInOilObject.transform.GetChild(0).gameObject.SetActive(false); }
            else
            {
                flakesInOilObject.SetActive(true);
                flakesInOilObject.transform.GetChild(0).gameObject.SetActive(true);
                flakesInOilObject.transform.GetChild(1).gameObject.SetActive(true);
                flakesInOilObject.transform.GetChild(2).gameObject.SetActive(true);
                flakesInOilObject.transform.GetChild(3).gameObject.SetActive(true);
            }
        }

        if (cheeseSpreadLeft == 0)
        { cheeseSpreadObject.SetActive(true); }
        else
        {
            if (cheeseSpreadLeft == 4)
            { cheeseSpreadObject.transform.GetChild(3).gameObject.SetActive(false); }
            else if (cheeseSpreadLeft == 3)
            { cheeseSpreadObject.transform.GetChild(2).gameObject.SetActive(false); }
            else if (cheeseSpreadLeft == 2)
            { cheeseSpreadObject.transform.GetChild(1).gameObject.SetActive(false); }
            else if (cheeseSpreadLeft == 1)
            { cheeseSpreadObject.transform.GetChild(0).gameObject.SetActive(false); }
            else
            {
                cheeseSpreadObject.SetActive(true);
                cheeseSpreadObject.transform.GetChild(0).gameObject.SetActive(true);
                cheeseSpreadObject.transform.GetChild(1).gameObject.SetActive(true);
                cheeseSpreadObject.transform.GetChild(2).gameObject.SetActive(true);
                cheeseSpreadObject.transform.GetChild(3).gameObject.SetActive(true);
            }
        }

        if (nescafeLeft == 0)
        { nescafeObject.SetActive(true); }
        else
        {
            if (nescafeLeft == 4)
            { nescafeObject.transform.GetChild(3).gameObject.SetActive(false); }
            else if (nescafeLeft == 3)
            { nescafeObject.transform.GetChild(2).gameObject.SetActive(false); }
            else if (nescafeLeft == 2)
            { nescafeObject.transform.GetChild(1).gameObject.SetActive(false); }
            else if (nescafeLeft == 1)
            { nescafeObject.transform.GetChild(0).gameObject.SetActive(false); }
            else
            {
                nescafeObject.SetActive(true);
                nescafeObject.transform.GetChild(0).gameObject.SetActive(true);
                nescafeObject.transform.GetChild(1).gameObject.SetActive(true);
                nescafeObject.transform.GetChild(2).gameObject.SetActive(true);
                nescafeObject.transform.GetChild(3).gameObject.SetActive(true);
            }
        }

        if (peanutButterLeft == 0)
        { peanutButterObject.SetActive(true); }
        else
        {
            if (peanutButterLeft == 4)
            { peanutButterObject.transform.GetChild(3).gameObject.SetActive(false); }
            else if (peanutButterLeft == 3)
            { peanutButterObject.transform.GetChild(2).gameObject.SetActive(false); }
            else if (peanutButterLeft == 2)
            { peanutButterObject.transform.GetChild(1).gameObject.SetActive(false); }
            else if (peanutButterLeft == 1)
            { peanutButterObject.transform.GetChild(0).gameObject.SetActive(false); }
            else
            {
                peanutButterObject.SetActive(true);
                peanutButterObject.transform.GetChild(0).gameObject.SetActive(true);
                peanutButterObject.transform.GetChild(1).gameObject.SetActive(true);
                peanutButterObject.transform.GetChild(2).gameObject.SetActive(true);
                peanutButterObject.transform.GetChild(3).gameObject.SetActive(true);
            }
        }

        if (artisanLeft == 0)
        { artisanObject.SetActive(true); }
        else
        {
            if (artisanLeft == 4)
            { artisanObject.transform.GetChild(3).gameObject.SetActive(false); }
            else if (artisanLeft == 3)
            { artisanObject.transform.GetChild(2).gameObject.SetActive(false); }
            else if (artisanLeft == 2)
            { artisanObject.transform.GetChild(1).gameObject.SetActive(false); }
            else if (artisanLeft == 1)
            { artisanObject.transform.GetChild(0).gameObject.SetActive(false); }
            else
            {
                artisanObject.SetActive(true);
                artisanObject.transform.GetChild(0).gameObject.SetActive(true);
                artisanObject.transform.GetChild(1).gameObject.SetActive(true);
                artisanObject.transform.GetChild(2).gameObject.SetActive(true);
                artisanObject.transform.GetChild(3).gameObject.SetActive(true);
            }
        }

        if (gardeniaLeft == 0)
        { gardeniaObject.SetActive(true); }
        else
        {
            if (gardeniaLeft == 4)
            { gardeniaObject.transform.GetChild(3).gameObject.SetActive(false); }
            else if (gardeniaLeft == 3)
            { gardeniaObject.transform.GetChild(2).gameObject.SetActive(false); }
            else if (gardeniaLeft == 2)
            { gardeniaObject.transform.GetChild(1).gameObject.SetActive(false); }
            else if (gardeniaLeft == 1)
            { gardeniaObject.transform.GetChild(0).gameObject.SetActive(false); }
            else
            {
                gardeniaObject.SetActive(true);
                gardeniaObject.transform.GetChild(0).gameObject.SetActive(true);
                gardeniaObject.transform.GetChild(1).gameObject.SetActive(true);
                gardeniaObject.transform.GetChild(2).gameObject.SetActive(true);
                gardeniaObject.transform.GetChild(3).gameObject.SetActive(true);
            }
        }
    }

    private void GiveItemToCatFromCart()
    {
        List<string> cartItems = itemsInCart.GetCartItems();

        if (!cartItems.Any(item => itemsRequest.Contains(item)))
            return;

        Debug.Log("[CART] Giving items to cat from cart...");

        var itemCounts = new Dictionary<string, int>();
        foreach (var item in cartItems)
        {
            if (itemCounts.ContainsKey(item))
                itemCounts[item]++;
            else
                itemCounts[item] = 1;
        }

        foreach (var itemEntry in itemCounts)
        {
            string itemName = itemEntry.Key;
            int quantity = itemEntry.Value;

            if (itemsRequest.Contains(itemName))
            {
                int indexOf = itemsRequest.IndexOf(itemName);
                int requestedQuantity = quantityItemRequest[indexOf];
                int quantityToGive = Mathf.Min(quantity, requestedQuantity);

                if (quantityToGive > 0)
                {
                    orderScript.DecreaseItemRequest(itemName, quantityToGive);
                    Debug.Log($"[CART] Gave {quantityToGive} x {itemName} to cat");
                }
            }
        }
    }

    public void GetItemListRequestAndQuantity()
    {
        itemsRequest = new List<string>(orderScript.getItemsRequest());
        quantityItemRequest = new List<int>(orderScript.getQuantitiesRequest());

        for (int i = 0; i < itemsRequest.Count; i++)
        {
            Debug.Log($"[DRAGDROPCLICK] Item Request {i + 1}: {itemsRequest[i]}, Quantity: {quantityItemRequest[i]}");
        }
    }

    public void setItemsRequest(List<string> itemsRequest) { this.itemsRequest = itemsRequest; }
    public void setQuantitiesRequest(List<int> quantityItemRequest) { this.quantityItemRequest = quantityItemRequest; }
    public List<string> getItemsRequest() { return itemsRequest; }
    public List<int> getQuantitiesRequest() { return quantityItemRequest; }
}

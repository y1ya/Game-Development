using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class OrderScript : MonoBehaviour
{
    public GameObject requestItem;
    public GameObject item1;
    public GameObject item2;

    private Dictionary<int, Vector3> itemScales;

    private Vector3 item1OriginalScale;
    private Vector3 item2OriginalScale;

    public Sprite[] items;

    public Text oneItemRequest;

    public Text item1QuantityText;
    public Text item2QuantityText;

    private int manyItems, whatItemRoll;
    private List<string> itemName;
    private List<int> itemQuantities;

    public DragDropClick dragDropClick;
    public PayingCustomer payingCustomer;
    public DisablingUI disableUI;

    private void Start()
    {
        InitializeItemScales();
        GetOrderRandomizer();
    }

    private void InitializeItemScales()
    {
        itemScales = new Dictionary<int, Vector3>
        {
            { 0, new Vector3(0.31f, 0.31f, 0.31f) },        // Goya Candy - default scale
            { 1, new Vector3(0.23f, 0.23f, 0.23f) },        // Mentos
            { 2, new Vector3(0.14f, 0.14f, 0.14f) },  // Rice - larger
            { 3, new Vector3(0.14f, 0.14f, 0.14f) },  // Soy Sauce - smaller
            { 4, new Vector3(0.14f, 0.14f, 0.14f) },        // Vinegar
            { 5, new Vector3(0.22f, 0.22f, 0.22f) },  // White Rabbit
            { 6, new Vector3(0.13f, 0.13f, 0.13f) },        // Joy
            { 7, new Vector3(0.13f, 0.13f, 0.13f) },        // Surf
            { 8, new Vector3(0.15f, 0.15f, 0.15f) },  // Payless Xtra Big - larger
            { 9, new Vector3(0.16f, 0.16f, 0.16f) },        // Lucky Me
            { 10, new Vector3(0.13f, 0.13f, 0.13f) }, // Cup Noodle - slightly smaller
            { 11, new Vector3(0.19f, 0.19f, 0.19f) },       // Colgate
            { 12, new Vector3(0.13f, 0.13f, 0.13f) },       // Rexona
            { 13, new Vector3(0.19f, 0.19f, 0.19f) },       // Sunsilk
            { 14, new Vector3(0.14f, 0.14f, 0.14f) }, // Chippy
            { 15, new Vector3(0.14f, 0.14f, 0.14f) },       // Nova
            { 16, new Vector3(0.14f, 0.14f, 0.14f) }, // Piattos
            { 17, new Vector3(0.13f, 0.13f, 0.13f) },       // Coke
            { 18, new Vector3(0.13f, 0.13f, 0.13f) },       // Pepsi
            { 19, new Vector3(0.13f, 0.13f, 0.13f) },       // Royal
            { 20, new Vector3(0.15f, 0.15f, 0.15f) },       // Zesto Apple
            { 21, new Vector3(0.13f, 0.13f, 0.13f) },       // Zesto Grape
            { 22, new Vector3(0.13f, 0.13f, 0.13f) },       // Zesto Orange
            { 23, new Vector3(0.37f, 0.37f, 0.37f) }, // Adobo
            { 24, new Vector3(0.37f, 0.37f, 0.37f) }, // Afritada
            { 25, new Vector3(0.15f, 0.15f, 0.15f) }, // Flakes in Oil
            { 26, new Vector3(0.13f, 0.13f, 0.13f) }, // Cheese Spread - smaller
            { 27, new Vector3(0.13f, 0.13f, 0.13f) },      // Nescafe
            { 28, new Vector3(0.13f, 0.13f, 0.13f) }, // Peanut Butter
            { 29, new Vector3(0.35f, 0.35f, 0.35f) }, // Artisan
            { 30, new Vector3(0.44f, 0.44f, 0.44f) } // Gardenia - larger
        };
    }

    private string GetItemNameByIndex(int index)
    {
        string[] itemNames = new string[]
        {
            "Goya Candy", "Mentos", "Rice", "Soy Sauce", "Vinegar", "White Rabbit",
            "Joy", "Surf", "Payless Xtra Big", "Lucky Me", "Cup Noodle", "Colgate",
            "Rexona", "Sunsilk", "Chippy", "Nova", "Piattos", "Coke", "Pepsi", "Royal",
            "Zesto Apple", "Zesto Grape", "Zesto Orange", "Adobo", "Afritada",
            "Flakes in Oil", "Cheese Spread", "Nescafe", "Peanut Butter", "Artisan", "Gardenia"
        };

        return index >= 0 && index < itemNames.Length ? itemNames[index] : "Unknown";
    }

    public void GetOrderRandomizer()
    {
        item1OriginalScale = item1.transform.localScale;
        item2OriginalScale = item2.transform.localScale;

        int countItems = items.Length;

        requestItem.SetActive(true);
        manyItems = Random.Range(1, 3);

        itemName = new List<string>(); 
        itemQuantities = new List<int>();

        /*
        1 = 1 item
        2 = 2 items
        */

        if (manyItems == 1)
        {
            item1.SetActive(true);
            Debug.Log("[ORDER] Items: 1");

            whatItemRoll = Random.Range(0, countItems);

            string itemNameString = GetItemNameByIndex(whatItemRoll);
            itemName.Add(itemNameString);
            Debug.Log($"[ORDER] Item: {itemNameString}");

            item1.GetComponent<SpriteRenderer>().sprite = items[whatItemRoll];
            item1.transform.localScale = itemScales[whatItemRoll];

            GetQuantityOrderRandomizer(manyItems, whatItemRoll);
        }
        else if (manyItems == 2)
        { Debug.Log("[ORDER] Items: 2");

            int whatItemRoll1 = Random.Range(0, countItems);
            int whatItemRoll2 = Random.Range(0, countItems);

            while (whatItemRoll1 == whatItemRoll2)
            {
                whatItemRoll2 = Random.Range(0, countItems);
            }

            item1.SetActive(true);
            item2.SetActive(true);

            itemName.Add(items[whatItemRoll1].name);
            itemName.Add(items[whatItemRoll2].name);

            item1.GetComponent<SpriteRenderer>().sprite = items[whatItemRoll1];
            item1.transform.localScale = itemScales[whatItemRoll1];

            item2.GetComponent<SpriteRenderer>().sprite = items[whatItemRoll2];
            item2.transform.localScale = itemScales[whatItemRoll2];            

            GetQuantityOrderRandomizer(manyItems, itemName.Count);
        }

        for (int i = 0; i < itemName.Count; i++)
        {
            Debug.Log($"[ORDER] Item {i + 1}: {itemName[i]}");
        }
    }

    private void GetQuantityOrderRandomizer(int randItems, int whatItem)
    {
        int quantity = Random.Range(1, 10);

        if (randItems == 1)
        {
            if (whatItem >= 0)
            {
                oneItemRequest.enabled = true;

                Debug.Log($"[ORDER] One Item Req: {quantity}");
                oneItemRequest.text = $"{quantity}";
            }

            itemQuantities.Add(quantity);
        }
        else if (randItems == itemName.Count)
        {
            Sprite sprite;
            string spriteName;

            for (int i = 0; i < randItems; i++)
            {
                sprite = items[i];
                spriteName = sprite.name;

                int quantityItems = Random.Range(1, 6);
                Debug.Log($"[ORDER] Quantity for Item {i + 1} ({spriteName}): {quantityItems}");

                itemQuantities.Add(quantityItems);
            }

            item1QuantityText.enabled = true;
            item2QuantityText.enabled = true;

            item1QuantityText.text = $"{itemQuantities[0]}";
            item2QuantityText.text = $"{itemQuantities[1]}";
        }
    }

    public void DecreaseItemRequest(string itemName, int itemToGive)
    {
        if (itemName == "Goya Candy")
        {
            //get current position of Goya Candy in itemName/itemQuantities list
            int index = this.itemName.IndexOf(itemName);
            int quantity = itemQuantities[index];

            if (quantity > 0)
            {
                quantity -= itemToGive;
                itemQuantities[index] = quantity;

                Debug.Log($"[ORDER] Value of manyItems: {manyItems}");

                if (manyItems == 1)
                {
                    oneItemRequest.text = $"{quantity}";
                    Debug.Log($"[ORDER] Decreasing the One Item Req quantity by {itemToGive} for one item request.");
                }
                else
                {
                    if (index == 0)
                    {
                        item1QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Goya Candy quantity. New quantity: {quantity}");
                    }
                    else if (index == 1)
                    {
                        item2QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Goya Candy quantity. New quantity: {quantity}");
                    }
                }
            }

            if (quantity == 0)
            {
                if (manyItems == 1)
                {
                    Debug.Log("[ORDER] Goya Candy order complete!");
                    oneItemRequest.enabled = false;
                }
                else
                {
                    if (index == 0)
                    {
                        item1.SetActive(false);
                        item1QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Goya Candy quantity. New quantity: {quantity}");
                    }
                    else if (index == 1)
                    {
                        item2.SetActive(false);
                        item2QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Goya Candy quantity. New quantity: {quantity}");
                    }
                }
            }
        }
        else if (itemName == "Mentos")
        {
            //get current position of Mentos in itemName/itemQuantities list
            int index = this.itemName.IndexOf(itemName);
            int quantity = itemQuantities[index];

            if (quantity > 0)
            {
                quantity -= itemToGive;
                itemQuantities[index] = quantity;

                Debug.Log($"[ORDER] Value of manyItems: {manyItems}");

                if (manyItems == 1)
                {
                    oneItemRequest.text = $"{quantity}";
                    Debug.Log($"[ORDER] Decreasing the One Item Req quantity by {itemToGive} for one item request.");
                }
                else
                {
                    if (index == 0)
                    {
                        item1QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Mentos quantity. New quantity: {quantity}");
                    }
                    else if (index == 1)
                    {
                        item2QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Mentos quantity. New quantity: {quantity}");
                    }
                }
            }

            if (quantity == 0)
            {
                if (manyItems == 1)
                {
                    Debug.Log("[ORDER] Mentos order complete!");
                    oneItemRequest.enabled = false;
                }
                else
                {
                    if (index == 0)
                    {
                        item1.SetActive(false);
                        item1QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Mentos quantity. New quantity: {quantity}");
                    }
                    else if (index == 1)
                    {
                        item2.SetActive(false);
                        item2QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Mentos quantity. New quantity: {quantity}");
                    }
                }
            }
        }
        else if (itemName == "White Rabbit")
        {
            //get current position of White Rabbit in itemName/itemQuantities list
            int index = this.itemName.IndexOf(itemName);
            int quantity = itemQuantities[index];

            if (quantity > 0)
            {
                quantity -= itemToGive;
                itemQuantities[index] = quantity;

                if (manyItems == 1)
                {
                    oneItemRequest.text = $"{quantity}";
                    Debug.Log($"[ORDER] Decreasing the One Item Req quantity by {itemToGive} for one item request.");
                }
                else
                {
                    if (index == 0)
                    {
                        item1QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased White Rabbit quantity. New quantity: {quantity}");
                    }
                    else if (index == 1)
                    {
                        item2QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased White Rabbit quantity. New quantity: {quantity}");
                    }
                }
            }

            if (quantity == 0)
            {
                if (manyItems == 1)
                {
                    Debug.Log("[ORDER] White Rabbit order complete!");
                    oneItemRequest.enabled = false;
                }
                else
                {
                    if (index == 0)
                    {
                        item1.SetActive(false);
                        item1QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased White Rabbit quantity. New quantity: {quantity}");
                    }
                    else if (index == 1)
                    {
                        item2.SetActive(false);
                        item2QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased White Rabbit quantity. New quantity: {quantity}");
                    }
                }
            }
        }
        else if (itemName == "Rice")
        {
            //get current position of Rice in itemName/itemQuantities list
            int index = this.itemName.IndexOf(itemName);
            int quantity = itemQuantities[index];

            if (quantity > 0)
            {
                quantity -= itemToGive;
                itemQuantities[index] = quantity;

                if (manyItems == 1)
                {
                    oneItemRequest.text = $"{quantity}";
                    Debug.Log($"[ORDER] Decreasing the One Item Req quantity by {itemToGive} for one item request.");
                }
                else
                {
                    if (index == 0)
                    {
                        item1QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Rice quantity. New quantity: {quantity}");
                    }
                    else if (index == 1)
                    {
                        item2QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Rice quantity. New quantity: {quantity}");
                    }
                }
            }

            if (quantity == 0)
            {
                if (manyItems == 1)
                {
                    Debug.Log("[ORDER] Rice order complete!");
                    oneItemRequest.enabled = false;
                }
                else
                {
                    if (index == 0)
                    {
                        item1.SetActive(false);
                        item1QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Rice quantity. New quantity: {quantity}");
                    }
                    else if (index == 1)
                    {
                        item2.SetActive(false);
                        item2QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Rice quantity. New quantity: {quantity}");
                    }
                }
            }
        }
        else if (itemName == "Soy Sauce")
        {
            //get current position of Soy Sauce in itemName/itemQuantities list
            int index = this.itemName.IndexOf(itemName);
            int quantity = itemQuantities[index];

            if (quantity > 0)
            {
                quantity -= itemToGive;
                itemQuantities[index] = quantity;

                if (manyItems == 1)
                {
                    oneItemRequest.text = $"{quantity}";
                    Debug.Log($"[ORDER] Decreasing the One Item Req quantity by {itemToGive} for one item request.");
                }
                else
                {
                    if (index == 0)
                    {
                        item1QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Soy Sauce quantity. New quantity: {quantity}");
                    }
                    else if (index == 1)
                    {
                        item2QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Soy Sauce quantity. New quantity: {quantity}");
                    }
                }
            }

            if (quantity == 0)
            {
                if (manyItems == 1)
                {
                    Debug.Log("[ORDER] Soy Sauce order complete!");
                    oneItemRequest.enabled = false;
                }
                else
                {
                    if (index == 0)
                    {
                        item1.SetActive(false);
                        item1QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Soy Sauce quantity. New quantity: {quantity}");
                    }
                    else if (index == 1)
                    {
                        item2.SetActive(false);
                        item2QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Soy Sauce quantity. New quantity: {quantity}");
                    }
                }
            }
        }
        else if (itemName == "Vinegar")
        {
            //get current position of Vinegar in itemName/itemQuantities list
            int index = this.itemName.IndexOf(itemName);
            int quantity = itemQuantities[index];

            if (quantity > 0)
            {
                quantity -= itemToGive;
                itemQuantities[index] = quantity;

                if (manyItems == 1)
                {
                    oneItemRequest.text = $"{quantity}";
                    Debug.Log($"[ORDER] Decreasing the One Item Req quantity by {itemToGive} for one item request.");
                }
                else
                {
                    if (index == 0)
                    {
                        item1QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Vinegar quantity. New quantity: {quantity}");
                    }
                    else if (index == 1)
                    {
                        item2QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Vinegar quantity. New quantity: {quantity}");
                    }
                }
            }

            if (quantity == 0)
            {
                if (manyItems == 1)
                {
                    Debug.Log("[ORDER] Vinegar order complete!");
                    oneItemRequest.enabled = false;
                }
                else
                {
                    if (index == 0)
                    {
                        item1.SetActive(false);
                        item1QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Vinegar quantity. New quantity: {quantity}");
                    }
                    else if (index == 1)
                    {
                        item2.SetActive(false);
                        item2QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Vinegar quantity. New quantity: {quantity}");
                    }
                }
            }
        }
        else if (itemName == "Joy")
        {
            //get current position of Joy in itemName/itemQuantities list
            int index = this.itemName.IndexOf(itemName);
            int quantity = itemQuantities[index];
            if (quantity > 0)
            {
                quantity -= itemToGive;
                itemQuantities[index] = quantity;
                if (manyItems == 1)
                {
                    oneItemRequest.text = $"{quantity}";
                    Debug.Log($"[ORDER] Decreasing the One Item Req quantity by {itemToGive} for one item request.");
                }
                else
                {
                    if (index == 0)
                    {
                        item1QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Joy quantity. New quantity: {quantity}");
                    }
                    else if (index == 1)
                    {
                        item2QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Joy quantity. New quantity: {quantity}");
                    }
                }
            }

            if (quantity == 0)
            {
                if (manyItems == 1)
                {
                    Debug.Log("[ORDER] Joy order complete!");
                    oneItemRequest.enabled = false;
                }
                else
                {
                    if (index == 0)
                    {
                        item1.SetActive(false);
                        item1QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Joy quantity. New quantity: {quantity}");
                    }
                    else if (index == 1)
                    {
                        item2.SetActive(false);
                        item2QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Joy quantity. New quantity: {quantity}");
                    }
                }
            }
        }
        else if (itemName == "Surf")
        {
            //get current position of Surf in itemName/itemQuantities list
            int index = this.itemName.IndexOf(itemName);
            int quantity = itemQuantities[index];
            if (quantity > 0)
            {
                quantity -= itemToGive;
                itemQuantities[index] = quantity;
                if (manyItems == 1)
                {
                    oneItemRequest.text = $"{quantity}";
                    Debug.Log($"[ORDER] Decreasing the One Item Req quantity by {itemToGive} for one item request.");
                }
                else
                {
                    if (index == 0)
                    {
                        item1QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Surf quantity. New quantity: {quantity}");
                    }
                    else
                    {
                        item2QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Surf quantity. New quantity: {quantity}");
                    }
                }
            }

            if (quantity == 0)
            {
                if (manyItems == 1)
                {
                    Debug.Log("[ORDER] Surf order complete!");
                    oneItemRequest.enabled = false;
                }
                else
                {
                    if (index == 0)
                    {
                        item1.SetActive(false);
                        item1QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Surf quantity. New quantity: {quantity}");
                    }
                    else if (index == 1)
                    {
                        item2.SetActive(false);
                        item2QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Surf quantity. New quantity: {quantity}");
                    }
                }
            }
        }
        else if (itemName == "Payless Xtra Big")
        {
            //get current position of Payless Xtrabig in itemName/itemQuantities list
            int index = this.itemName.IndexOf(itemName);
            int quantity = itemQuantities[index];
            if (quantity > 0)
            {
                quantity -= itemToGive;
                itemQuantities[index] = quantity;
                if (manyItems == 1)
                {
                    oneItemRequest.text = $"{quantity}";
                    Debug.Log($"[ORDER] Decreasing the One Item Req quantity by {itemToGive} for one item request.");
                }
                else
                {
                    if (index == 0)
                    {
                        item1QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Payless Xtrabig quantity. New quantity: {quantity}");
                    }
                    else
                    {
                        item2QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Payless Xtrabig quantity. New quantity: {quantity}");
                    }
                }
            }

            if (quantity == 0)
            {
                if (manyItems == 1)
                {
                    Debug.Log("[ORDER] Payless Xtra Big order complete!");
                    oneItemRequest.enabled = false;
                }
                else
                {
                    if (index == 0)
                    {
                        item1.SetActive(false);
                        item1QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Payless Xtrabig quantity. New quantity: {quantity}");
                    }
                    else if (index == 1)
                    {
                        item2.SetActive(false);
                        item2QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Payless Xtrabig quantity. New quantity: {quantity}");
                    }
                }
            }
        }
        else if (itemName == "Lucky Me")
        {
            //get current position of Lucky Me in itemName/itemQuantities list
            int index = this.itemName.IndexOf(itemName);
            int quantity = itemQuantities[index];
            if (quantity > 0)
            {
                quantity -= itemToGive;
                itemQuantities[index] = quantity;
                if (manyItems == 1)
                {
                    oneItemRequest.text = $"{quantity}";
                    Debug.Log($"[ORDER] Decreasing the One Item Req quantity by {itemToGive} for one item request.");
                }
                else
                {
                    if (index == 0)
                    {
                        item1QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Lucky Me quantity. New quantity: {quantity}");
                    }
                    else
                    {
                        item2QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Lucky Me quantity. New quantity: {quantity}");
                    }
                }
            }

            if (quantity == 0)
            {
                if (manyItems == 1)
                {
                    Debug.Log("[ORDER] Lucky Me order complete!");
                    oneItemRequest.enabled = false;
                }
                else
                {
                    if (index == 0)
                    {
                        item1.SetActive(false);
                        item1QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Lucky Me quantity. New quantity: {quantity}");
                    }
                    else if (index == 1)
                    {
                        item2.SetActive(false);
                        item2QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Lucky Me quantity. New quantity: {quantity}");
                    }
                }
            }
        }
        else if (itemName == "Cup Noodle")
        {
            //get current position of Cup Noodle in itemName/itemQuantities list
            int index = this.itemName.IndexOf(itemName);
            int quantity = itemQuantities[index];

            if (quantity > 0)
            {
                quantity -= itemToGive;
                itemQuantities[index] = quantity;

                if (manyItems == 1)
                {
                    oneItemRequest.text = $"{quantity}";
                    Debug.Log($"[ORDER] Decreasing the One Item Req quantity by {itemToGive} for one item request.");
                }
                else
                {
                    if (index == 0)
                    {
                        item1QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Cup Noodle quantity. New quantity: {quantity}");
                    }
                    else
                    {
                        item2QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Cup Noodle quantity. New quantity: {quantity}");
                    }
                }
            }

            if (quantity == 0)
            {
                if (manyItems == 1)
                {
                    Debug.Log("[ORDER] Cup Noodle order complete!");
                    oneItemRequest.enabled = false;
                }
                else
                {
                    if (index == 0)
                    {
                        item1.SetActive(false);
                        item1QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Cup Noodle quantity. New quantity: {quantity}");
                    }
                    else if (index == 1)
                    {
                        item2.SetActive(false);
                        item2QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Cup Noodle quantity. New quantity: {quantity}");
                    }
                }
            }
        }
        else if (itemName == "Colgate")
        {
            //get current position of Colgate in itemName/itemQuantities list
            int index = this.itemName.IndexOf(itemName);
            int quantity = itemQuantities[index];
            if (quantity > 0)
            {
                quantity -= itemToGive;
                itemQuantities[index] = quantity;
                if (manyItems == 1)
                {
                    oneItemRequest.text = $"{quantity}";
                    Debug.Log($"[ORDER] Decreasing the One Item Req quantity by {itemToGive} for one item request.");
                }
                else
                {
                    if (index == 0)
                    {
                        item1QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Colgate quantity. New quantity: {quantity}");
                    }
                    else
                    {
                        item2QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Colgate quantity. New quantity: {quantity}");
                    }
                }
            }

            if (quantity == 0)
            {
                if (manyItems == 1)
                {
                    Debug.Log("[ORDER] Colgate order complete!");
                    oneItemRequest.enabled = false;
                }
                else
                {
                    if (index == 0)
                    {
                        item1.SetActive(false);
                        item1QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Colgate quantity. New quantity: {quantity}");
                    }
                    else if (index == 1)
                    {
                        item2.SetActive(false);
                        item2QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Colgate quantity. New quantity: {quantity}");
                    }
                }
            }
        }
        else if (itemName == "Rexona")
        {
            //get current position of Rexona in itemName/itemQuantities list
            int index = this.itemName.IndexOf(itemName);
            int quantity = itemQuantities[index];
            if (quantity > 0)
            {
                quantity -= itemToGive;
                itemQuantities[index] = quantity;
                if (manyItems == 1)
                {
                    oneItemRequest.text = $"{quantity}";
                    Debug.Log($"[ORDER] Decreasing the One Item Req quantity by {itemToGive} for one item request.");
                }
                else
                {
                    if (index == 0)
                    {
                        item1QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Rexona quantity. New quantity: {quantity}");
                    }
                    else
                    {
                        item2QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Rexona quantity. New quantity: {quantity}");
                    }
                }
            }

            if (quantity == 0)
            {
                if (manyItems == 1)
                {
                    Debug.Log("[ORDER] Rexona order complete!");
                    oneItemRequest.enabled = false;
                }
                else
                {
                    if (index == 0)
                    {
                        item1.SetActive(false);
                        item1QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Rexona quantity. New quantity: {quantity}");
                    }
                    else if (index == 1)
                    {
                        item2.SetActive(false);
                        item2QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Rexona quantity. New quantity: {quantity}");
                    }
                }
            }
        }
        else if (itemName == "Sunsilk")
        {
            //get current position of Sunsilk in itemName/itemQuantities list
            int index = this.itemName.IndexOf(itemName);
            int quantity = itemQuantities[index];
            if (quantity > 0)
            {
                quantity -= itemToGive;
                itemQuantities[index] = quantity;
                if (manyItems == 1)
                {
                    oneItemRequest.text = $"{quantity}";
                    Debug.Log($"[ORDER] Decreasing the One Item Req quantity by {itemToGive} for one item request.");
                }
                else
                {
                    if (index == 0)
                    {
                        item1QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Sunsilk quantity. New quantity: {quantity}");
                    }
                    else
                    {
                        item2QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Sunsilk quantity. New quantity: {quantity}");
                    }
                }
            }

            if (quantity == 0)
            {
                if (manyItems == 1)
                {
                    Debug.Log("[ORDER] Sunsilk order complete!");
                    oneItemRequest.enabled = false;
                }
                else
                {
                    if (index == 0)
                    {
                        item1.SetActive(false);
                        item1QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Sunsilk quantity. New quantity: {quantity}");
                    }
                    else if (index == 1)
                    {
                        item2.SetActive(false);
                        item2QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Sunsilk quantity. New quantity: {quantity}");
                    }
                }
            }
        }
        else if (itemName == "Chippy")
        {
            //get current position of Chippy in itemName/itemQuantities list
            int index = this.itemName.IndexOf(itemName);
            int quantity = itemQuantities[index];
            if (quantity > 0)
            {
                quantity -= itemToGive;
                itemQuantities[index] = quantity;
                if (manyItems == 1)
                {
                    oneItemRequest.text = $"{quantity}";
                    Debug.Log($"[ORDER] Decreasing the One Item Req quantity by {itemToGive} for one item request.");
                }
                else
                {
                    if (index == 0)
                    {
                        item1QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Chippy quantity. New quantity: {quantity}");
                    }
                    else
                    {
                        item2QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Chippy quantity. New quantity: {quantity}");
                    }
                }
            }
            if (manyItems == 1 && quantity == 0)
            {
                Debug.Log("[ORDER] Chippy order complete!");
                oneItemRequest.enabled = false;
            }
            if (quantity == 0 && manyItems != 1)
            {
                if (index == 0)
                {
                    item1.SetActive(false);
                    item1QuantityText.enabled = false;
                    Debug.Log($"[ORDER] Decreased Chippy quantity. New quantity: {quantity}");
                }
                else if (index == 1)
                {
                    item2.SetActive(false);
                    item2QuantityText.enabled = false;
                    Debug.Log($"[ORDER] Decreased Chippy quantity. New quantity: {quantity}");
                }
            }
        }
        else if (itemName == "Nova")
        {
            //get current position of Nova in itemName/itemQuantities list
            int index = this.itemName.IndexOf(itemName);
            int quantity = itemQuantities[index];
            if (quantity > 0)
            {
                quantity -= itemToGive;
                itemQuantities[index] = quantity;
                if (manyItems == 1)
                {
                    oneItemRequest.text = $"{quantity}";
                    Debug.Log($"[ORDER] Decreasing the One Item Req quantity by {itemToGive} for one item request.");
                }
                else
                {
                    if (index == 0)
                    {
                        item1QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Nova quantity. New quantity: {quantity}");
                    }
                    else
                    {
                        item2QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Nova quantity. New quantity: {quantity}");
                    }
                }
            }
            if (manyItems == 1 && quantity == 0)
            {
                Debug.Log("[ORDER] Nova order complete!");
                oneItemRequest.enabled = false;
            }
            if (quantity == 0 && manyItems != 1)
            {
                if (index == 0)
                {
                    item1.SetActive(false);
                    item1QuantityText.enabled = false;
                    Debug.Log($"[ORDER] Decreased Nova quantity. New quantity: {quantity}");
                }
                else if (index == 1)
                {
                    item2.SetActive(false);
                    item2QuantityText.enabled = false;
                    Debug.Log($"[ORDER] Decreased Nova quantity. New quantity: {quantity}");
                }
            }
        }
        else if (itemName == "Piattos")
        {
            //get current position of Piattos in itemName/itemQuantities list
            int index = this.itemName.IndexOf(itemName);
            int quantity = itemQuantities[index];
            if (quantity > 0)
            {
                quantity -= itemToGive;
                itemQuantities[index] = quantity;
                if (manyItems == 1)
                {
                    oneItemRequest.text = $"{quantity}";
                    Debug.Log($"[ORDER] Decreasing the One Item Req quantity by {itemToGive} for one item request.");
                }
                else
                {
                    if (index == 0)
                    {
                        item1QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Piattos quantity. New quantity: {quantity}");
                    }
                    else
                    {
                        item2QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Piattos quantity. New quantity: {quantity}");
                    }
                }
            }
            if (manyItems == 1 && quantity == 0)
            {
                Debug.Log("[ORDER] Piattos order complete!");
                oneItemRequest.enabled = false;
            }

            if (quantity == 0 && manyItems != 1)
            {
                if (index == 0)
                {
                    item1.SetActive(false);
                    item1QuantityText.enabled = false;
                    Debug.Log($"[ORDER] Decreased Piattos quantity. New quantity: {quantity}");
                }
                else if (index == 1)
                {
                    item2.SetActive(false);
                    item2QuantityText.enabled = false;
                    Debug.Log($"[ORDER] Decreased Piattos quantity. New quantity: {quantity}");
                }
            }

        }
        else if (itemName == "Coke")
        {             //get current position of Coke in itemName/itemQuantities list
            int index = this.itemName.IndexOf(itemName);
            int quantity = itemQuantities[index];
            if (quantity > 0)
            {
                quantity -= itemToGive;
                itemQuantities[index] = quantity;
                if (manyItems == 1)
                {
                    oneItemRequest.text = $"{quantity}";
                    Debug.Log($"[ORDER] Decreasing the One Item Req quantity by {itemToGive} for one item request.");
                }
                else
                {
                    if (index == 0)
                    {
                        item1QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Coke quantity. New quantity: {quantity}");
                    }
                    else
                    {
                        item2QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Coke quantity. New quantity: {quantity}");
                    }
                }
            }

            if (quantity == 0)
            {
                if (manyItems == 1)
                {
                    Debug.Log("[ORDER] Coke order complete!");
                    oneItemRequest.enabled = false;
                }
                else
                {
                    if (index == 0)
                    {
                        item1.SetActive(false);
                        item1QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Coke quantity. New quantity: {quantity}");
                    }
                    else if (index == 1)
                    {
                        item2.SetActive(false);
                        item2QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Coke quantity. New quantity: {quantity}");
                    }
                }
            }
        }
        else if (itemName == "Pepsi")
        {
            //get current position of Pepsi in itemName/itemQuantities list
            int index = this.itemName.IndexOf(itemName);
            int quantity = itemQuantities[index];
            if (quantity > 0)
            {
                quantity -= itemToGive;
                itemQuantities[index] = quantity;
                if (manyItems == 1)
                {
                    oneItemRequest.text = $"{quantity}";
                    Debug.Log($"[ORDER] Decreasing the One Item Req quantity by {itemToGive} for one item request.");
                }
                else
                {
                    if (index == 0)
                    {
                        item1QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Pepsi quantity. New quantity: {quantity}");
                    }
                    else
                    {
                        item2QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Pepsi quantity. New quantity: {quantity}");
                    }
                }
            }

            if (quantity == 0)
            {
                if (manyItems == 1)
                {
                    Debug.Log("[ORDER] Pepsi order complete!");
                    oneItemRequest.enabled = false;
                }
                else
                {
                    if (index == 0)
                    {
                        item1.SetActive(false);
                        item1QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Pepsi quantity. New quantity: {quantity}");
                    }
                    else if (index == 1)
                    {
                        item2.SetActive(false);
                        item2QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Pepsi quantity. New quantity: {quantity}");
                    }
                }
            }
        }
        else if (itemName == "Royal")
        {
            //get current position of Royal in itemName/itemQuantities list
            int index = this.itemName.IndexOf(itemName);
            int quantity = itemQuantities[index];
            if (quantity > 0)
            {
                quantity -= itemToGive;
                itemQuantities[index] = quantity;
                if (manyItems == 1)
                {
                    oneItemRequest.text = $"{quantity}";
                    Debug.Log($"[ORDER] Decreasing the One Item Req quantity by {itemToGive} for one item request.");
                }
                else
                {
                    if (index == 0)
                    {
                        item1QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Royal quantity. New quantity: {quantity}");
                    }
                    else
                    {
                        item2QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Royal quantity. New quantity: {quantity}");
                    }
                }
            }

            if (quantity == 0)
            {
                if (manyItems == 1)
                {
                    Debug.Log("[ORDER] Royal order complete!");
                    oneItemRequest.enabled = false;
                }
                else
                {
                    if (index == 0)
                    {
                        item1.SetActive(false);
                        item1QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Royal quantity. New quantity: {quantity}");
                    }
                    else if (index == 1)
                    {
                        item2.SetActive(false);
                        item2QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Royal quantity. New quantity: {quantity}");
                    }
                }
            }
        }
        else if (itemName == "Zesto Apple")
        {
            //get current position of Zesto Apple in itemName/itemQuantities list
            int index = this.itemName.IndexOf(itemName);
            int quantity = itemQuantities[index];
            if (quantity > 0)
            {
                quantity -= itemToGive;
                itemQuantities[index] = quantity;
                if (manyItems == 1)
                {
                    oneItemRequest.text = $"{quantity}";
                    Debug.Log($"[ORDER] Decreasing the One Item Req quantity by {itemToGive} for one item request.");
                }
                else
                {
                    if (index == 0)
                    {
                        item1QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Zesto Apple quantity. New quantity: {quantity}");
                    }
                    else
                    {
                        item2QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Zesto Apple quantity. New quantity: {quantity}");
                    }
                }
            }
            if (quantity == 0)
            {
                if (manyItems == 1)
                {
                    Debug.Log("[ORDER] Zesto Apple order complete!");
                    oneItemRequest.enabled = false;
                }
                else
                {
                    if (index == 0)
                    {
                        item1.SetActive(false);
                        item1QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Zesto Apple quantity. New quantity: {quantity}");
                    }
                    else if (index == 1)
                    {
                        item2.SetActive(false);
                        item2QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Zesto Apple quantity. New quantity: {quantity}");
                    }
                }
            }
        }
        else if (itemName == "Zesto Grape")
        {
            //get current position of Zesto Grape in itemName/itemQuantities list
            int index = this.itemName.IndexOf(itemName);
            int quantity = itemQuantities[index];
            if (quantity > 0)
            {
                quantity -= itemToGive;
                itemQuantities[index] = quantity;
                if (manyItems == 1)
                {
                    oneItemRequest.text = $"{quantity}";
                    Debug.Log($"[ORDER] Decreasing the One Item Req quantity by {itemToGive} for one item request.");
                }
                else
                {
                    if (index == 0)
                    {
                        item1QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Zesto Grape quantity. New quantity: {quantity}");
                    }
                    else
                    {
                        item2QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Zesto Grape quantity. New quantity: {quantity}");
                    }
                }
            }
            if (quantity == 0)
            {
                if (manyItems == 1)
                {
                    Debug.Log("[ORDER] Zesto Grape order complete!");
                    oneItemRequest.enabled = false;
                }
                else
                {
                    if (index == 0)
                    {
                        item1.SetActive(false);
                        item1QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Zesto Grape quantity. New quantity: {quantity}");
                    }
                    else if (index == 1)
                    {
                        item2.SetActive(false);
                        item2QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Zesto Grape quantity. New quantity: {quantity}");
                    }
                }
            }
        }
        else if (itemName == "Zesto Orange")
        {
            //get current position of Zesto Orange in itemName/itemQuantities list
            int index = this.itemName.IndexOf(itemName);
            int quantity = itemQuantities[index];
            if (quantity > 0)
            {
                quantity -= itemToGive;
                itemQuantities[index] = quantity;
                if (manyItems == 1)
                {
                    oneItemRequest.text = $"{quantity}";
                    Debug.Log($"[ORDER] Decreasing the One Item Req quantity by {itemToGive} for one item request.");
                }
                else
                {
                    if (index == 0)
                    {
                        item1QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Zesto Orange quantity. New quantity: {quantity}");
                    }
                    else
                    {
                        item2QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Zesto Orange quantity. New quantity: {quantity}");
                    }
                }
            }
            if (quantity == 0)
            {
                if (manyItems == 1)
                {
                    Debug.Log("[ORDER] Zesto Orange order complete!");
                    oneItemRequest.enabled = false;
                }
                else
                {
                    if (index == 0)
                    {
                        item1.SetActive(false);
                        item1QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Zesto Orange quantity. New quantity: {quantity}");
                    }
                    else if (index == 1)
                    {
                        item2.SetActive(false);
                        item2QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Zesto Orange quantity. New quantity: {quantity}");
                    }
                }
            }
        }
        else if (itemName == "Adobo")
        {
            //get current position of Adobo in itemName/itemQuantities list
            int index = this.itemName.IndexOf(itemName);
            int quantity = itemQuantities[index];
            if (quantity > 0)
            {
                quantity -= itemToGive;
                itemQuantities[index] = quantity;
                if (manyItems == 1)
                {
                    oneItemRequest.text = $"{quantity}";
                    Debug.Log($"[ORDER] Decreasing the One Item Req quantity by {itemToGive} for one item request.");
                }
                else
                {
                    if (index == 0)
                    {
                        item1QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Adobo quantity. New quantity: {quantity}");
                    }
                    else
                    {
                        item2QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Adobo quantity. New quantity: {quantity}");
                    }
                }
            }

            if (quantity == 0)
            {
                if (manyItems == 1)
                {
                    Debug.Log("[ORDER] Adobo order complete!");
                    oneItemRequest.enabled = false;
                }
                else
                {
                    if (index == 0)
                    {
                        item1.SetActive(false);
                        item1QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Adobo quantity. New quantity: {quantity}");
                    }
                    else if (index == 1)
                    {
                        item2.SetActive(false);
                        item2QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Adobo quantity. New quantity: {quantity}");
                    }
                }
            }
        }
        else if (itemName == "Afritada")
        {
            //get current position of Afritada in itemName/itemQuantities list
            int index = this.itemName.IndexOf(itemName);
            int quantity = itemQuantities[index];
            if (quantity > 0)
            {
                quantity -= itemToGive;
                itemQuantities[index] = quantity;
                if (manyItems == 1)
                {
                    oneItemRequest.text = $"{quantity}";
                    Debug.Log($"[ORDER] Decreasing the One Item Req quantity by {itemToGive} for one item request.");
                }
                else
                {
                    if (index == 0)
                    {
                        item1QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Afritada quantity. New quantity: {quantity}");
                    }
                    else
                    {
                        item2QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Afritada quantity. New quantity: {quantity}");
                    }
                }
            }

            if (quantity == 0)
            {
                if (manyItems == 1)
                {
                    Debug.Log("[ORDER] Afritada order complete!");
                    oneItemRequest.enabled = false;
                }
                else
                {
                    if (index == 0)
                    {
                        item1.SetActive(false);
                        item1QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Afritada quantity. New quantity: {quantity}");
                    }
                    else if (index == 1)
                    {
                        item2.SetActive(false);
                        item2QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Afritada quantity. New quantity: {quantity}");
                    }
                }
            }
        }
        else if (itemName == "Flakes in Oil")
        {
            //get current position of Flakes in Oil in itemName/itemQuantities list
            int index = this.itemName.IndexOf(itemName);
            int quantity = itemQuantities[index];
            if (quantity > 0)
            {
                quantity -= itemToGive;
                itemQuantities[index] = quantity;
                if (manyItems == 1)
                {
                    oneItemRequest.text = $"{quantity}";
                    Debug.Log($"[ORDER] Decreasing the One Item Req quantity by {itemToGive} for one item request.");
                }
                else
                {
                    if (index == 0)
                    {
                        item1QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Flakes in Oil quantity. New quantity: {quantity}");
                    }
                    else
                    {
                        item2QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Flakes in Oil quantity. New quantity: {quantity}");
                    }
                }
            }

            if (quantity == 0)
            {
                if (manyItems == 1)
                {
                    Debug.Log("[ORDER] Flakes in Oil order complete!");
                    oneItemRequest.enabled = false;
                }
                else
                {
                    if (index == 0)
                    {
                        item1.SetActive(false);
                        item1QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Flakes in Oil quantity. New quantity: {quantity}");
                    }
                    else if (index == 1)
                    {
                        item2.SetActive(false);
                        item2QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Flakes in Oil quantity. New quantity: {quantity}");
                    }
                }
            }
        }
        else if (itemName == "Cheese Spread")
        {
            //get current position of Cheese Spread in itemName/itemQuantities list
            int index = this.itemName.IndexOf(itemName);
            int quantity = itemQuantities[index];
            if (quantity > 0)
            {
                quantity -= itemToGive;
                itemQuantities[index] = quantity;
                if (manyItems == 1)
                {
                    oneItemRequest.text = $"{quantity}";
                    Debug.Log($"[ORDER] Decreasing the One Item Req quantity by {itemToGive} for one item request.");
                }
                else
                {
                    if (index == 0)
                    {
                        item1QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Cheese Spread quantity. New quantity: {quantity}");
                    }
                    else
                    {
                        item2QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Cheese Spread quantity. New quantity: {quantity}");
                    }
                }
            }

            if (quantity == 0)
            {
                if (manyItems == 1)
                {
                    Debug.Log("[ORDER] Cheese Spread order complete!");
                    oneItemRequest.enabled = false;
                }
                else
                {
                    if (index == 0)
                    {
                        item1.SetActive(false);
                        item1QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Cheese Spread quantity. New quantity: {quantity}");
                    }
                    else if (index == 1)
                    {
                        item2.SetActive(false);
                        item2QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Cheese Spread quantity. New quantity: {quantity}");
                    }
                }
            }
        }
        else if (itemName == "Nescafe")
        {
            //get current position of Nescafe in itemName/itemQuantities list
            int index = this.itemName.IndexOf(itemName);
            int quantity = itemQuantities[index];
            if (quantity > 0)
            {
                quantity -= itemToGive;
                itemQuantities[index] = quantity;
                if (manyItems == 1)
                {
                    oneItemRequest.text = $"{quantity}";
                    Debug.Log($"[ORDER] Decreasing the One Item Req quantity by {itemToGive} for one item request.");
                }
                else
                {
                    if (index == 0)
                    {
                        item1QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Nescafe quantity. New quantity: {quantity}");
                    }
                    else
                    {
                        item2QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Nescafe quantity. New quantity: {quantity}");
                    }
                }
            }

            if (quantity == 0)
            {
                if (manyItems == 1)
                {
                    Debug.Log("[ORDER] Nescafe order complete!");
                    oneItemRequest.enabled = false;
                }
                else
                {
                    if (index == 0)
                    {
                        item1.SetActive(false);
                        item1QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Nescafe quantity. New quantity: {quantity}");
                    }
                    else if (index == 1)
                    {
                        item2.SetActive(false);
                        item2QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Nescafe quantity. New quantity: {quantity}");
                    }
                }
            }
        }
        else if (itemName == "Peanut Butter")
        {
            //get current position of Peanut Butter in itemName/itemQuantities list
            int index = this.itemName.IndexOf(itemName);
            int quantity = itemQuantities[index];
            if (quantity > 0)
            {
                quantity -= itemToGive;
                itemQuantities[index] = quantity;
                if (manyItems == 1)
                {
                    oneItemRequest.text = $"{quantity}";
                    Debug.Log($"[ORDER] Decreasing the One Item Req quantity by {itemToGive} for one item request.");
                }
                else
                {
                    if (index == 0)
                    {
                        item1QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Peanut Butter quantity. New quantity: {quantity}");
                    }
                    else
                    {
                        item2QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Peanut Butter quantity. New quantity: {quantity}");
                    }
                }
            }
            if (quantity == 0)
            {
                if (manyItems == 1)
                {
                    Debug.Log("[ORDER] Peanut Butter order complete!");
                    oneItemRequest.enabled = false;
                }
                else
                {
                    if (index == 0)
                    {
                        item1.SetActive(false);
                        item1QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Peanut Butter quantity. New quantity: {quantity}");
                    }
                    else if (index == 1)
                    {
                        item2.SetActive(false);
                        item2QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Peanut Butter quantity. New quantity: {quantity}");
                    }
                }
            }
        }
        else if (itemName == "Artisan")
        {
            //get current position of Artisan in itemName/itemQuantities list
            int index = this.itemName.IndexOf(itemName);
            int quantity = itemQuantities[index];
            if (quantity > 0)
            {
                quantity -= itemToGive;
                itemQuantities[index] = quantity;
                if (manyItems == 1)
                {
                    oneItemRequest.text = $"{quantity}";
                    Debug.Log($"[ORDER] Decreasing the One Item Req quantity by {itemToGive} for one item request.");
                }
                else
                {
                    if (index == 0)
                    {
                        item1QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Artisan quantity. New quantity: {quantity}");
                    }
                    else
                    {
                        item2QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Artisan quantity. New quantity: {quantity}");
                    }
                }
            }
            if (quantity == 0)
            {
                if (manyItems == 1)
                {
                    Debug.Log("[ORDER] Artisan order complete!");
                    oneItemRequest.enabled = false;
                }
                else
                {
                    if (index == 0)
                    {
                        item1.SetActive(false);
                        item1QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Artisan quantity. New quantity: {quantity}");
                    }
                    else if (index == 1)
                    {
                        item2.SetActive(false);
                        item2QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Artisan quantity. New quantity: {quantity}");
                    }
                }
            }
        }
        else if (itemName == "Gardenia")
        {
            //get current position of Gardenia in itemName/itemQuantities list
            int index = this.itemName.IndexOf(itemName);
            int quantity = itemQuantities[index];
            if (quantity > 0)
            {
                quantity -= itemToGive;
                itemQuantities[index] = quantity;
                if (manyItems == 1)
                {
                    oneItemRequest.text = $"{quantity}";
                    Debug.Log($"[ORDER] Decreasing the One Item Req quantity by {itemToGive} for one item request.");
                }
                else
                {
                    if (index == 0)
                    {
                        item1QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Gardenia quantity. New quantity: {quantity}");
                    }
                    else
                    {
                        item2QuantityText.text = $"{quantity}";
                        Debug.Log($"[ORDER] Decreased Gardenia quantity. New quantity: {quantity}");
                    }
                }
            }
            if (quantity == 0)
            {
                if (manyItems == 1)
                {
                    Debug.Log("[ORDER] Gardenia order complete!");
                    oneItemRequest.enabled = false;
                }
                else
                {
                    if (index == 0)
                    {
                        item1.SetActive(false);
                        item1QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Gardenia quantity. New quantity: {quantity}");
                    }
                    else if (index == 1)
                    {
                        item2.SetActive(false);
                        item2QuantityText.enabled = false;
                        Debug.Log($"[ORDER] Decreased Gardenia quantity. New quantity: {quantity}");
                    }
                }
            }
        }

        if (itemQuantities.TrueForAll(q => q == 0))
        {
            payingCustomer.PayForTotalAmount();
            requestItem.SetActive(false);

            item1.SetActive(false);
            item2.SetActive(false);

            disableUI.DisableWhileCalcu();
        }

        UpdateListFromDragDropClick();

    }

    private void UpdateListFromDragDropClick()
    {
        dragDropClick.setItemsRequest(itemName);
        dragDropClick.setQuantitiesRequest(itemQuantities);

        List<string> items = dragDropClick.getItemsRequest();
        List<int> quantities = dragDropClick.getQuantitiesRequest();

        for (int i = 0; i < items.Count; i++)
        {
            Debug.Log($"[ORDER] Updated List from DragDropClick - Item {i + 1}: {items[i]}, Quantity: {quantities[i]}");
        }
    }

    public void DisableOrderText()
    {
        oneItemRequest.enabled = false;
        item1QuantityText.enabled = false;
        item2QuantityText.enabled = false;
    }
    public void ClearItemsList()
    {
        itemName.Clear();
        itemQuantities.Clear();
    }
    public List<string> getItemsRequest() { return itemName; }
    public List<int> getQuantitiesRequest() { return itemQuantities; }
}

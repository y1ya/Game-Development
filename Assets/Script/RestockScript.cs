using UnityEngine;
using UnityEngine.UI;

public class RestockScript : MonoBehaviour
{
    public MinMaxItemsDisplay minMaxItemsDisplay;
    public ItemsLeft itemsLeft;

    public GameObject restockGoyaCandy, restockMentos, restockWhiteRabbit;
    public GameObject restockRice, restockSoySauce, restockVinegar;
    public GameObject restockPaylessXtraBig, restockLuckyMe, restockCupNoodle;
    public GameObject restockColgate, restockRexona, restockSunsilk;
    public GameObject restockChippy, restockNova, restockPiattos;
    public GameObject restockSurf, restockJoy;
    public GameObject restockCoke, restockPepsi, restockRoyal, restockZestoApple, restockZestoGrape, restockZestoOrange;

    public void RestockButton(GameObject buttonChild)
    {
        Transform parentTransform = buttonChild.transform.parent;
        Debug.Log("[RESTOCK] Restock button clicked. Parent transform: " + parentTransform.name);

        int inventoryLeft, leftItems, maxItems;
        if (parentTransform.name.ToString().Equals("Goya Candy"))
        {
            Debug.Log("[RESTOCK] Restocking Goya items.");

            inventoryLeft = minMaxItemsDisplay.GetInventoryItems("Goya Candy");
            Debug.Log("[RESTOCK] Current Goya Candy inventory: " + inventoryLeft);

            leftItems = itemsLeft.GetGoyaCandyLeft();

            maxItems = minMaxItemsDisplay.maxItemsCandies;

            RestockItems("Goya Candy", inventoryLeft, leftItems, maxItems, parentTransform);

            itemsLeft.goyaCandyLeftText.color = Color.white;
        }
        else if (parentTransform.name.ToString().Equals("Mentos"))
        {
            Debug.Log("[RESTOCK] Restocking Mentos items.");

            inventoryLeft = minMaxItemsDisplay.GetInventoryItems("Mentos");
            Debug.Log("[RESTOCK] Current Mentos inventory: " + inventoryLeft);

            leftItems = itemsLeft.GetMentosLeft();

            maxItems = minMaxItemsDisplay.maxItemsCandies;

            RestockItems("Mentos", inventoryLeft, leftItems, maxItems, parentTransform);

            itemsLeft.mentosLeftText.color = Color.white;
        }
        else if (parentTransform.name.ToString().Equals("White Rabbit"))
        {
            Debug.Log("[RESTOCK] Restocking White Rabbit items.");

            inventoryLeft = minMaxItemsDisplay.GetInventoryItems("White Rabbit");
            Debug.Log("[RESTOCK] Current White Rabbit inventory: " + inventoryLeft);

            leftItems = itemsLeft.GetWhiteRabbitLeft();

            maxItems = minMaxItemsDisplay.maxItemsCandies;

            RestockItems("White Rabbit", inventoryLeft, leftItems, maxItems, parentTransform);

            itemsLeft.whiteRabbitLeftText.color = Color.white;
        }
        else if (parentTransform.name.ToString().Equals("Rice"))
        {
            Debug.Log("[RESTOCK] Restocking Rice items.");

            inventoryLeft = minMaxItemsDisplay.GetInventoryItems("Rice");
            Debug.Log("[RESTOCK] Current Rice inventory: " + inventoryLeft);

            leftItems = itemsLeft.GetRiceLeft();

            maxItems = minMaxItemsDisplay.maxItemsPantryStaples;

            RestockItems("Rice", inventoryLeft, leftItems, maxItems, parentTransform);

            itemsLeft.riceLeftText.color = Color.white;
        }
        else if (parentTransform.name.ToString().Equals("Soy Sauce"))
        {
            Debug.Log("[RESTOCK] Restocking Soy Sauce items.");

            inventoryLeft = minMaxItemsDisplay.GetInventoryItems("Soy Sauce");
            Debug.Log("[RESTOCK] Current Soy Sauce inventory: " + inventoryLeft);

            leftItems = itemsLeft.GetSoySauceLeft();

            maxItems = minMaxItemsDisplay.maxItemsPantryStaples;

            RestockItems("Soy Sauce", inventoryLeft, leftItems, maxItems, parentTransform);

            itemsLeft.soySauceLeftText.color = Color.white;
        }
        else if (parentTransform.name.ToString().Equals("Vinegar"))
        {
            Debug.Log("[RESTOCK] Restocking Vinegar items.");

            inventoryLeft = minMaxItemsDisplay.GetInventoryItems("Vinegar");
            Debug.Log("[RESTOCK] Current Vinegar inventory: " + inventoryLeft);

            leftItems = itemsLeft.GetVinegarLeft();

            maxItems = minMaxItemsDisplay.maxItemsPantryStaples;

            RestockItems("Vinegar", inventoryLeft, leftItems, maxItems, parentTransform);

            itemsLeft.vinegarLeftText.color = Color.white;
        }
        else if (parentTransform.name.ToString().Equals("Payless Xtra Big"))
        {
            Debug.Log("[RESTOCK] Restocking Payless Xtra Big items.");

            inventoryLeft = minMaxItemsDisplay.GetInventoryItems("Payless Xtra Big");
            Debug.Log("[RESTOCK] Current Payless Xtra Big inventory: " + inventoryLeft);

            leftItems = itemsLeft.GetPaylessXtraBigLeft();

            maxItems = minMaxItemsDisplay.maxItemsInstantNoodles;

            RestockItems("Payless Xtra Big", inventoryLeft, leftItems, maxItems, parentTransform);

            itemsLeft.paylessXtraBigLeftText.color = Color.white;
        }
        else if (parentTransform.name.ToString().Equals("Lucky Me"))
        {
            Debug.Log("[RESTOCK] Restocking Lucky Me items.");

            inventoryLeft = minMaxItemsDisplay.GetInventoryItems("Lucky Me");
            Debug.Log("[RESTOCK] Current Lucky Me inventory: " + inventoryLeft);

            leftItems = itemsLeft.GetLuckyMeLeft();

            maxItems = minMaxItemsDisplay.maxItemsInstantNoodles;

            RestockItems("Lucky Me", inventoryLeft, leftItems, maxItems, parentTransform);

            itemsLeft.luckyMeLeftText.color = Color.white;
        }
        else if (parentTransform.name.ToString().Equals("Cup Noodle"))
        {
            Debug.Log("[RESTOCK] Restocking Cup Noodle items.");

            inventoryLeft = minMaxItemsDisplay.GetInventoryItems("Cup Noodle");
            Debug.Log("[RESTOCK] Current Cup Noodle inventory: " + inventoryLeft);

            leftItems = itemsLeft.GetCupNoodleLeft();

            maxItems = minMaxItemsDisplay.maxItemsInstantNoodles;

            RestockItems("Cup Noodle", inventoryLeft, leftItems, maxItems, parentTransform);

            itemsLeft.cupNoodleLeftText.color = Color.white;
        }
        else if (parentTransform.name.ToString().Equals("Colgate"))
        {
            Debug.Log("[RESTOCK] Restocking Colgate items.");

            inventoryLeft = minMaxItemsDisplay.GetInventoryItems("Colgate");
            Debug.Log("[RESTOCK] Current Colgate inventory: " + inventoryLeft);

            leftItems = itemsLeft.GetColgateLeft();

            maxItems = minMaxItemsDisplay.maxItemsPersonalCare;

            RestockItems("Colgate", inventoryLeft, leftItems, maxItems, parentTransform);

            itemsLeft.colgateLeftText.color = Color.white;
        }
        else if (parentTransform.name.ToString().Equals("Rexona"))
        {
            Debug.Log("[RESTOCK] Restocking Rexona items.");

            inventoryLeft = minMaxItemsDisplay.GetInventoryItems("Rexona");
            Debug.Log("[RESTOCK] Current Rexona inventory: " + inventoryLeft);

            leftItems = itemsLeft.GetRexonaLeft();

            maxItems = minMaxItemsDisplay.maxItemsPersonalCare;

            RestockItems("Rexona", inventoryLeft, leftItems, maxItems, parentTransform);

            itemsLeft.rexonaLeftText.color = Color.white;
        }
        else if (parentTransform.name.ToString().Equals("Sunsilk"))
        {
            Debug.Log("[RESTOCK] Restocking Sunsilk items.");
            
            inventoryLeft = minMaxItemsDisplay.GetInventoryItems("Sunsilk");
            Debug.Log("[RESTOCK] Current Sunsilk inventory: " + inventoryLeft);
            
            leftItems = itemsLeft.GetSunsilkLeft();
            
            maxItems = minMaxItemsDisplay.maxItemsPersonalCare;
            
            RestockItems("Sunsilk", inventoryLeft, leftItems, maxItems, parentTransform);
            
            itemsLeft.sunsilkLeftText.color = Color.white;
        }
        else if (parentTransform.name.ToString().Equals("Chippy"))
        {
            Debug.Log("[RESTOCK] Restocking Chippy items.");
            
            inventoryLeft = minMaxItemsDisplay.GetInventoryItems("Chippy");
            Debug.Log("[RESTOCK] Current Chippy inventory: " + inventoryLeft);
            
            leftItems = itemsLeft.GetChippyLeft();
            
            maxItems = minMaxItemsDisplay.maxItemsSnacks;
            
            RestockItems("Chippy", inventoryLeft, leftItems, maxItems, parentTransform);
            
            itemsLeft.chippyLeftText.color = Color.white;
        }
        else if (parentTransform.name.ToString().Equals("Nova"))
        {
            Debug.Log("[RESTOCK] Restocking Nova items.");
            
            inventoryLeft = minMaxItemsDisplay.GetInventoryItems("Nova");
            Debug.Log("[RESTOCK] Current Nova inventory: " + inventoryLeft);
            
            leftItems = itemsLeft.GetNovaLeft();
            
            maxItems = minMaxItemsDisplay.maxItemsSnacks;
            
            RestockItems("Nova", inventoryLeft, leftItems, maxItems, parentTransform);
            
            itemsLeft.novaLeftText.color = Color.white;
        }
        else if (parentTransform.name.ToString().Equals("Piattos"))
        {
            Debug.Log("[RESTOCK] Restocking Piattos items.");
            
            inventoryLeft = minMaxItemsDisplay.GetInventoryItems("Piattos");
            Debug.Log("[RESTOCK] Current Piattos inventory: " + inventoryLeft);
            
            leftItems = itemsLeft.GetPiattosLeft();
            
            maxItems = minMaxItemsDisplay.maxItemsSnacks;
            
            RestockItems("Piattos", inventoryLeft, leftItems, maxItems, parentTransform);
            
            itemsLeft.piattosLeftText.color = Color.white;
        }
        else if (parentTransform.name.ToString().Equals("Surf"))
        {
            Debug.Log("[RESTOCK] Restocking Surf items.");
            
            inventoryLeft = minMaxItemsDisplay.GetInventoryItems("Surf");
            Debug.Log("[RESTOCK] Current Surf inventory: " + inventoryLeft);
            
            leftItems = itemsLeft.GetSurfLeft();
            
            maxItems = minMaxItemsDisplay.maxItemsPantryStaples;
            
            RestockItems("Surf", inventoryLeft, leftItems, maxItems, parentTransform);
            
            itemsLeft.surfLeftText.color = Color.white;
        }
        else if (parentTransform.name.ToString().Equals("Joy"))
        {
            Debug.Log("[RESTOCK] Restocking Joy items.");
            
            inventoryLeft = minMaxItemsDisplay.GetInventoryItems("Joy");
            Debug.Log("[RESTOCK] Current Joy inventory: " + inventoryLeft);
            
            leftItems = itemsLeft.GetJoyLeft();
            
            maxItems = minMaxItemsDisplay.maxItemsPantryStaples;
            
            RestockItems("Joy", inventoryLeft, leftItems, maxItems, parentTransform);
            
            itemsLeft.joyLeftText.color = Color.white;
        }
        else if (parentTransform.name.ToString().Equals("Coke"))
        {
            Debug.Log("[RESTOCK] Restocking Coke items.");
            
            inventoryLeft = minMaxItemsDisplay.GetInventoryItems("Coke");
            Debug.Log("[RESTOCK] Current Coke inventory: " + inventoryLeft);
            
            leftItems = itemsLeft.GetCokeLeft();
            
            maxItems = minMaxItemsDisplay.maxItemsDrinks;
            
            RestockItems("Coke", inventoryLeft, leftItems, maxItems, parentTransform);
            
            itemsLeft.cokeLeftText.color = Color.white;
        }
        else if (parentTransform.name.ToString().Equals("Pepsi"))
        {
            Debug.Log("[RESTOCK] Restocking Pepsi items.");
            
            inventoryLeft = minMaxItemsDisplay.GetInventoryItems("Pepsi");
            Debug.Log("[RESTOCK] Current Pepsi inventory: " + inventoryLeft);
            
            leftItems = itemsLeft.GetPepsiLeft();
            
            maxItems = minMaxItemsDisplay.maxItemsDrinks;
            
            RestockItems("Pepsi", inventoryLeft, leftItems, maxItems, parentTransform);
            
            itemsLeft.pepsiLeftText.color = Color.white;
        }
        else if (parentTransform.name.ToString().Equals("Royal"))
        {
            Debug.Log("[RESTOCK] Restocking Royal items.");
            
            inventoryLeft = minMaxItemsDisplay.GetInventoryItems("Royal");
            Debug.Log("[RESTOCK] Current Royal inventory: " + inventoryLeft);
            
            leftItems = itemsLeft.GetRoyalLeft();
            
            maxItems = minMaxItemsDisplay.maxItemsDrinks;
            
            RestockItems("Royal", inventoryLeft, leftItems, maxItems, parentTransform);
            
            itemsLeft.royalLeftText.color = Color.white;
        }
        else if (parentTransform.name.ToString().Equals("Zesto Apple"))
        {
            Debug.Log("[RESTOCK] Restocking Zesto Apple items.");
            
            inventoryLeft = minMaxItemsDisplay.GetInventoryItems("Zesto Apple");
            Debug.Log("[RESTOCK] Current Zesto Apple inventory: " + inventoryLeft);
            
            leftItems = itemsLeft.GetZestoAppleLeft();
            
            maxItems = minMaxItemsDisplay.maxItemsDrinks;
            
            RestockItems("Zesto Apple", inventoryLeft, leftItems, maxItems, parentTransform);
            
            itemsLeft.zestoAppleLeftText.color = Color.white;
        }
        else if (parentTransform.name.ToString().Equals("Zesto Grape"))
        {
            Debug.Log("[RESTOCK] Restocking Zesto Grape items.");
            
            inventoryLeft = minMaxItemsDisplay.GetInventoryItems("Zesto Grape");
            Debug.Log("[RESTOCK] Current Zesto Grape inventory: " + inventoryLeft);
            
            leftItems = itemsLeft.GetZestoGrapeLeft();
            
            maxItems = minMaxItemsDisplay.maxItemsDrinks;
            
            RestockItems("Zesto Grape", inventoryLeft, leftItems, maxItems, parentTransform);
            
            itemsLeft.zestoGrapeLeftText.color = Color.white;
        }
        else if (parentTransform.name.ToString().Equals("Zesto Orange"))
        {
            Debug.Log("[RESTOCK] Restocking Zesto Orange items.");
            
            inventoryLeft = minMaxItemsDisplay.GetInventoryItems("Zesto Orange");
            Debug.Log("[RESTOCK] Current Zesto Orange inventory: " + inventoryLeft);
            
            leftItems = itemsLeft.GetZestoOrangeLeft();
            
            maxItems = minMaxItemsDisplay.maxItemsDrinks;
            
            RestockItems("Zesto Orange", inventoryLeft, leftItems, maxItems, parentTransform);
            
            itemsLeft.zestoOrangeLeftText.color = Color.white;
        }
    }

    private void RestockItems(string itemName, int currentInventory, int leftItems, int maxItems, Transform parentButton)
    {
        if (currentInventory > 0)
        {
            int restockAmount = maxItems - leftItems;

            if (restockAmount > 0)
            {
                Debug.Log($"[RESTOCK] Restocking {restockAmount} {itemName} items.");

                itemsLeft.SetItemNameLeft(itemName, maxItems);

                minMaxItemsDisplay.DecreaseInventoryItems("Candies", itemName, restockAmount);

                Debug.Log($"[RESTOCK] Updated Inventory {itemName} item: {minMaxItemsDisplay.GetInventoryItems(itemName)}");
            }
        }

        DisableRestockButton(parentButton);
    }

    public void DisableRestockButton(Transform gameObjectButton)
    { 
        Transform childButton = gameObjectButton.transform.GetChild(0);
        childButton.gameObject.SetActive(false);
    }

    public void EnableRestockButton(string name)
    {
        Transform childButton;

        switch (name)
        {
            case "Goya Candy":
                childButton = restockGoyaCandy.transform.GetChild(0);
                childButton.gameObject.SetActive(true);
                break;
            case "Mentos":
                childButton = restockMentos.transform.GetChild(0);
                childButton.gameObject.SetActive(true);
                break;
            case "White Rabbit":
                childButton = restockWhiteRabbit.transform.GetChild(0);
                childButton.gameObject.SetActive(true);
                break;
            case "Rice":
                childButton = restockRice.transform.GetChild(0);
                childButton.gameObject.SetActive(true);
                break;
            case "Soy Sauce":
                childButton = restockSoySauce.transform.GetChild(0);
                childButton.gameObject.SetActive(true);
                break;
            case "Vinegar":
                childButton = restockVinegar.transform.GetChild(0);
                childButton.gameObject.SetActive(true);
                break;
            case "Payless Xtra Big":
                childButton = restockPaylessXtraBig.transform.GetChild(0);
                childButton.gameObject.SetActive(true);
                break;
            case "Lucky Me":
                childButton = restockLuckyMe.transform.GetChild(0);
                childButton.gameObject.SetActive(true);
                break;
            case "Cup Noodle":
                childButton = restockCupNoodle.transform.GetChild(0);
                childButton.gameObject.SetActive(true);
                break;
            case "Colgate":
                childButton = restockColgate.transform.GetChild(0);
                childButton.gameObject.SetActive(true);
                break;
            case "Rexona":
                childButton = restockRexona.transform.GetChild(0);
                childButton.gameObject.SetActive(true);
                break;
            case "Sunsilk":
                childButton = restockSunsilk.transform.GetChild(0);
                childButton.gameObject.SetActive(true);
                break;
            case "Chippy":
                childButton = restockChippy.transform.GetChild(0);
                childButton.gameObject.SetActive(true);
                break;
            case "Nova":
                childButton = restockNova.transform.GetChild(0);
                childButton.gameObject.SetActive(true);
                break;
            case "Piattos":
                childButton = restockPiattos.transform.GetChild(0);
                childButton.gameObject.SetActive(true);
                break;
            case "Surf":
                childButton = restockSurf.transform.GetChild(0);
                childButton.gameObject.SetActive(true);
                break;
            case "Joy":
                childButton = restockJoy.transform.GetChild(0);
                childButton.gameObject.SetActive(true);
                break;
            case "Coke":
                childButton = restockCoke.transform.GetChild(0);
                childButton.gameObject.SetActive(true);
                break;
            case "Pepsi":
                childButton = restockPepsi.transform.GetChild(0);
                childButton.gameObject.SetActive(true);
                break;
            case "Royal":
                childButton = restockRoyal.transform.GetChild(0);
                childButton.gameObject.SetActive(true);
                break;
            case "Zesto Apple":
                childButton = restockZestoApple.transform.GetChild(0);
                childButton.gameObject.SetActive(true);
                break;
            case "Zesto Grape":
                childButton = restockZestoGrape.transform.GetChild(0);
                childButton.gameObject.SetActive(true);
                break;
            case "Zesto Orange":
                childButton = restockZestoOrange.transform.GetChild(0);
                childButton.gameObject.SetActive(true);
                break;
            default:
                Debug.LogWarning($"[RESTOCK] No matching item found for name: {name}. Restock button not assigned.");
                break;
        }
    }
}

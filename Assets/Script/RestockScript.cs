using UnityEngine;
using UnityEngine.UI;

public class RestockScript : MonoBehaviour
{
    public MinMaxItemsDisplay minMaxItemsDisplay;
    public ItemsLeft itemsLeft;

    public GameObject restockButton;

    public Button restockBtn;

    public void RestockButton()
    {
        Transform parentTransform = restockButton.transform.parent;
        Debug.Log("[RESTOCK] Restock button clicked. Parent transform: " + parentTransform.name);

        int inventoryLeft, leftItems, maxItems;
        if (parentTransform.name.ToString().Equals("Goya Candy"))
        {
            Debug.Log("[RESTOCK] Restocking Goya items.");

            inventoryLeft = minMaxItemsDisplay.GetInventoryItems("Goya Candy");
            Debug.Log("[RESTOCK] Current Goya Candy inventory: " + inventoryLeft);

            leftItems = itemsLeft.GetGoyaCandyLeft();

            maxItems = minMaxItemsDisplay.maxItemsCandies;

            RestockItems("Goya Candy", inventoryLeft, leftItems, maxItems);

            itemsLeft.goyaCandyLeftText.color = Color.white;
        }
        else if (parentTransform.name.ToString().Equals("Mentos"))
        {
            Debug.Log("[RESTOCK] Restocking Mentos items.");

            inventoryLeft = minMaxItemsDisplay.GetInventoryItems("Mentos");
            Debug.Log("[RESTOCK] Current Mentos inventory: " + inventoryLeft);

            leftItems = itemsLeft.GetMentosLeft();

            maxItems = minMaxItemsDisplay.maxItemsCandies;

            RestockItems("Mentos", inventoryLeft, leftItems, maxItems);

            itemsLeft.mentosLeftText.color = Color.white;
        }
        else if (parentTransform.name.ToString().Equals("White Rabbit"))
        {
            Debug.Log("[RESTOCK] Restocking White Rabbit items.");

            inventoryLeft = minMaxItemsDisplay.GetInventoryItems("White Rabbit");
            Debug.Log("[RESTOCK] Current White Rabbit inventory: " + inventoryLeft);

            leftItems = itemsLeft.GetWhiteRabbitLeft();

            maxItems = minMaxItemsDisplay.maxItemsCandies;

            RestockItems("White Rabbit", inventoryLeft, leftItems, maxItems);

            itemsLeft.whiteRabbitLeftText.color = Color.white;
        }
        else if (parentTransform.name.ToString().Equals("Rice"))
        {
            Debug.Log("[RESTOCK] Restocking Rice items.");
            
            inventoryLeft = minMaxItemsDisplay.GetInventoryItems("Rice");
            Debug.Log("[RESTOCK] Current Rice inventory: " + inventoryLeft);
            
            leftItems = itemsLeft.GetRiceLeft();
            
            maxItems = minMaxItemsDisplay.maxItemsPantryStaples;
            
            RestockItems("Rice", inventoryLeft, leftItems, maxItems);

            itemsLeft.riceLeftText.color = Color.white;
        }
        else if (parentTransform.name.ToString().Equals("Soy Sauce"))
        {
            Debug.Log("[RESTOCK] Restocking Soy Sauce items.");
            
            inventoryLeft = minMaxItemsDisplay.GetInventoryItems("Soy Sauce");
            Debug.Log("[RESTOCK] Current Soy Sauce inventory: " + inventoryLeft);
            
            leftItems = itemsLeft.GetSoySauceLeft();
            
            maxItems = minMaxItemsDisplay.maxItemsPantryStaples;
            
            RestockItems("Soy Sauce", inventoryLeft, leftItems, maxItems);

            itemsLeft.soySauceLeftText.color = Color.white;
        }
        else if (parentTransform.name.ToString().Equals("Vinegar"))
        {
            Debug.Log("[RESTOCK] Restocking Vinegar items.");

            inventoryLeft = minMaxItemsDisplay.GetInventoryItems("Vinegar");
            Debug.Log("[RESTOCK] Current Vinegar inventory: " + inventoryLeft);

            leftItems = itemsLeft.GetVinegarLeft();

            maxItems = minMaxItemsDisplay.maxItemsPantryStaples;

            RestockItems("Vinegar", inventoryLeft, leftItems, maxItems);

            itemsLeft.vinegarLeftText.color = Color.white;
        }
        restockButton.SetActive(false);
    }

    private void RestockItems(string itemName, int currentInventory, int leftItems, int maxItems)
    {
        if (currentInventory > 0)
        {
            int restockAmount = maxItems - leftItems;

            if (restockAmount > 0)
            {
                Debug.Log($"[RESTOCK] Restocking {restockAmount} {itemName} items.");

                itemsLeft.SetGoyaCandyLeft(maxItems);

                minMaxItemsDisplay.DecreaseInventoryItems("Candies", itemName, restockAmount);

                Debug.Log($"[RESTOCK] Updated Inventory {itemName} item: {minMaxItemsDisplay.GetInventoryItems(itemName)}");
            }
        }
    }

    public void EnableRestockButton()
    { restockButton.SetActive(true); }
}

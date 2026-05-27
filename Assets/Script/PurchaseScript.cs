using UnityEngine;
using UnityEngine.UI;

public class PurchaseScript : MonoBehaviour
{
    public MinMaxItemsDisplay minMaxItemsDisplay;

    public GameObject shopBuyItems;
    public GameObject purchaseButton;

    public Button goyaCandyItem;
    public Button mentosItem;
    public Button whiteRabbitItem;
    public Button riceItem;
    public Button soySauceItem;
    public Button vinegarItem;
    public Button surfItem;
    public Button joyItem;
    public Button paylessXtraBigItem;
    public Button luckyMeItem;
    public Button cupNoodleItem;
    public Button colgateItem;
    public Button rexonaItem;
    public Button sunsilkItem;
    public Button chippyItem;
    public Button novaItem;
    public Button piattos;
    public Button cokeItem;
    public Button pepsiItem;
    public Button royalItem;
    public Button zestoAppleItem;
    public Button zestoGrapeItem;
    public Button zestoOrangeItem;

    public ItemsLeft itemsLeft;
    public PlayerCurrency playerCurrency;

    public void ShowPurchaseItems()
    {
        shopBuyItems.SetActive(true);
        purchaseButton.SetActive(false);
    }

    public void CloseInventoryShop()
    {
        shopBuyItems.SetActive(false);
        purchaseButton.SetActive(true);
    }
    public void PurchaseItem(Button buttonText)
    {
        string itemName = buttonText.GetComponentInChildren<Text>().text;
        Debug.Log($"[PURCHASE] Attempting to purchase: {itemName}");

        string cleanedItemName = itemName.Substring(4);
        float currentCurrency = playerCurrency.GetCurrentCurrency();
        Debug.Log($"[PURCHASE] Current currency: {currentCurrency}");

        int maxDisplay, itemsRemainingToMax;

        if (cleanedItemName.Equals("Goya Candy"))
        {
            if (currentCurrency >= 62.50f)
            {
                int currentGoyaCandy = itemsLeft.GetGoyaCandyLeft();
                Debug.Log($"[PURCHASE] Current Candy before purchase: {currentGoyaCandy}");

                minMaxItemsDisplay.SetInventoryItems("Candies", "Goya Candy", 50);
                Debug.Log($"[PURCHASE] Added 50 Goya Candy to inventory. Current Candy Inventory: {minMaxItemsDisplay.GetInventoryItems("Candies")}");

                maxDisplay = minMaxItemsDisplay.maxItemsCandies;

                if (currentGoyaCandy + 50 > maxDisplay)
                {
                    itemsLeft.SetGoyaCandyLeft(maxDisplay);

                    itemsRemainingToMax = maxDisplay - currentGoyaCandy;

                    Debug.Log($"[PURCHASE] Items exceeding before max: {itemsRemainingToMax}");
                    minMaxItemsDisplay.DecreaseInventoryItems("Candies", "Goya Candy", itemsRemainingToMax);

                    Debug.Log($"[PURCHASE] Current Candy Inventory: {minMaxItemsDisplay.GetInventoryItems("Goya Candy")}");
                    Debug.Log($"[PURCHASE] Current Candy: {itemsLeft.GetGoyaCandyLeft()} (Capped at max display)");
                }

                playerCurrency.SetCurrentCurrency(currentCurrency - 62.50f);
                Debug.Log($"[PURCHASE] Currency after purchase: {playerCurrency.GetCurrentCurrency()}");
            }
            else
            {
                Debug.Log("[PURCHASE] Not enough currency to purchase Goya Candy.");
            }
        }
        else if (cleanedItemName.Equals("Mentos"))
        {
            if (currentCurrency >= 84f)
            {
                int currentMentos = itemsLeft.GetMentosLeft();

                minMaxItemsDisplay.SetInventoryItems("Candies", "Mentos", 24);
                Debug.Log($"[PURCHASE] Added 24 Mentos to inventory. Current Mentos Inventory: {minMaxItemsDisplay.GetInventoryItems("Mentos")}");

                maxDisplay = minMaxItemsDisplay.maxItemsCandies;

                if (currentMentos + 24 > maxDisplay)
                {
                    itemsLeft.SetMentosLeft(maxDisplay);

                    itemsRemainingToMax = maxDisplay - currentMentos;

                    Debug.Log($"[PURCHASE] Items exceeding before max: {itemsRemainingToMax}");
                    minMaxItemsDisplay.DecreaseInventoryItems("Candies", "Mentos", itemsRemainingToMax);

                    Debug.Log($"[PURCHASE] Current Mentos Inventory: {minMaxItemsDisplay.GetInventoryItems("Mentos")}");
                    Debug.Log($"[PURCHASE] Current Mentos: {itemsLeft.GetMentosLeft()} (Capped at max display)");
                }

                playerCurrency.SetCurrentCurrency(currentCurrency - 84f);
                Debug.Log($"[PURCHASE] Currency after purchase: {playerCurrency.GetCurrentCurrency()}");
            }
            else
            {
                Debug.Log("[PURCHASE] Not enough currency to purchase Mentos.");
            }
        }
        else if (cleanedItemName.Equals("White Rabbit"))
        {
            if (currentCurrency >= 20f)
            {
                int currentWhiteRabbit = itemsLeft.GetWhiteRabbitLeft();

                minMaxItemsDisplay.SetInventoryItems("Candies", "White Rabbit", 10);
                Debug.Log($"[PURCHASE] Added 10 White Rabbit to inventory. Current White Rabbit Inventory: {minMaxItemsDisplay.GetInventoryItems("White Rabbit")}");

                maxDisplay = minMaxItemsDisplay.maxItemsCandies;

                if (currentWhiteRabbit + 10 > maxDisplay)
                {
                    itemsLeft.SetWhiteRabbitLeft(maxDisplay);

                    itemsRemainingToMax = maxDisplay - currentWhiteRabbit;

                    Debug.Log($"[PURCHASE] Items exceeding before max: {itemsRemainingToMax}");
                    minMaxItemsDisplay.DecreaseInventoryItems("Candies", "White Rabbit", itemsRemainingToMax);

                    Debug.Log($"[PURCHASE] Current White Rabbit Inventory: {minMaxItemsDisplay.GetInventoryItems("White Rabbit")}");
                    Debug.Log($"[PURCHASE] Current White Rabbit: {itemsLeft.GetWhiteRabbitLeft()} (Capped at max display)");
                }

                playerCurrency.SetCurrentCurrency(currentCurrency - 20f);
                Debug.Log($"[PURCHASE] Currency after purchase: {playerCurrency.GetCurrentCurrency()}");
            }
            else
            {
                Debug.Log("[PURCHASE] Not enough currency to purchase White Rabbit.");
            }
        }
        else if (cleanedItemName.Equals("Rice"))
        {
            if (currentCurrency >= 300f)
            {
                int currentRice = itemsLeft.GetRiceLeft();

                minMaxItemsDisplay.SetInventoryItems("Pantry Staples", "Rice", 25);

                maxDisplay = minMaxItemsDisplay.maxItemsPantryStaples;

                if (currentRice + 25 > maxDisplay)
                {
                    itemsLeft.SetRiceLeft(maxDisplay);
                    
                    itemsRemainingToMax = maxDisplay - currentRice;
                    Debug.Log($"[PURCHASE] Items exceeding before max: {itemsRemainingToMax}");
                    
                    minMaxItemsDisplay.DecreaseInventoryItems("Pantry Staples", "Rice", itemsRemainingToMax);
                    Debug.Log($"[PURCHASE] Current Rice Inventory: {minMaxItemsDisplay.GetInventoryItems("Rice")}");
                    Debug.Log($"[PURCHASE] Current Rice: {itemsLeft.GetRiceLeft()} (Capped at max display)");
                }
                playerCurrency.SetCurrentCurrency(currentCurrency - 300f);
                Debug.Log($"[PURCHASE] Currency after purchase: {playerCurrency.GetCurrentCurrency()}");
            }
            else
            {
                Debug.Log("[PURCHASE] Not enough currency to purchase Rice.");
            }
        }
        else if (cleanedItemName.Equals("Soy Sauce"))
        {
            if (currentCurrency >= 24f)
            {
                int currentSoySauce = itemsLeft.GetSoySauceLeft();

                minMaxItemsDisplay.SetInventoryItems("Pantry Staples", "Soy Sauce", 12);

                maxDisplay = minMaxItemsDisplay.maxItemsPantryStaples;
                if (currentSoySauce + 12 > maxDisplay)
                {
                    itemsLeft.SetSoySauceLeft(maxDisplay);

                    itemsRemainingToMax = maxDisplay - currentSoySauce;
                    Debug.Log($"[PURCHASE] Items exceeding before max: {itemsRemainingToMax}");

                    minMaxItemsDisplay.DecreaseInventoryItems("Pantry Staples", "Soy Sauce", itemsRemainingToMax);
                    Debug.Log($"[PURCHASE] Current Soy Sauce Inventory: {minMaxItemsDisplay.GetInventoryItems("Soy Sauce")}");
                    Debug.Log($"[PURCHASE] Current Soy Sauce: {itemsLeft.GetSoySauceLeft()} (Capped at max display)");
                }
                playerCurrency.SetCurrentCurrency(currentCurrency - 24f);
                Debug.Log($"[PURCHASE] Currency after purchase: {playerCurrency.GetCurrentCurrency()}");
            }
            else
            {
                Debug.Log("[PURCHASE] Not enough currency to purchase Soy Sauce.");
            }
        }
        else if (cleanedItemName.Equals("Vinegar"))
        {
            if (currentCurrency >= 21f)
            {
                int currentVinegar = itemsLeft.GetVinegarLeft();

                minMaxItemsDisplay.SetInventoryItems("Pantry Staples", "Vinegar", 12);

                maxDisplay = minMaxItemsDisplay.maxItemsPantryStaples;

                if (currentVinegar + 12 > maxDisplay)
                {
                    itemsLeft.SetVinegarLeft(maxDisplay);

                    itemsRemainingToMax = maxDisplay - currentVinegar;
                    Debug.Log($"[PURCHASE] Items exceeding before max: {itemsRemainingToMax}");
                    
                    minMaxItemsDisplay.DecreaseInventoryItems("Pantry Staples", "Vinegar", itemsRemainingToMax);
                    Debug.Log($"[PURCHASE] Current Vinegar Inventory: {minMaxItemsDisplay.GetInventoryItems("Vinegar")}");
                    Debug.Log($"[PURCHASE] Current Vinegar: {itemsLeft.GetVinegarLeft()} (Capped at max display)");
                }
                playerCurrency.SetCurrentCurrency(currentCurrency - 21f);
                Debug.Log($"[PURCHASE] Currency after purchase: {playerCurrency.GetCurrentCurrency()}");
            }
            else
            {
                Debug.Log("[PURCHASE] Not enough currency to purchase Vinegar.");
            }
        }
        else if (cleanedItemName.Equals("Joy"))
        {
            if (currentCurrency >= 31.25f)
            {
                int currentJoy = itemsLeft.GetJoyLeft();
                //itemsLeft.SetJoyLeft(currentJoy + 25);
                //Debug.Log($"[PURCHASE] Current Joy: {itemsLeft.GetJoyLeft()}");

                minMaxItemsDisplay.SetInventoryItems("HouseHold Basics", "Joy", 25);

                maxDisplay = minMaxItemsDisplay.maxItemsHouseHoldBasics;

                if (currentJoy + 25 > maxDisplay)
                {
                    itemsLeft.SetJoyLeft(maxDisplay);

                    itemsRemainingToMax = maxDisplay - currentJoy;
                    Debug.Log($"[PURCHASE] Items exceeding before max: {itemsRemainingToMax}");

                    minMaxItemsDisplay.DecreaseInventoryItems("HouseHold Basics", "Joy", itemsRemainingToMax);
                    Debug.Log($"[PURCHASE] Current Joy Inventory: {minMaxItemsDisplay.GetInventoryItems("Joy")}");
                    Debug.Log($"[PURCHASE] Current Joy: {itemsLeft.GetJoyLeft()} (Capped at max display)");
                }
                playerCurrency.SetCurrentCurrency(currentCurrency - 31.25f);
                Debug.Log($"[PURCHASE] Currency after purchase: {playerCurrency.GetCurrentCurrency()}");
            }
            else
            {
                Debug.Log("[PURCHASE] Not enough currency to purchase Joy.");
            }
        }
        else if (cleanedItemName.Equals("Surf"))
        {
            if (currentCurrency >= 31.25f)
            {
                int currentSurf = itemsLeft.GetSurfLeft();

                minMaxItemsDisplay.SetInventoryItems("HouseHold Basics", "Surf", 25);

                maxDisplay = minMaxItemsDisplay.maxItemsHouseHoldBasics;

                if (currentSurf + 25 > maxDisplay)
                {
                    itemsLeft.SetSurfLeft(maxDisplay);

                    itemsRemainingToMax = maxDisplay - currentSurf;
                    Debug.Log($"[PURCHASE] Items exceeding before max: {itemsRemainingToMax}");
                    
                    minMaxItemsDisplay.DecreaseInventoryItems("HouseHold Basics", "Surf", itemsRemainingToMax);
                    Debug.Log($"[PURCHASE] Current Surf Inventory: {minMaxItemsDisplay.GetInventoryItems("Surf")}");
                    Debug.Log($"[PURCHASE] Current Surf: {itemsLeft.GetSurfLeft()} (Capped at max display)");
                }
                playerCurrency.SetCurrentCurrency(currentCurrency - 31.25f);
                Debug.Log($"[PURCHASE] Currency after purchase: {playerCurrency.GetCurrentCurrency()}");
            }
            else
            {
                Debug.Log("[PURCHASE] Not enough currency to purchase Surf.");
            }
        }
        else if (cleanedItemName.Equals("Payless Xtra Big"))
        {
            if (currentCurrency >= 54f)
            {
                int currentPaylessXtraBig = itemsLeft.GetPaylessXtraBigLeft();

                minMaxItemsDisplay.SetInventoryItems("Instant Noodles", "Payless Xtra Big", 24);

                int maxDisplayPaylessXtraBig = minMaxItemsDisplay.maxItemsInstantNoodles;

                if (currentPaylessXtraBig + 24 > maxDisplayPaylessXtraBig)
                {
                    itemsLeft.SetPaylessXtraBigLeft(maxDisplayPaylessXtraBig);
                    
                    itemsRemainingToMax = maxDisplayPaylessXtraBig - currentPaylessXtraBig;
                    Debug.Log($"[PURCHASE] Items exceeding before max: {itemsRemainingToMax}");
                    
                    minMaxItemsDisplay.DecreaseInventoryItems("Instant Noodles", "Payless Xtra Big", itemsRemainingToMax);
                    Debug.Log($"[PURCHASE] Current Payless Xtra Big Inventory: {minMaxItemsDisplay.GetInventoryItems("Payless Xtra Big")}");
                    Debug.Log($"[PURCHASE] Current Payless Xtra Big: {itemsLeft.GetPaylessXtraBigLeft()} (Capped at max display)");
                }
                playerCurrency.SetCurrentCurrency(currentCurrency - 54f);
                Debug.Log($"[PURCHASE] Currency after purchase: {playerCurrency.GetCurrentCurrency()}");
            }
            else
            {
                Debug.Log("[PURCHASE] Not enough currency to purchase Payless Xtra Big.");
            }
        }
        else if (cleanedItemName.Equals("Lucky Me"))
        {
            if (currentCurrency >= 84f)
            {
                int currentLuckyMe = itemsLeft.GetLuckyMeLeft();

                minMaxItemsDisplay.SetInventoryItems("Instant Noodles", "Lucky Me", 24);
                int maxDisplayLuckyMe = minMaxItemsDisplay.maxItemsInstantNoodles;

                if (currentLuckyMe + 24 > maxDisplayLuckyMe)
                {
                    itemsLeft.SetLuckyMeLeft(maxDisplayLuckyMe);
                    
                    itemsRemainingToMax = maxDisplayLuckyMe - currentLuckyMe;
                    Debug.Log($"[PURCHASE] Items exceeding before max: {itemsRemainingToMax}");
                    
                    minMaxItemsDisplay.DecreaseInventoryItems("Instant Noodles", "Lucky Me", itemsRemainingToMax);
                    Debug.Log($"[PURCHASE] Current Lucky Me Inventory: {minMaxItemsDisplay.GetInventoryItems("Lucky Me")}");
                    Debug.Log($"[PURCHASE] Current Lucky Me: {itemsLeft.GetLuckyMeLeft()} (Capped at max display)");
                }
                playerCurrency.SetCurrentCurrency(currentCurrency - 84f);
                Debug.Log($"[PURCHASE] Currency after purchase: {playerCurrency.GetCurrentCurrency()}");
            }
            else
            {
                Debug.Log("[PURCHASE] Not enough currency to purchase Lucky Me.");
            }
        }
        else if (cleanedItemName.Equals("Cup Noodle"))
        {
            if (currentCurrency >= 108f)
            {
                int currentCupNoodle = itemsLeft.GetCupNoodleLeft();

                minMaxItemsDisplay.SetInventoryItems("Instant Noodles", "Cup Noodle", 12);

                int maxDisplayCupNoodle = minMaxItemsDisplay.maxItemsInstantNoodles;

                if (currentCupNoodle + 12 > maxDisplayCupNoodle)
                {
                    itemsLeft.SetCupNoodleLeft(maxDisplayCupNoodle);
                    
                    itemsRemainingToMax = maxDisplayCupNoodle - currentCupNoodle;
                    Debug.Log($"[PURCHASE] Items exceeding before max: {itemsRemainingToMax}");
                    
                    minMaxItemsDisplay.DecreaseInventoryItems("Instant Noodles", "Cup Noodle", itemsRemainingToMax);
                    Debug.Log($"[PURCHASE] Current Cup Noodle Inventory: {minMaxItemsDisplay.GetInventoryItems("Cup Noodle")}");
                    Debug.Log($"[PURCHASE] Current Cup Noodle: {itemsLeft.GetCupNoodleLeft()} (Capped at max display)");
                }
                playerCurrency.SetCurrentCurrency(currentCurrency - 108f);
                Debug.Log($"[PURCHASE] Currency after purchase: {playerCurrency.GetCurrentCurrency()}");
            }
            else
            {
                Debug.Log("[PURCHASE] Not enough currency to purchase Cup Noodle.");
            }
        }
        else if (cleanedItemName.Equals("Colgate"))
        {
            if (currentCurrency >= 48f)
            {
                int currentColgate = itemsLeft.GetColgateLeft();

                minMaxItemsDisplay.SetInventoryItems("Personal Care", "Colgate", 24);

                maxDisplay = minMaxItemsDisplay.maxItemsPersonalCare;

                if (currentColgate + 24 > maxDisplay)
                {
                    itemsLeft.SetColgateLeft(maxDisplay);
                    
                    itemsRemainingToMax = maxDisplay - currentColgate;
                    Debug.Log($"[PURCHASE] Items exceeding before max: {itemsRemainingToMax}");
                    
                    minMaxItemsDisplay.DecreaseInventoryItems("Personal Care", "Colgate", itemsRemainingToMax);
                    Debug.Log($"[PURCHASE] Current Colgate Inventory: {minMaxItemsDisplay.GetInventoryItems("Colgate")}");
                    Debug.Log($"[PURCHASE] Current Colgate: {itemsLeft.GetColgateLeft()} (Capped at max display)");
                }
                playerCurrency.SetCurrentCurrency(currentCurrency - 48f);
                Debug.Log($"[PURCHASE] Currency after purchase: {playerCurrency.GetCurrentCurrency()}");
            }
            else
            {
                Debug.Log("[PURCHASE] Not enough currency to purchase Colgate.");
            }
        }
        else if (cleanedItemName.Equals("Rexona"))
        {
            if (currentCurrency >= 144f)
            {
                int currentRexona = itemsLeft.GetRexonaLeft();

                minMaxItemsDisplay.SetInventoryItems("Personal Care", "Rexona", 12);

                maxDisplay = minMaxItemsDisplay.maxItemsPersonalCare;

                if (currentRexona + 12 > maxDisplay)
                {
                    itemsLeft.SetRexonaLeft(maxDisplay);
                    
                    itemsRemainingToMax = maxDisplay - currentRexona;
                    Debug.Log($"[PURCHASE] Items exceeding before max: {itemsRemainingToMax}");
                    
                    minMaxItemsDisplay.DecreaseInventoryItems("Personal Care", "Rexona", itemsRemainingToMax);
                    Debug.Log($"[PURCHASE] Current Rexona Inventory: {minMaxItemsDisplay.GetInventoryItems("Rexona")}");
                    Debug.Log($"[PURCHASE] Current Rexona: {itemsLeft.GetRexonaLeft()} (Capped at max display)");
                }
                playerCurrency.SetCurrentCurrency(currentCurrency - 144f);
                Debug.Log($"[PURCHASE] Currency after purchase: {playerCurrency.GetCurrentCurrency()}");
            }
            else
            {
                Debug.Log("[PURCHASE] Not enough currency to purchase Rexona.");
            }
        }
        else if (cleanedItemName.Equals("Sunsilk"))
        {
            if (currentCurrency >= 30f)
            {
                int currentSunsilk = itemsLeft.GetSunsilkLeft();

                minMaxItemsDisplay.SetInventoryItems("Personal Care", "Sunsilk", 24);

                maxDisplay = minMaxItemsDisplay.maxItemsPersonalCare;

                if (currentSunsilk + 24 > maxDisplay)
                {
                    itemsLeft.SetSunsilkLeft(maxDisplay);
                    
                    itemsRemainingToMax = maxDisplay - currentSunsilk;
                    Debug.Log($"[PURCHASE] Items exceeding before max: {itemsRemainingToMax}");
                    
                    minMaxItemsDisplay.DecreaseInventoryItems("Personal Care", "Sunsilk", itemsRemainingToMax);
                    Debug.Log($"[PURCHASE] Current Sunsilk Inventory: {minMaxItemsDisplay.GetInventoryItems("Sunsilk")}");
                    Debug.Log($"[PURCHASE] Current Sunsilk: {itemsLeft.GetSunsilkLeft()} (Capped at max display)");
                }

                playerCurrency.SetCurrentCurrency(currentCurrency - 30f);
                Debug.Log($"[PURCHASE] Currency after purchase: {playerCurrency.GetCurrentCurrency()}");
            }
            else
            {
                Debug.Log("[PURCHASE] Not enough currency to purchase Sunsilk.");
            }
        }
        else if (cleanedItemName.Equals("Chippy"))
        {
            if (currentCurrency >= 96f)
            {
                int currentChippy = itemsLeft.GetChippyLeft();

                minMaxItemsDisplay.SetInventoryItems("Snacks", "Chippy", 24);

                maxDisplay = minMaxItemsDisplay.maxItemsSnacks;

                if (currentChippy + 24 > maxDisplay)
                {
                    itemsLeft.SetChippyLeft(maxDisplay);
                    
                    itemsRemainingToMax = maxDisplay - currentChippy;
                    Debug.Log($"[PURCHASE] Items exceeding before max: {itemsRemainingToMax}");
                    
                    minMaxItemsDisplay.DecreaseInventoryItems("Snacks", "Chippy", itemsRemainingToMax);
                    Debug.Log($"[PURCHASE] Current Chippy Inventory: {minMaxItemsDisplay.GetInventoryItems("Chippy")}");
                    Debug.Log($"[PURCHASE] Current Chippy: {itemsLeft.GetChippyLeft()} (Capped at max display)");
                }
                playerCurrency.SetCurrentCurrency(currentCurrency - 96f);
                Debug.Log($"[PURCHASE] Currency after purchase: {playerCurrency.GetCurrentCurrency()}");
            }
            else
            {
                Debug.Log("[PURCHASE] Not enough currency to purchase Chippy.");
            }
        }
        else if (cleanedItemName.Equals("Nova"))
        {
            if (currentCurrency >= 96f)
            {
                int currentNova = itemsLeft.GetNovaLeft();

                minMaxItemsDisplay.SetInventoryItems("Snacks", "Nova", 24);

                maxDisplay = minMaxItemsDisplay.maxItemsSnacks;

                if (currentNova + 24 > maxDisplay)
                {
                    itemsLeft.SetNovaLeft(maxDisplay);
                    
                    itemsRemainingToMax = maxDisplay - currentNova;
                    Debug.Log($"[PURCHASE] Items exceeding before max: {itemsRemainingToMax}");
                    
                    minMaxItemsDisplay.DecreaseInventoryItems("Snacks", "Nova", itemsRemainingToMax);
                    Debug.Log($"[PURCHASE] Current Nova Inventory: {minMaxItemsDisplay.GetInventoryItems("Nova")}");
                    Debug.Log($"[PURCHASE] Current Nova: {itemsLeft.GetNovaLeft()} (Capped at max display)");
                }
                playerCurrency.SetCurrentCurrency(currentCurrency - 96f);
                Debug.Log($"[PURCHASE] Currency after purchase: {playerCurrency.GetCurrentCurrency()}");
            }
            else
            {
                Debug.Log("[PURCHASE] Not enough currency to purchase Nova.");
            }
        }
        else if (cleanedItemName.Equals("Piattos"))
        {
            if (currentCurrency >= 96f)
            {
                int currentPiattos = itemsLeft.GetPiattosLeft();

                minMaxItemsDisplay.SetInventoryItems("Snacks", "Piattos", 24);

                maxDisplay = minMaxItemsDisplay.maxItemsSnacks;

                if (currentPiattos + 24 > maxDisplay)
                {
                    itemsLeft.SetPiattosLeft(maxDisplay);
                    
                    itemsRemainingToMax = maxDisplay - currentPiattos;
                    Debug.Log($"[PURCHASE] Items exceeding before max: {itemsRemainingToMax}");
                    
                    minMaxItemsDisplay.DecreaseInventoryItems("Snacks", "Piattos", itemsRemainingToMax);
                    Debug.Log($"[PURCHASE] Current Piattos Inventory: {minMaxItemsDisplay.GetInventoryItems("Piattos")}");
                    Debug.Log($"[PURCHASE] Current Piattos: {itemsLeft.GetPiattosLeft()} (Capped at max display)");
                }
                playerCurrency.SetCurrentCurrency(currentCurrency - 96f);
                Debug.Log($"[PURCHASE] Currency after purchase: {playerCurrency.GetCurrentCurrency()}");
            }
            else
            {
                Debug.Log("[PURCHASE] Not enough currency to purchase Piattos.");
            }
        }
        else if (cleanedItemName.Equals("Coke"))
        {
            if (currentCurrency >= 108f)
            {
                int currentCoke = itemsLeft.GetCokeLeft();

                minMaxItemsDisplay.SetInventoryItems("Drinks", "Coke", 24);

                maxDisplay = minMaxItemsDisplay.maxItemsDrinks;

                if (currentCoke + 24 > maxDisplay)
                {
                    itemsLeft.SetCokeLeft(maxDisplay);
                    
                    itemsRemainingToMax = maxDisplay - currentCoke;
                    Debug.Log($"[PURCHASE] Items exceeding before max: {itemsRemainingToMax}");
                    
                    minMaxItemsDisplay.DecreaseInventoryItems("Drinks", "Coke", itemsRemainingToMax);
                    Debug.Log($"[PURCHASE] Current Coke Inventory: {minMaxItemsDisplay.GetInventoryItems("Coke")}");
                    Debug.Log($"[PURCHASE] Current Coke: {itemsLeft.GetCokeLeft()} (Capped at max display)");
                }
                playerCurrency.SetCurrentCurrency(currentCurrency - 108f);
                Debug.Log($"[PURCHASE] Currency after purchase: {playerCurrency.GetCurrentCurrency()}");
            }
            else
            {
                Debug.Log("[PURCHASE] Not enough currency to purchase Coke.");
            }
        }
        else if (cleanedItemName.Equals("Pepsi"))
        {
            if (currentCurrency >= 108f)
            {
                int currentPepsi = itemsLeft.GetPepsiLeft();

                minMaxItemsDisplay.SetInventoryItems("Drinks", "Pepsi", 24);

                maxDisplay = minMaxItemsDisplay.maxItemsDrinks;

                if (currentPepsi + 24 > maxDisplay)
                {
                    itemsLeft.SetPepsiLeft(maxDisplay);
                    
                    itemsRemainingToMax = maxDisplay - currentPepsi;
                    Debug.Log($"[PURCHASE] Items exceeding before max: {itemsRemainingToMax}");
                    
                    minMaxItemsDisplay.DecreaseInventoryItems("Drinks", "Pepsi", itemsRemainingToMax);
                    Debug.Log($"[PURCHASE] Current Pepsi Inventory: {minMaxItemsDisplay.GetInventoryItems("Pepsi")}");
                    Debug.Log($"[PURCHASE] Current Pepsi: {itemsLeft.GetPepsiLeft()} (Capped at max display)");
                }
                playerCurrency.SetCurrentCurrency(currentCurrency - 108f);
                Debug.Log($"[PURCHASE] Currency after purchase: {playerCurrency.GetCurrentCurrency()}");
            }
            else
            {
                Debug.Log("[PURCHASE] Not enough currency to purchase Pepsi.");
            }
        }
        else if (cleanedItemName.Equals("Royal"))
        {
            if (currentCurrency >= 108f)
            {
                int currentRoyal = itemsLeft.GetRoyalLeft();

                minMaxItemsDisplay.SetInventoryItems("Drinks", "Royal", 24);

                maxDisplay = minMaxItemsDisplay.maxItemsDrinks;

                if (currentRoyal + 24 > maxDisplay)
                {
                    itemsLeft.SetRoyalLeft(maxDisplay);
                    
                    itemsRemainingToMax = maxDisplay - currentRoyal;
                    Debug.Log($"[PURCHASE] Items exceeding before max: {itemsRemainingToMax}");
                    
                    minMaxItemsDisplay.DecreaseInventoryItems("Drinks", "Royal", itemsRemainingToMax);
                    Debug.Log($"[PURCHASE] Current Royal Inventory: {minMaxItemsDisplay.GetInventoryItems("Royal")}");
                    Debug.Log($"[PURCHASE] Current Royal: {itemsLeft.GetRoyalLeft()} (Capped at max display)");
                }
                playerCurrency.SetCurrentCurrency(currentCurrency - 108f);
                Debug.Log($"[PURCHASE] Currency after purchase: {playerCurrency.GetCurrentCurrency()}");
            }
            else
            {
                Debug.Log("[PURCHASE] Not enough currency to purchase Royal.");
            }
        }
        else if (cleanedItemName.Equals("Zesto Apple"))
        {
            if (currentCurrency >= 20f)
            {
                int currentZestoApple = itemsLeft.GetZestoAppleLeft();

                itemsLeft.SetZestoAppleLeft(currentZestoApple + 10);

                maxDisplay = minMaxItemsDisplay.maxItemsDrinks;

                if (currentZestoApple + 10 > maxDisplay)
                {
                    itemsLeft.SetZestoAppleLeft(maxDisplay);
                    
                    itemsRemainingToMax = maxDisplay - currentZestoApple;
                    Debug.Log($"[PURCHASE] Items exceeding before max: {itemsRemainingToMax}");
                    
                    minMaxItemsDisplay.DecreaseInventoryItems("Drinks", "Zesto Apple", itemsRemainingToMax);
                    Debug.Log($"[PURCHASE] Current Zesto Apple Inventory: {minMaxItemsDisplay.GetInventoryItems("Zesto Apple")}");
                    Debug.Log($"[PURCHASE] Current Zesto Apple: {itemsLeft.GetZestoAppleLeft()} (Capped at max display)");
                }
                playerCurrency.SetCurrentCurrency(currentCurrency - 20f);
                Debug.Log($"[PURCHASE] Currency after purchase: {playerCurrency.GetCurrentCurrency()}");
            }
            else
            {
                Debug.Log("[PURCHASE] Not enough currency to purchase Zesto Apple.");
            }
        }
        else if (cleanedItemName.Equals("Zesto Grape"))
        {
            if (currentCurrency >= 20f)
            {
                int currentZestoGrape = itemsLeft.GetZestoGrapeLeft();

                itemsLeft.SetZestoGrapeLeft(currentZestoGrape + 10);

                maxDisplay = minMaxItemsDisplay.maxItemsDrinks;

                if (currentZestoGrape + 10 > maxDisplay)
                {
                    itemsLeft.SetZestoGrapeLeft(maxDisplay);
                    
                    itemsRemainingToMax = maxDisplay - currentZestoGrape;
                    Debug.Log($"[PURCHASE] Items exceeding before max: {itemsRemainingToMax}");
                    
                    minMaxItemsDisplay.DecreaseInventoryItems("Drinks", "Zesto Grape", itemsRemainingToMax);
                    Debug.Log($"[PURCHASE] Current Zesto Grape Inventory: {minMaxItemsDisplay.GetInventoryItems("Zesto Grape")}");
                    Debug.Log($"[PURCHASE] Current Zesto Grape: {itemsLeft.GetZestoGrapeLeft()} (Capped at max display)");
                }
                playerCurrency.SetCurrentCurrency(currentCurrency - 20f);
                Debug.Log($"[PURCHASE] Currency after purchase: {playerCurrency.GetCurrentCurrency()}");
            }
            else
            {
                Debug.Log("[PURCHASE] Not enough currency to purchase Zesto Grape.");
            }
        }
        else if (cleanedItemName.Equals("Zesto Orange"))
        {
            if (currentCurrency >= 20f)
            {
                int currentZestoOrange = itemsLeft.GetZestoOrangeLeft();

                itemsLeft.SetZestoOrangeLeft(currentZestoOrange + 10);

                maxDisplay = minMaxItemsDisplay.maxItemsDrinks;

                if (currentZestoOrange + 10 > maxDisplay)
                {
                    itemsLeft.SetZestoOrangeLeft(maxDisplay);
                    
                    itemsRemainingToMax = maxDisplay - currentZestoOrange;
                    Debug.Log($"[PURCHASE] Items exceeding before max: {itemsRemainingToMax}");
                    
                    minMaxItemsDisplay.DecreaseInventoryItems("Drinks", "Zesto Orange", itemsRemainingToMax);
                    Debug.Log($"[PURCHASE] Current Zesto Orange Inventory: {minMaxItemsDisplay.GetInventoryItems("Zesto Orange")}");
                    Debug.Log($"[PURCHASE] Current Zesto Orange: {itemsLeft.GetZestoOrangeLeft()} (Capped at max display)");
                }
                playerCurrency.SetCurrentCurrency(currentCurrency - 20f);
                Debug.Log($"[PURCHASE] Currency after purchase: {playerCurrency.GetCurrentCurrency()}");
            }
            else
            {
                Debug.Log("[PURCHASE] Not enough currency to purchase Zesto Orange.");
            }
        }
        else
        {
            Debug.LogWarning($"[PURCHASE] Unknown item: {cleanedItemName}");
        }
    }
}

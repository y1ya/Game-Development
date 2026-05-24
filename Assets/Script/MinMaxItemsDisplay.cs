using UnityEngine;

public class MinMaxItemsDisplay : MonoBehaviour
{
    public int maxItemsCandies = 15;
    public int minItemsCandies = 3;

    public int maxItemsDrinks = 10;
    public int minItemsDrinks = 3;

    public int maxItemsHouseHoldBasics = 20;
    public int minItemsHouseHoldBasics = 3;

    public int maxItemsInstantNoodles = 15;
    public int minItemsInstantNoodles = 3;

    public int maxItemsPantryStaples = 10;
    public int minItemsPantryStaples = 3;

    public int maxItemsPersonalCare = 10;
    public int minItemsPersonalCare = 3;

    public int maxItemsSnacks = 20;
    public int minItemsSnacks = 3;

    private int inventoryItemsGoyaCandy = 0;
    private int inventoryItemsMentos = 0;
    private int inventoryItemsWhiteRabbit = 0;

    private int inventoryItemsCoke = 0;
    private int inventoryItemsPepsi = 0;
    private int inventoryItemsRoyal = 0;
    private int inventoryItemsZestoApple = 0;
    private int inventoryItemsZestoGrape = 0;
    private int inventoryItemsZestoOrange = 0;

    private int inventoryItemsJoy = 0;
    private int inventoryItemsSurf = 0;

    private int inventoryItemsPaylessXtraBig = 0;
    private int inventoryItemsLuckyMe = 0;
    private int inventoryItemsCupNoodle = 0;

    private int inventoryItemsRice = 0;
    private int inventoryItemsSoySauce = 0;
    private int inventoryItemsVinegar = 0;

    private int inventoryItemsColgate = 0;
    private int inventoryItemsRexona = 0;
    private int inventoryItemsSunsilk = 0;

    private int inventoryItemsChippy = 0;
    private int inventoryItemsNova = 0;
    private int inventoryItemsPiattos = 0;

    public void SetInventoryItems(string category, string item,int items)
    {
        switch (category)
        {
            case "Candies":
                if (item == "Goya Candy")
                { inventoryItemsGoyaCandy += items; }
                else if (item == "Mentos")
                { inventoryItemsMentos += items; }
                else if (item == "White Rabbit")
                { inventoryItemsWhiteRabbit += items; }
                break;
            case "Drinks":
                if (item == "Coke")
                { inventoryItemsCoke += items; }
                else if (item == "Pepsi")
                { inventoryItemsPepsi += items; }
                else if (item == "Royal")
                { inventoryItemsRoyal += items; }
                else if (item == "Zesto Apple")
                { inventoryItemsZestoApple += items; }
                else if (item == "Zesto Grape")
                { inventoryItemsZestoGrape += items; }
                else if (item == "Zesto Orange")
                { inventoryItemsZestoOrange += items; }
                break;
            case "HouseHold Basics":
                if (item == "Joy")
                { inventoryItemsJoy += items; }
                else if (item == "Surf")
                { inventoryItemsSurf += items; }
                break;
            case "Instant Noodles":
                if (item == "Payless Xtra Big")
                { inventoryItemsPaylessXtraBig += items; }
                else if (item == "Lucky Me")
                { inventoryItemsLuckyMe += items; }
                else if (item == "Cup Noodle")
                { inventoryItemsCupNoodle += items; }
                break;
            case "Pantry Staples":
                if (item == "Rice")
                { inventoryItemsRice += items; }
                else if (item == "Soy Sauce")
                { inventoryItemsSoySauce += items; }
                else if (item == "Vinegar")
                { inventoryItemsVinegar += items; }
                break;
            case "Personal Care":
                if (item == "Colgate")
                { inventoryItemsColgate += items; }
                else if (item == "Rexona")
                { inventoryItemsRexona += items; }
                else if (item == "Sunsilk")
                { inventoryItemsSunsilk += items; }
                break;
            case "Snacks":
                if (item == "Chippy")
                { inventoryItemsChippy += items; }
                else if (item == "Nova")
                { inventoryItemsNova += items; }
                else if (item == "Piattos")
                { inventoryItemsPiattos += items; }
                break;
        }
    }

    public int GetInventoryItems(string category)
    {
        return category switch
        {
            "Goya Candy" => inventoryItemsGoyaCandy,
            "Mentos" => inventoryItemsMentos,
            "White Rabbit" => inventoryItemsWhiteRabbit,

            "Coke" => inventoryItemsCoke,
            "Pepsi" => inventoryItemsPepsi,
            "Royal" => inventoryItemsRoyal,
            "Zesto Apple" => inventoryItemsZestoApple,
            "Zesto Grape" => inventoryItemsZestoGrape,
            "Zesto Orange" => inventoryItemsZestoOrange,

            "Joy" => inventoryItemsJoy,
            "Surf" => inventoryItemsSurf,

            "Payless Xtra Big" => inventoryItemsPaylessXtraBig,
            "Lucky Me" => inventoryItemsLuckyMe,
            "Cup Noodle" => inventoryItemsCupNoodle,

            "Rice" => inventoryItemsRice,
            "Soy Sauce" => inventoryItemsSoySauce,
            "Vinegar" => inventoryItemsVinegar,

            "Colgate" => inventoryItemsColgate,
            "Rexona" => inventoryItemsRexona,
            "Sunsilk" => inventoryItemsSunsilk,

            "Chippy" => inventoryItemsChippy,
            "Nova" => inventoryItemsNova,
            "Piattos" => inventoryItemsPiattos,

            _ => 0
        };
    }

    public void DecreaseInventoryItems(string category, string item, int itemsDecreased)
    {
        switch (category)
        {
            case "Candies":
                if (item == "Goya Candy")
                { inventoryItemsGoyaCandy -= itemsDecreased; }
                else if (item == "Mentos")
                { inventoryItemsMentos -= itemsDecreased; }
                else if (item == "White Rabbit")
                { inventoryItemsWhiteRabbit -= itemsDecreased; }
                break;
            case "Drinks":
                if (item == "Coke")
                { inventoryItemsCoke -= itemsDecreased; }
                else if (item == "Pepsi")
                { inventoryItemsPepsi -= itemsDecreased; }
                else if (item == "Royal")
                { inventoryItemsRoyal -= itemsDecreased; }
                else if (item == "Zesto Apple")
                { inventoryItemsZestoApple -= itemsDecreased; }
                else if (item == "Zesto Grape")
                { inventoryItemsZestoGrape -= itemsDecreased; }
                else if (item == "Zesto Orange")
                { inventoryItemsZestoOrange -= itemsDecreased; }
                break;
            case "HouseHold Basics":
                if (item == "Joy")
                { inventoryItemsJoy -= itemsDecreased; }
                else if (item == "Surf")
                { inventoryItemsSurf -= itemsDecreased; }
                break;
            case "Instant Noodles":
                if (item == "Payless Xtra Big")
                { inventoryItemsPaylessXtraBig -= itemsDecreased; }
                else if (item == "Lucky Me")
                { inventoryItemsLuckyMe -= itemsDecreased; }
                else if (item == "Cup Noodle")
                { inventoryItemsCupNoodle -= itemsDecreased; }
                break;
            case "Pantry Staples":
                if (item == "Rice")
                { inventoryItemsRice -= itemsDecreased; }
                else if (item == "Soy Sauce")
                { inventoryItemsSoySauce -= itemsDecreased; }
                else if (item == "Vinegar")
                { inventoryItemsVinegar -= itemsDecreased; }
                break;
            case "Personal Care":
                if (item == "Colgate")
                { inventoryItemsColgate -= itemsDecreased; }
                else if (item == "Rexona")
                { inventoryItemsRexona -= itemsDecreased; }
                else if (item == "Sunsilk")
                { inventoryItemsSunsilk -= itemsDecreased; }
                break;
            case "Snacks":
                if (item == "Chippy")
                { inventoryItemsChippy -= itemsDecreased; }
                else if (item == "Nova")
                { inventoryItemsNova -= itemsDecreased; }
                else if (item == "Piattos")
                { inventoryItemsPiattos -= itemsDecreased; }
                break;
        }
    }

    public bool CheckMinimumRequirement(string item, int currentLeftItem)
    {
        return item switch
        {
            "Goya Candy" => currentLeftItem <= minItemsCandies,
            "Mentos" => currentLeftItem <= minItemsCandies,
            "White Rabbit" => currentLeftItem <= minItemsCandies,

            "Coke" => currentLeftItem <= minItemsDrinks,
            "Pepsi" => currentLeftItem <= minItemsDrinks,
            "Royal" => currentLeftItem <= minItemsDrinks,
            "Zesto Apple" => currentLeftItem <= minItemsDrinks,
            "Zesto Grape" => currentLeftItem <= minItemsDrinks,
            "Zesto Orange" => currentLeftItem <= minItemsDrinks,

            "Joy" => currentLeftItem <= minItemsHouseHoldBasics,
            "Surf" => currentLeftItem <= minItemsHouseHoldBasics,
            
            "Payless Xtra Big" => currentLeftItem <= minItemsInstantNoodles,
            "Lucky Me" => currentLeftItem <= minItemsInstantNoodles,
            "Cup Noodle" => currentLeftItem <= minItemsInstantNoodles,
            
            "Rice" => currentLeftItem <= minItemsPantryStaples,
            "Soy Sauce" => currentLeftItem <= minItemsPantryStaples,
            "Vinegar" => currentLeftItem <= minItemsPantryStaples,
            
            "Colgate" => currentLeftItem <= minItemsPersonalCare,
            "Rexona" => currentLeftItem <= minItemsPersonalCare,
            "Sunsilk" => currentLeftItem <= minItemsPersonalCare,
            
            "Chippy" => currentLeftItem <= minItemsSnacks,
            "Nova" => currentLeftItem <= minItemsSnacks,
            "Piattos" => currentLeftItem <= minItemsSnacks,

            _ => false
        };
    }
}

using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class ItemsLeft : MonoBehaviour
{
    public MinMaxItemsDisplay minMaxItemsDisplay;
    public RestockScript restockScript;

    private int goyaCandyLeft, mentosLeft, whiteRabbitLeft;
    private int riceLeft, soySauceLeft, vinegarLeft;
    private int joyLeft, surfLeft;
    private int paylessXtraBigLeft, luckyMeLeft, cupNoodleLeft;
    private int colgateLeft, rexonaLeft, sunsilkLeft;
    private int chippyLeft, novaLeft, piattosLeft;
    private int cokeLeft, pepsiLeft, royalLeft;
    private int zestoAppleLeft, zestoGrapeLeft, zestoOrangeLeft;
    private int adoboLeft, afritadaLeft, flakesInOilLeft;
    private int cheeseSpreadLeft, nescafeLeft, peanutButterLeft;
    private int artisanLeft, gardeniaLeft;

    public GameObject joyItem, surfItem;

    public Text goyaCandyLeftText, mentosLeftText, whiteRabbitLeftText;
    public Text riceLeftText, soySauceLeftText, vinegarLeftText;
    public Text joyLeftText, surfLeftText;
    public Text paylessXtraBigLeftText, luckyMeLeftText, cupNoodleLeftText;
    public Text colgateLeftText, rexonaLeftText, sunsilkLeftText;
    public Text chippyLeftText, novaLeftText, piattosLeftText;
    public Text cokeLeftText, pepsiLeftText, royalLeftText;
    public Text zestoAppleLeftText, zestoGrapeLeftText, zestoOrangeLeftText;
    public Text adoboLeftText, afritadaLeftText, flakesInOilLeftText;
    public Text cheeseSpreadLeftText, nescafeLeftText, peanutButterLeftText;
    public Text artisanLeftText, gardeniaLeftText;

    void Start()
    {
        int maxCandies = minMaxItemsDisplay.maxItemsCandies;
        int maxPantryStaples = minMaxItemsDisplay.maxItemsPantryStaples;
        int maxHouseHoldBasic = minMaxItemsDisplay.maxItemsHouseHoldBasics;
        int maxInstantNoodles = minMaxItemsDisplay.maxItemsInstantNoodles;
        int maxPersonalCare = minMaxItemsDisplay.maxItemsPersonalCare;
        int maxSnacks = minMaxItemsDisplay.maxItemsSnacks;
        int maxDrinks = minMaxItemsDisplay.maxItemsDrinks;
        int maxCannedGoods = minMaxItemsDisplay.maxItemsCannedGoods;
        int maxSpreads = minMaxItemsDisplay.maxItemsSpreads;
        int maxBreads = minMaxItemsDisplay.maxItemsBreads;

        goyaCandyLeft = maxCandies; mentosLeft = maxCandies; whiteRabbitLeft = maxCandies;
        riceLeft = maxPantryStaples; soySauceLeft = maxPantryStaples; vinegarLeft = maxPantryStaples;
        joyLeft = maxHouseHoldBasic; surfLeft = maxHouseHoldBasic;
        paylessXtraBigLeft = maxInstantNoodles; luckyMeLeft = maxInstantNoodles; cupNoodleLeft = maxInstantNoodles;
        colgateLeft = maxPersonalCare; rexonaLeft = maxPersonalCare; sunsilkLeft = maxPersonalCare;
        chippyLeft = maxSnacks; novaLeft = maxSnacks; piattosLeft = maxSnacks;
        cokeLeft = maxDrinks; pepsiLeft = maxDrinks; royalLeft = maxDrinks;
        zestoAppleLeft = maxDrinks; zestoGrapeLeft = maxDrinks; zestoOrangeLeft = maxDrinks;
        adoboLeft = maxCannedGoods; afritadaLeft = maxCannedGoods; flakesInOilLeft = maxCannedGoods;
        cheeseSpreadLeft = maxSpreads; nescafeLeft = maxSpreads; peanutButterLeft = maxSpreads;
        artisanLeft = maxBreads; gardeniaLeft = maxBreads;

        UpdateGoyaCandyLeftText(); UpdateMentosLeftText(); UpdateWhiteRabbitLeftText();
        UpdateRiceLeftText(); UpdateSoySauceLeftText(); UpdateVinegarLeftText();
        UpdateSurfLeftText(); UpdateJoyLeftText(); 
        UpdatePaylessXtraBigLeftText(); UpdateLuckyMeLeftText(); UpdateCupNoodleLeftText(); 
        UpdateColgateLeftText(); UpdateRexonaLeftText(); UpdateSunsilkLeftText();
        UpdateChippyLeftText(); UpdateNovaLeftText(); UpdatePiattosLeftText(); 
        UpdateCokeLeftText(); UpdatePepsiLeftText(); UpdateRoyalLeftText(); 
        UpdateZestoAppleLeftText(); UpdateZestoGrapeLeftText();UpdateZestoOrangeLeftText();
        UpdateAdoboLeftText(); UpdateAfritadaLeftText(); UpdateFlakesInOilLeftText();
        UpdateCheeseSpreadLeftText(); UpdateNescafeLeftText(); UpdatePeanutButterLeftText();
        UpdateArtisanLeftText(); UpdateGardeniaLeftText();
    }
    public void DecreaseGoyaCandy()
    {
        if (goyaCandyLeft > 0)
        {
            goyaCandyLeft--;

            if (minMaxItemsDisplay.GetInventoryItems("Goya Candy") > 0)
            {
                if (minMaxItemsDisplay.CheckMinimumRequirement("Goya Candy", goyaCandyLeft))
                {
                    restockScript.EnableRestockButton("Goya Candy");
                    goyaCandyLeftText.color = Color.red;
                }
            }
        }
        UpdateGoyaCandyLeftText();
    }
    public void DecreaseMentos()
    {
        if (mentosLeft > 0)
        {
            mentosLeft--;

            if (minMaxItemsDisplay.GetInventoryItems("Mentos") > 0)
            {
                if (minMaxItemsDisplay.CheckMinimumRequirement("Mentos", mentosLeft))
                {
                    restockScript.EnableRestockButton("Mentos");
                    mentosLeftText.color = Color.red;
                }
            }
        }
        UpdateMentosLeftText();
    }
    public void DecreaseWhiteRabbit()
    {
        if (whiteRabbitLeft > 0)
        {
            whiteRabbitLeft--;

            if (minMaxItemsDisplay.GetInventoryItems("White Rabbit") > 0)
            {
                if (minMaxItemsDisplay.CheckMinimumRequirement("White Rabbit", whiteRabbitLeft))
                {
                    restockScript.EnableRestockButton("White Rabbit");
                    whiteRabbitLeftText.color = Color.red;
                }
            }
        }
        UpdateWhiteRabbitLeftText();
    }
    public void DecreaseRice()
    {
        if (riceLeft > 0)
        {
            riceLeft--;

            if (minMaxItemsDisplay.GetInventoryItems("Rice") > 0)
            {
                if (minMaxItemsDisplay.CheckMinimumRequirement("Rice", riceLeft))
                {
                    restockScript.EnableRestockButton("Rice");
                    riceLeftText.color = Color.red;
                }
            }
        }
        UpdateRiceLeftText();
    }
    public void DecreaseSoySauce()
    {
        if (soySauceLeft > 0)
        {
            soySauceLeft--;

            if (minMaxItemsDisplay.GetInventoryItems("Soy Sauce") > 0)
            {
                if (minMaxItemsDisplay.CheckMinimumRequirement("Soy Sauce", soySauceLeft))
                {
                    restockScript.EnableRestockButton("Soy Sauce");
                    soySauceLeftText.color = Color.red;
                }
            }
        }
        UpdateSoySauceLeftText();
    }
    public void DecreaseVinegar()
    {
        if (vinegarLeft > 0)
        {
            vinegarLeft--;

            if (minMaxItemsDisplay.GetInventoryItems("Vinegar") > 0)
            {
                if (minMaxItemsDisplay.CheckMinimumRequirement("Vinegar", vinegarLeft))
                {
                    restockScript.EnableRestockButton("Vinegar");
                    vinegarLeftText.color = Color.red;
                }
            }
        }
        UpdateVinegarLeftText();
    }
    public void DecreaseJoy()
    {
        if (joyLeft > 0)
        {
            joyLeft--;

            if (minMaxItemsDisplay.GetInventoryItems("Joy") > 0)
            {
                if (minMaxItemsDisplay.CheckMinimumRequirement("Joy", joyLeft))
                {
                    restockScript.EnableRestockButton("Joy");
                    joyLeftText.color = Color.red;
                }
            }
        }
        
        UpdateJoyLeftText();
    }
    public void DecreaseSurf()
    {
        if (surfLeft > 0)
        {
            surfLeft--;

            if (minMaxItemsDisplay.GetInventoryItems("Surf") > 0)
            {
                if (minMaxItemsDisplay.CheckMinimumRequirement("Surf", surfLeft))
                {
                    restockScript.EnableRestockButton("Surf");
                    surfLeftText.color = Color.red;
                }
            }
        }
        
        UpdateSurfLeftText();
    }
    public void DecreasePaylessXtraBig()
    {
        if (paylessXtraBigLeft > 0)
        {
            paylessXtraBigLeft--;

            if (minMaxItemsDisplay.GetInventoryItems("Payless Xtra Big") > 0)
            {
                if (minMaxItemsDisplay.CheckMinimumRequirement("Payless Xtra Big", paylessXtraBigLeft))
                {
                    restockScript.EnableRestockButton("Payless Xtra Big");
                    paylessXtraBigLeftText.color = Color.red;
                }
            }
        }
        UpdatePaylessXtraBigLeftText();
    }
    public void DecreaseLuckyMe()
    {
        if (luckyMeLeft > 0)
        {
            luckyMeLeft--;

            if (minMaxItemsDisplay.GetInventoryItems("Lucky Me") > 0)
            {
                if (minMaxItemsDisplay.CheckMinimumRequirement("Lucky Me", luckyMeLeft))
                {
                    restockScript.EnableRestockButton("Lucky Me");
                    luckyMeLeftText.color = Color.red;
                }
            }
        }
        UpdateLuckyMeLeftText();
    }
    public void DecreaseCupNoodle()
    {
        if (cupNoodleLeft > 0)
        {
            cupNoodleLeft--;

            if (minMaxItemsDisplay.GetInventoryItems("Cup Noodle") > 0)
            {
                if (minMaxItemsDisplay.CheckMinimumRequirement("Cup Noodle", cupNoodleLeft))
                {
                    restockScript.EnableRestockButton("Cup Noodle");
                    cupNoodleLeftText.color = Color.red;
                }
            }
        }
        UpdateCupNoodleLeftText();
    }
    public void DecreaseColgate()
    {
        if (colgateLeft > 0)
        {
            colgateLeft--;

            if (minMaxItemsDisplay.GetInventoryItems("Colgate") > 0)
            {
                if (minMaxItemsDisplay.CheckMinimumRequirement("Colgate", colgateLeft))
                {
                    restockScript.EnableRestockButton("Colgate");
                    colgateLeftText.color = Color.red;
                }
            }
        }
        UpdateColgateLeftText();
    }
    public void DecreaseRexona()
    {
        if (rexonaLeft > 0)
        {
            rexonaLeft--;

            if (minMaxItemsDisplay.GetInventoryItems("Rexona") > 0)
            {
                if (minMaxItemsDisplay.CheckMinimumRequirement("Rexona", rexonaLeft))
                {
                    restockScript.EnableRestockButton("Rexona");
                    rexonaLeftText.color = Color.red;
                }
            }
        }
        UpdateRexonaLeftText();
    }
    public void DecreaseSunsilk()
    {
        if (sunsilkLeft > 0)
        {
            sunsilkLeft--;

            if (minMaxItemsDisplay.GetInventoryItems("Sunsilk") > 0)
            {
                if (minMaxItemsDisplay.CheckMinimumRequirement("Sunsilk", sunsilkLeft))
                {
                    restockScript.EnableRestockButton("Sunsilk");
                    sunsilkLeftText.color = Color.red;
                }
            }
        }
        UpdateSunsilkLeftText();
    }
    public void DecreaseChippy()
    {
        if (chippyLeft > 0)
        {
            chippyLeft--;

            if (minMaxItemsDisplay.GetInventoryItems("Chippy") > 0)
            {
                if (minMaxItemsDisplay.CheckMinimumRequirement("Chippy", chippyLeft))
                {
                    restockScript.EnableRestockButton("Chippy");
                    chippyLeftText.color = Color.red;
                }
            }
        }
        UpdateChippyLeftText();
    }
    public void DecreaseNova()
    {
        if (novaLeft > 0)
        {
            novaLeft--;

            if (minMaxItemsDisplay.GetInventoryItems("Nova") > 0)
            {
                if (minMaxItemsDisplay.CheckMinimumRequirement("Nova", novaLeft))
                {
                    restockScript.EnableRestockButton("Nova");
                    novaLeftText.color = Color.red;
                }
            }
        }
        UpdateNovaLeftText();
    }
    public void DecreasePiattos()
    {
        if (piattosLeft > 0)
        {
            piattosLeft--;

            if (minMaxItemsDisplay.GetInventoryItems("Piattos") > 0)
            {
                if (minMaxItemsDisplay.CheckMinimumRequirement("Piattos", piattosLeft))
                {
                    restockScript.EnableRestockButton("Piattos");
                    piattosLeftText.color = Color.red;
                }
            }
        }
        UpdatePiattosLeftText();
    }
    public void DecreaseCoke()
    {
        if (cokeLeft > 0)
        {
            cokeLeft--;

            if (minMaxItemsDisplay.GetInventoryItems("Coke") > 0)
            {
                if (minMaxItemsDisplay.CheckMinimumRequirement("Coke", cokeLeft))
                {
                    restockScript.EnableRestockButton("Coke");
                    cokeLeftText.color = Color.red;
                }
            }
        }
        UpdateCokeLeftText();
    }
    public void DecreasePepsi()
    {
        if (pepsiLeft > 0)
        {
            pepsiLeft--;

            if (minMaxItemsDisplay.GetInventoryItems("Pepsi") > 0)
            {
                if (minMaxItemsDisplay.CheckMinimumRequirement("Pepsi", pepsiLeft))
                {
                    restockScript.EnableRestockButton("Pepsi");
                    pepsiLeftText.color = Color.red;
                }
            }
        }
        UpdatePepsiLeftText();
    }
    public void DecreaseRoyal()
    {
        if (royalLeft > 0)
        {
            royalLeft--;

            if (minMaxItemsDisplay.GetInventoryItems("Royal") > 0)
            {
                if (minMaxItemsDisplay.CheckMinimumRequirement("Royal", royalLeft))
                {
                    restockScript.EnableRestockButton("Royal");
                    royalLeftText.color = Color.red;
                }
            }
        }
        UpdateRoyalLeftText();
    }
    public void DecreaseZestoApple()
    {
        if (zestoAppleLeft > 0)
        {
            zestoAppleLeft--;

            if (minMaxItemsDisplay.GetInventoryItems("Zesto Apple") > 0)
            {
                if (minMaxItemsDisplay.CheckMinimumRequirement("Zesto Apple", zestoAppleLeft))
                {
                    restockScript.EnableRestockButton("Zesto Apple");
                    zestoAppleLeftText.color = Color.red;
                }
            }
        }
        UpdateZestoAppleLeftText();
    }
    public void DecreaseZestoGrape()
    {
        if (zestoGrapeLeft > 0)
        {
            zestoGrapeLeft--;

            if (minMaxItemsDisplay.GetInventoryItems("Zesto Grape") > 0)
            {
                if (minMaxItemsDisplay.CheckMinimumRequirement("Zesto Grape", zestoGrapeLeft))
                {
                    restockScript.EnableRestockButton("Zesto Grape");
                    zestoGrapeLeftText.color = Color.red;
                }
            }
        }
        UpdateZestoGrapeLeftText();
    }
    public void DecreaseZestoOrange()
    {
        if (zestoOrangeLeft > 0)
        {
            zestoOrangeLeft--;

            if (minMaxItemsDisplay.GetInventoryItems("Zesto Orange") > 0)
            {
                if (minMaxItemsDisplay.CheckMinimumRequirement("Zesto Orange", zestoOrangeLeft))
                {
                    restockScript.EnableRestockButton("Zesto Orange");
                    zestoOrangeLeftText.color = Color.red;
                }
            }
        }
        UpdateZestoOrangeLeftText();
    }
    public void DecreaseAdobo()
    {
        if (adoboLeft > 0)
        {
            adoboLeft--;
            if (minMaxItemsDisplay.GetInventoryItems("Adobo") > 0)
            {
                if (minMaxItemsDisplay.CheckMinimumRequirement("Adobo", adoboLeft))
                {
                    restockScript.EnableRestockButton("Adobo");
                    adoboLeftText.color = Color.red;
                }
            }
        }
        UpdateAdoboLeftText();
    }
    public void DecreaseAfritada()
    {
        if (afritadaLeft > 0)
        {
            afritadaLeft--;
            if (minMaxItemsDisplay.GetInventoryItems("Afritada") > 0)
            {
                if (minMaxItemsDisplay.CheckMinimumRequirement("Afritada", afritadaLeft))
                {
                    restockScript.EnableRestockButton("Afritada");
                    afritadaLeftText.color = Color.red;
                }
            }
        }
        UpdateAfritadaLeftText();
    }
    public void DecreaseFlakesInOil()
    {
        if (flakesInOilLeft > 0)
        {
            flakesInOilLeft--;
            if (minMaxItemsDisplay.GetInventoryItems("Flakes in Oil") > 0)
            {
                if (minMaxItemsDisplay.CheckMinimumRequirement("Flakes in Oil", flakesInOilLeft))
                {
                    restockScript.EnableRestockButton("Flakes in Oil");
                    flakesInOilLeftText.color = Color.red;
                }
            }
        }
        UpdateFlakesInOilLeftText();
    }
    public void DecreaseCheeseSpread()
    {
        if (cheeseSpreadLeft > 0)
        {
            cheeseSpreadLeft--;
            if (minMaxItemsDisplay.GetInventoryItems("Cheese Spread") > 0)
            {
                if (minMaxItemsDisplay.CheckMinimumRequirement("Cheese Spread", cheeseSpreadLeft))
                {
                    restockScript.EnableRestockButton("Cheese Spread");
                    cheeseSpreadLeftText.color = Color.red;
                }
            }
        }
        UpdateCheeseSpreadLeftText();
    }
    public void DecreaseNescafe()
    {
        if (nescafeLeft > 0)
        {
            nescafeLeft--;
            if (minMaxItemsDisplay.GetInventoryItems("Nescafe") > 0)
            {
                if (minMaxItemsDisplay.CheckMinimumRequirement("Nescafe", nescafeLeft))
                {
                    restockScript.EnableRestockButton("Nescafe");
                    nescafeLeftText.color = Color.red;
                }
            }
        }
        UpdateNescafeLeftText();
    }
    public void DecreasePeanutButter()
    {
        if (peanutButterLeft > 0)
        {
            peanutButterLeft--;
            if (minMaxItemsDisplay.GetInventoryItems("Peanut Butter") > 0)
            {
                if (minMaxItemsDisplay.CheckMinimumRequirement("Peanut Butter", peanutButterLeft))
                {
                    restockScript.EnableRestockButton("Peanut Butter");
                    peanutButterLeftText.color = Color.red;
                }
            }
        }
        UpdatePeanutButterLeftText();
    }
    public void DecreaseArtisan()
    {
        if (artisanLeft > 0)
        {
            artisanLeft--;
            if (minMaxItemsDisplay.GetInventoryItems("Artisan") > 0)
            {
                if (minMaxItemsDisplay.CheckMinimumRequirement("Artisan", artisanLeft))
                {
                    restockScript.EnableRestockButton("Artisan");
                    artisanLeftText.color = Color.red;
                }
            }
        }
        UpdateArtisanLeftText();
    }
    public void DecreaseGardenia()
    {
        if (gardeniaLeft > 0)
        {
            gardeniaLeft--;
            if (minMaxItemsDisplay.GetInventoryItems("Gardenia") > 0)
            {
                if (minMaxItemsDisplay.CheckMinimumRequirement("Gardenia", gardeniaLeft))
                {
                    restockScript.EnableRestockButton("Gardenia");
                    gardeniaLeftText.color = Color.red;
                }
            }
        }
        UpdateGardeniaLeftText();
    }
    public void DecreaseItem(string item)
    {
        if (item.Equals("Goya Candy"))
        { DecreaseGoyaCandy(); }
        else if (item.Equals("Mentos"))
        { DecreaseMentos(); }
        else if (item.Equals("White Rabbit"))
        { DecreaseWhiteRabbit(); }
        else if (item.Equals("Rice"))
        { DecreaseRice(); }
        else if (item.Equals("Soy Sauce"))
        { DecreaseSoySauce(); }
        else if (item.Equals("Vinegar"))
        { DecreaseVinegar(); }
        else if (item.Equals("Joy"))
        { DecreaseJoy(); }
        else if (item.Equals("Surf"))
        { DecreaseSurf(); }
        else if (item.Equals("Payless Xtra Big"))
        { DecreasePaylessXtraBig(); }
        else if (item.Equals("Lucky Me"))
        { DecreaseLuckyMe(); }
        else if (item.Equals("Cup Noodle"))
        { DecreaseCupNoodle(); }
        else if (item.Equals("Colgate"))
        { DecreaseColgate(); }
        else if (item.Equals("Rexona"))
        { DecreaseRexona(); }
        else if (item.Equals("Sunsilk"))
        { DecreaseSunsilk(); }
        else if (item.Equals("Chippy"))
        { DecreaseChippy(); }
        else if (item.Equals("Nova"))
        { DecreaseNova(); }
        else if (item.Equals("Piattos"))
        { DecreasePiattos(); }
        else if (item.Equals("Coke"))
        { DecreaseCoke(); }
        else if (item.Equals("Pepsi"))
        { DecreasePepsi(); }
        else if (item.Equals("Royal"))
        { DecreaseRoyal(); }
        else if (item.Equals("Zesto Apple"))
        { DecreaseZestoApple(); }
        else if (item.Equals("Zesto Grape"))
        { DecreaseZestoGrape(); }
        else if (item.Equals("Zesto Orange"))
        { DecreaseZestoOrange(); }
        else if (item.Equals("Adobo"))
        { DecreaseAdobo(); }
        else if (item.Equals("Afritada"))
        { DecreaseAfritada(); }
        else if (item.Equals("Flakes in Oil"))
        { DecreaseFlakesInOil(); }
        else if (item.Equals("Cheese Spread"))
        { DecreaseCheeseSpread(); }
        else if (item.Equals("Nescafe"))
        { DecreaseNescafe(); }
        else if (item.Equals("Peanut Butter"))
        { DecreasePeanutButter(); }
        else if (item.Equals("Artisan"))
        { DecreaseArtisan(); }
        else if (item.Equals("Gardenia"))
        { DecreaseGardenia(); }
    }

    private void UpdateGoyaCandyLeftText()
    {
        goyaCandyLeftText.text = $"{goyaCandyLeft}";
        Debug.Log($"[ITEMSLEFT] Goya Candy left: {goyaCandyLeft}");
    }
    private void UpdateMentosLeftText()
    {
        mentosLeftText.text = $"{mentosLeft}";
        Debug.Log($"[ITEMSLEFT] Mentos left: {mentosLeft}");
    }
    private void UpdateWhiteRabbitLeftText()
    {
        whiteRabbitLeftText.text = $"{whiteRabbitLeft}";
        Debug.Log($"[ITEMSLEFT] White Rabbit left: {whiteRabbitLeft}");
    }
    private void UpdateRiceLeftText()
    {
        riceLeftText.text = $"{riceLeft}";
        Debug.Log($"[ITEMSLEFT] Rice left: {riceLeft}");
    }
    private void UpdateSoySauceLeftText()
    {
        soySauceLeftText.text = $"{soySauceLeft}";
        Debug.Log($"[ITEMSLEFT] Soy Sauce left: {soySauceLeft}");
    }
    private void UpdateVinegarLeftText()
    {
        vinegarLeftText.text = $"{vinegarLeft}";
        Debug.Log($"[ITEMSLEFT] Vinegar left: {vinegarLeft}");
    }
    private void UpdateJoyLeftText()
    {
        joyLeftText.text = $"{joyLeft}";
        Debug.Log($"[ITEMSLEFT] Joy left: {joyLeft}");
    }
    private void UpdateSurfLeftText()
    {
        surfLeftText.text = $"{surfLeft}";
        Debug.Log($"[ITEMSLEFT] Surf left: {surfLeft}");
    }
    private void UpdatePaylessXtraBigLeftText()
    {
        paylessXtraBigLeftText.text = $"{paylessXtraBigLeft}";
        Debug.Log($"[ITEMSLEFT] Payless Xtra Big left: {paylessXtraBigLeft}");
    }
    private void UpdateLuckyMeLeftText()
    {
        luckyMeLeftText.text = $"{luckyMeLeft}";
        Debug.Log($"[ITEMSLEFT] Lucky Me left: {luckyMeLeft}");
    }
    private void UpdateCupNoodleLeftText()
    {
        cupNoodleLeftText.text = $"{cupNoodleLeft}";
        Debug.Log($"[ITEMSLEFT] Cup Noodle left: {cupNoodleLeft}");
    }
    private void UpdateColgateLeftText()
    {
        colgateLeftText.text = $"{colgateLeft}";
        Debug.Log($"[ITEMSLEFT] Colgate left: {colgateLeft}");
    }
    private void UpdateRexonaLeftText()
    {
        rexonaLeftText.text = $"{rexonaLeft}";
        Debug.Log($"[ITEMSLEFT] Rexona left: {rexonaLeft}");
    }
    private void UpdateSunsilkLeftText()
    {
        sunsilkLeftText.text = $"{sunsilkLeft}";
        Debug.Log($"[ITEMSLEFT] Sunsilk left: {sunsilkLeft}");
    }
    private void UpdateChippyLeftText()
    {
        chippyLeftText.text = $"{chippyLeft}";
        Debug.Log($"[ITEMSLEFT] Chippy left: {chippyLeft}");
    }
    private void UpdateNovaLeftText()
    {
        novaLeftText.text = $"{novaLeft}";
        Debug.Log($"[ITEMSLEFT] Nova left: {novaLeft}");
    }
    private void UpdatePiattosLeftText()
    {
        piattosLeftText.text = $"{piattosLeft}";
        Debug.Log($"[ITEMSLEFT] Piattos left: {piattosLeft}");
    }
    private void UpdateCokeLeftText()
    {
        cokeLeftText.text = $"{cokeLeft}";
        Debug.Log($"[ITEMSLEFT] Coke left: {cokeLeft}");
    }
    private void UpdatePepsiLeftText()
    {
        pepsiLeftText.text = $"{pepsiLeft}";
        Debug.Log($"[ITEMSLEFT] Pepsi left: {pepsiLeft}");
    }
    private void UpdateRoyalLeftText()
    {
        royalLeftText.text = $"{royalLeft}";
        Debug.Log($"[ITEMSLEFT] Royal left: {royalLeft}");
    }
    private void UpdateZestoAppleLeftText()
    {
        zestoAppleLeftText.text = $"{zestoAppleLeft}";
        Debug.Log($"[ITEMSLEFT] Zesto Apple left: {zestoAppleLeft}");
    }
    private void UpdateZestoGrapeLeftText()
    {
        zestoGrapeLeftText.text = $"{zestoGrapeLeft}";
        Debug.Log($"[ITEMSLEFT] Zesto Grape left: {zestoGrapeLeft}");
    }
    private void UpdateZestoOrangeLeftText()
    {
        zestoOrangeLeftText.text = $"{zestoOrangeLeft}";
        Debug.Log($"[ITEMSLEFT] Zesto Orange left: {zestoOrangeLeft}");
    }
    private void UpdateAdoboLeftText()
    {
        adoboLeftText.text = $"{adoboLeft}";
        Debug.Log($"[ITEMSLEFT] Adobo left: {adoboLeft}");
    }
    private void UpdateAfritadaLeftText()
    {
        afritadaLeftText.text = $"{afritadaLeft}";
        Debug.Log($"[ITEMSLEFT] Afritada left: {afritadaLeft}");
    }
    private void UpdateFlakesInOilLeftText()
    {
        flakesInOilLeftText.text = $"{flakesInOilLeft}";
        Debug.Log($"[ITEMSLEFT] Flakes in Oil left: {flakesInOilLeft}");
    }
    private void UpdateCheeseSpreadLeftText()
    {
        cheeseSpreadLeftText.text = $"{cheeseSpreadLeft}";
        Debug.Log($"[ITEMSLEFT] Cheese Spread left: {cheeseSpreadLeft}");
    }
    private void UpdateNescafeLeftText()
    {
        nescafeLeftText.text = $"{nescafeLeft}";
        Debug.Log($"[ITEMSLEFT] Nescafe left: {nescafeLeft}");
    }
    private void UpdatePeanutButterLeftText()
    {
        peanutButterLeftText.text = $"{peanutButterLeft}";
        Debug.Log($"[ITEMSLEFT] Peanut Butter left: {peanutButterLeft}");
    }
    private void UpdateArtisanLeftText()
    {
        artisanLeftText.text = $"{artisanLeft}";
        Debug.Log($"[ITEMSLEFT] Artisan left: {artisanLeft}");
    }
    private void UpdateGardeniaLeftText()
    {
        gardeniaLeftText.text = $"{gardeniaLeft}";
        Debug.Log($"[ITEMSLEFT] Gardenia left: {gardeniaLeft}");
    }

    public void SetGoyaCandyLeft(int goyaCandyLeft)
    {
        this.goyaCandyLeft = goyaCandyLeft;
        UpdateGoyaCandyLeftText();
    }
    public void SetMentosLeft(int mentosLeft)
    {
        this.mentosLeft = mentosLeft;
        UpdateMentosLeftText();
    }
    public void SetWhiteRabbitLeft(int whiteRabbitLeft)
    {
        this.whiteRabbitLeft = whiteRabbitLeft;
        UpdateWhiteRabbitLeftText();
    }
    public void SetRiceLeft(int riceLeft)
    {
        this.riceLeft = riceLeft;
        UpdateRiceLeftText();
    }
    public void SetSoySauceLeft(int soySauceLeft)
    {
        this.soySauceLeft = soySauceLeft;
        UpdateSoySauceLeftText();
    }
    public void SetVinegarLeft(int vinegarLeft)
    {
        this.vinegarLeft = vinegarLeft;
        UpdateVinegarLeftText();
    }
    public void SetJoyLeft(int joyLeft)
    {
        this.joyLeft = joyLeft;
        UpdateJoyLeftText();
    }
    public void SetSurfLeft(int surfLeft)
    {
        this.surfLeft = surfLeft;
        UpdateSurfLeftText();
    }
    public void SetPaylessXtraBigLeft(int paylessXtraBigLeft)
    {
        this.paylessXtraBigLeft = paylessXtraBigLeft;
        UpdatePaylessXtraBigLeftText();
    }
    public void SetLuckyMeLeft(int luckyMeLeft)
    {
        this.luckyMeLeft = luckyMeLeft;
        UpdateLuckyMeLeftText();
    }
    public void SetCupNoodleLeft(int cupNoodleLeft)
    {
        this.cupNoodleLeft = cupNoodleLeft;
        UpdateCupNoodleLeftText();
    }
    public void SetColgateLeft(int colgateLeft)
    {
        this.colgateLeft = colgateLeft;
        UpdateColgateLeftText();
    }
    public void SetRexonaLeft(int rexonaLeft)
    {
        this.rexonaLeft = rexonaLeft;
        UpdateRexonaLeftText();
    }
    public void SetSunsilkLeft(int sunsilkLeft)
    {
        this.sunsilkLeft = sunsilkLeft;
        UpdateSunsilkLeftText();
    }
    public void SetChippyLeft(int chippyLeft)
    {
        this.chippyLeft = chippyLeft;
        UpdateChippyLeftText();
    }
    public void SetNovaLeft(int novaLeft)
    {
        this.novaLeft = novaLeft;
        UpdateNovaLeftText();
    }
    public void SetPiattosLeft(int piattosLeft)
    {
        this.piattosLeft = piattosLeft;
        UpdatePiattosLeftText();
    }
    public void SetCokeLeft(int cokeLeft)
    {
        this.cokeLeft = cokeLeft;
        UpdateCokeLeftText();
    }
    public void SetPepsiLeft(int pepsiLeft)
    {
        this.pepsiLeft = pepsiLeft;
        UpdatePepsiLeftText();
    }
    public void SetRoyalLeft(int royalLeft)
    {
        this.royalLeft = royalLeft;
        UpdateRoyalLeftText();
    }
    public void SetZestoAppleLeft(int zestoAppleLeft)
    {
        this.zestoAppleLeft = zestoAppleLeft;
        UpdateZestoAppleLeftText();
    }
    public void SetZestoGrapeLeft(int zestoGrapeLeft)
    {
        this.zestoGrapeLeft = zestoGrapeLeft;
        UpdateZestoGrapeLeftText();
    }
    public void SetZestoOrangeLeft(int zestoOrangeLeft)
    {
        this.zestoOrangeLeft = zestoOrangeLeft;
        UpdateZestoOrangeLeftText();
    }
    public void SetAdoboLeft(int adoboLeft)
    {
        this.adoboLeft = adoboLeft;
        UpdateAdoboLeftText();
    }
    public void SetAfritadaLeft(int afritadaLeft)
    {
        this.afritadaLeft = afritadaLeft;
        UpdateAfritadaLeftText();
    }
    public void SetFlakesInOilLeft(int flakesInOilLeft)
    {
        this.flakesInOilLeft = flakesInOilLeft;
        UpdateFlakesInOilLeftText();
    }
    public void SetCheeseSpreadLeft(int cheeseSpreadLeft)
    {
        this.cheeseSpreadLeft = cheeseSpreadLeft;
        UpdateCheeseSpreadLeftText();
    }
    public void SetNescafeLeft(int nescafeLeft)
    {
        this.nescafeLeft = nescafeLeft;
        UpdateNescafeLeftText();
    }
    public void SetPeanutButterLeft(int peanutButterLeft)
    {
        this.peanutButterLeft = peanutButterLeft;
        UpdatePeanutButterLeftText();
    }
    public void SetArtisanLeft(int artisanLeft)
    {
        this.artisanLeft = artisanLeft;
        UpdateArtisanLeftText();
    }
    public void SetGardeniaLeft(int gardeniaLeft)
    {
        this.gardeniaLeft = gardeniaLeft;
        UpdateGardeniaLeftText();
    }

    public void SetItemNameLeft(string itemName, int quantityLeft)
    {
        if (itemName.Equals("Goya Candy"))
        { SetGoyaCandyLeft(quantityLeft); }
        else if (itemName.Equals("Mentos"))
        { SetMentosLeft(quantityLeft); }
        else if (itemName.Equals("White Rabbit"))
        { SetWhiteRabbitLeft(quantityLeft); }
        else if (itemName.Equals("Rice"))
        { SetRiceLeft(quantityLeft); }
        else if (itemName.Equals("Soy Sauce"))
        { SetSoySauceLeft(quantityLeft); }
        else if (itemName.Equals("Vinegar"))
        { SetVinegarLeft(quantityLeft); }
        else if (itemName.Equals("Joy"))
        { SetJoyLeft(quantityLeft); }
        else if (itemName.Equals("Surf"))
        { SetSurfLeft(quantityLeft); }
        else if (itemName.Equals("Payless Xtra Big"))
        { SetPaylessXtraBigLeft(quantityLeft); }
        else if (itemName.Equals("Lucky Me"))
        { SetLuckyMeLeft(quantityLeft); }
        else if (itemName.Equals("Cup Noodle"))
        { SetCupNoodleLeft(quantityLeft); }
        else if (itemName.Equals("Colgate"))
        { SetColgateLeft(quantityLeft); }
        else if (itemName.Equals("Rexona"))
        { SetRexonaLeft(quantityLeft); }
        else if (itemName.Equals("Sunsilk"))
        { SetSunsilkLeft(quantityLeft); }
        else if (itemName.Equals("Chippy"))
        { SetChippyLeft(quantityLeft); }
        else if (itemName.Equals("Nova"))
        { SetNovaLeft(quantityLeft); }
        else if (itemName.Equals("Piattos"))
        { SetPiattosLeft(quantityLeft); }
        else if (itemName.Equals("Coke"))
        { SetCokeLeft(quantityLeft); }
        else if (itemName.Equals("Pepsi"))
        { SetPepsiLeft(quantityLeft); }
        else if (itemName.Equals("Royal"))
        { SetRoyalLeft(quantityLeft); }
        else if (itemName.Equals("Zesto Apple"))
        { SetZestoAppleLeft(quantityLeft); }
        else if (itemName.Equals("Zesto Grape"))
        { SetZestoGrapeLeft(quantityLeft); }
        else if (itemName.Equals("Zesto Orange"))
        { SetZestoOrangeLeft(quantityLeft); }
        else if (itemName.Equals("Adobo"))
        { SetAdoboLeft(quantityLeft); }
        else if (itemName.Equals("Afritada"))
        { SetAfritadaLeft(quantityLeft); }
        else if (itemName.Equals("Flakes in Oil"))
        { SetFlakesInOilLeft(quantityLeft); }
        else if (itemName.Equals("Cheese Spread"))
        { SetCheeseSpreadLeft(quantityLeft); }
        else if (itemName.Equals("Nescafe"))
        { SetNescafeLeft(quantityLeft); }
        else if (itemName.Equals("Peanut Butter"))
        { SetPeanutButterLeft(quantityLeft); }
        else if (itemName.Equals("Artisan"))
        { SetArtisanLeft(quantityLeft); }
        else if (itemName.Equals("Gardenia"))
        { SetGardeniaLeft(quantityLeft); }
    }

    public int GetGoyaCandyLeft()
    { return goyaCandyLeft; }
    public int GetMentosLeft()
    { return mentosLeft; }
    public int GetWhiteRabbitLeft()
    { return whiteRabbitLeft; }
    public int GetRiceLeft() 
    { return riceLeft; }
    public int GetSoySauceLeft() 
    { return soySauceLeft; }
    public int GetVinegarLeft() 
    { return vinegarLeft; }
    public int GetJoyLeft() 
    { return joyLeft; }
    public int GetSurfLeft() 
    { return surfLeft; }
    public int GetPaylessXtraBigLeft() 
    { return paylessXtraBigLeft; }
    public int GetLuckyMeLeft() 
    { return luckyMeLeft; }
    public int GetCupNoodleLeft() 
    { return cupNoodleLeft; }
    public int GetColgateLeft() 
    { return colgateLeft; }
    public int GetRexonaLeft() 
    { return rexonaLeft; }
    public int GetSunsilkLeft() 
    { return sunsilkLeft; }
    public int GetChippyLeft() 
    { return chippyLeft; }
    public int GetNovaLeft() 
    { return novaLeft; }
    public int GetPiattosLeft() 
    { return piattosLeft; }
    public int GetCokeLeft() 
    { return cokeLeft; }
    public int GetPepsiLeft() 
    { return pepsiLeft; }
    public int GetRoyalLeft() 
    { return royalLeft; }
    public int GetZestoAppleLeft() 
    { return zestoAppleLeft; }
    public int GetZestoGrapeLeft() 
    { return zestoGrapeLeft; }
    public int GetZestoOrangeLeft() 
    { return zestoOrangeLeft; }
    public int GetAdoboLeft() 
    { return adoboLeft; }
    public int GetAfritadaLeft() 
    { return afritadaLeft; }
    public int GetFlakesInOilLeft() 
    { return flakesInOilLeft; }
    public int GetCheeseSpreadLeft() 
    { return cheeseSpreadLeft; }
    public int GetNescafeLeft() 
    { return nescafeLeft; }
    public int GetPeanutButterLeft() 
    { return peanutButterLeft; }
    public int GetArtisanLeft() 
    { return artisanLeft; }
    public int GetGardeniaLeft() 
    { return gardeniaLeft; }
}

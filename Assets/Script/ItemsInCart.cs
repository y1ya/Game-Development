using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ItemsInCart : MonoBehaviour
{
    private int totalItems = 0;
    public Text totalItemsText;

    private int totalGoyaCandy = 0; 
    private int totalMentos = 0;
    private int totalWhiteRabbit = 0;
    private int totalRice = 0;
    private int totalSoySauce = 0;
    private int totalVinegar = 0;
    private int totalJoy = 0;
    private int totalSurf = 0;
    private int totalPaylessXtraBig = 0;
    private int totalLuckyMe = 0;
    private int totalCupNoodle = 0;
    private int totalColgate = 0;
    private int totalRexona = 0;
    private int totalSunsilk = 0;
    private int totalChippy = 0;
    private int totalNova = 0;
    private int totalPiattos = 0;
    private int totalCoke = 0;
    private int totalPepsi = 0;
    private int totalRoyal = 0;
    private int totalZestoApple = 0;
    private int totalZestoGrape = 0;
    private int totalZestoOrange = 0;
    private int totalAdobo = 0;
    private int totalAfritada = 0;
    private int totalFlakesInOil = 0;
    private int totalCheeseSpread = 0;
    private int totalNescafe = 0;
    private int totalPeanutButter = 0;
    private int totalArtisan = 0;
    private int totalGardenia = 0;

    public Text totalGoyaCandyText, totalMentosText, totalWhiteRabbitText,
        totalRiceText, totalSoySauceText, totalVinegarText,
        totalJoyText, totalSurfText,
        totalPaylessXtraBigText, totalLuckyMeText, totalCupNoodleText,
        totalColgateText, totalRexonaText, totalSunsilkText,
        totalChippyText, totalNovaText, totalPiattosText,
        totalCokeText, totalPepsiText, totalRoyalText,
        totalZestoAppleText, totalZestoGrapeText, totalZestoOrangeText,
        totalAdoboText, totalAfritadaText, totalFlakesInOilText,
        totalCheeseSpreadText, totalNescafeText, totalPeanutButerText,
        totalArtisanText, totalGardeniaText;

    private List<string> cartItems = new List<string>();

    public ItemsLeft itemsLeft;
    public void AddItem(string ItemName)
    {
        cartItems.Add(ItemName);
        Debug.Log("Added to cart: " + ItemName);

        if (ItemName.Equals("Goya Candy"))
        { totalGoyaCandy++; Debug.Log($"Added Goya Candy to Cart"); }
        else if (ItemName.Equals("Mentos"))
        { totalMentos++; Debug.Log($"Added Mentos to Cart"); }
        else if (ItemName.Equals("White Rabbit"))
        { totalWhiteRabbit++; Debug.Log($"Added White Rabbit to Cart"); }
        else if (ItemName.Equals("Rice"))
        { totalRice++; Debug.Log($"Added Rice to Cart"); }
        else if (ItemName.Equals("Soy Sauce"))
        { totalSoySauce++; Debug.Log($"Added Soy Sauce to Cart"); }
        else if (ItemName.Equals("Vinegar"))
        { totalVinegar++; Debug.Log($"Added Vinegar to Cart"); }
        else if (ItemName.Equals("Joy"))
        { totalJoy++; Debug.Log($"Added Joy to Cart"); }
        else if (ItemName.Equals("Surf"))
        { totalSurf++; Debug.Log($"Added Surf to Cart"); }
        else if (ItemName.Equals("Payless Xtra Big"))
        { totalPaylessXtraBig++; Debug.Log($"Added Payless Xtra Big to Cart"); }
        else if (ItemName.Equals("Lucky Me"))
        { totalLuckyMe++; Debug.Log($"Added Lucky Me to Cart"); }
        else if (ItemName.Equals("Cup Noodle"))
        { totalCupNoodle++; Debug.Log($"Added Cup Noodle to Cart"); }
        else if (ItemName.Equals("Colgate"))
        { totalColgate++; Debug.Log($"Added Colgate to Cart"); }
        else if (ItemName.Equals("Rexona"))
        { totalRexona++; Debug.Log($"Added Rexona to Cart"); }
        else if (ItemName.Equals("Sunsilk"))
        { totalSunsilk++; Debug.Log($"Added Sunsilk to Cart"); }
        else if (ItemName.Equals("Chippy"))
        { totalChippy++; Debug.Log($"Added Chippy to Cart"); }
        else if (ItemName.Equals("Nova"))
        { totalNova++; Debug.Log($"Added Nova to Cart"); }
        else if (ItemName.Equals("Piattos"))
        { totalPiattos++; Debug.Log($"Added Piattos to Cart"); }
        else if (ItemName.Equals("Coke"))
        { totalCoke++; Debug.Log($"Added Coke to Cart"); }
        else if (ItemName.Equals("Pepsi"))
        { totalPepsi++; Debug.Log($"Added Pepsi to Cart"); }
        else if (ItemName.Equals("Royal"))
        { totalRoyal++; Debug.Log($"Added Royal to Cart"); }
        else if (ItemName.Equals("Zesto Apple"))
        { totalZestoApple++; Debug.Log($"Added Zesto Apple to Cart"); }
        else if (ItemName.Equals("Zesto Grape"))
        { totalZestoGrape++; Debug.Log($"Added Zesto Grape to Cart"); }
        else if (ItemName.Equals("Zesto Orange"))
        { totalZestoOrange++; Debug.Log($"Added Zesto Orange to Cart"); }
        else if (ItemName.Equals("Adobo"))
        { totalAdobo++; Debug.Log($"Added Adobo to Cart"); }
        else if (ItemName.Equals("Afritada"))
        { totalAfritada++; Debug.Log($"Added Afritada to Cart"); }
        else if (ItemName.Equals("Flakes in Oil"))
        { totalFlakesInOil++; Debug.Log($"Added Flakes in Oil to Cart"); }
        else if (ItemName.Equals("Cheese Spread"))
        { totalCheeseSpread++; Debug.Log($"Added Cheese Spread to Cart"); }
        else if (ItemName.Equals("Nescafe"))
        { totalNescafe++; Debug.Log($"Added Nescafe to Cart"); }
        else if (ItemName.Equals("Peanut Butter"))
        { totalPeanutButter++; Debug.Log($"Added Peanut Butter to Cart"); }
        else if (ItemName.Equals("Artisan"))
        { totalArtisan++; Debug.Log($"Added Artisan to Cart"); }
        else if (ItemName.Equals("Gardenia"))
        { totalGardenia++; Debug.Log($"Added Gardenia to Cart"); }

        AddItemsInCart();
    }
    public void AddItemsInCart()
    {
        totalItems++;
        UpdateTotalText();
    }

    public void UpdateTotalText()
    {
        if (totalItems >= 0)
        {
            if (totalGoyaCandy > 0)
            { totalGoyaCandyText.enabled = true; }
            else { totalGoyaCandyText.enabled = false; }

            if (totalMentos > 0)
            { totalMentosText.enabled = true; }
            else { totalMentosText.enabled = false; }

            if (totalWhiteRabbit > 0)
            { totalWhiteRabbitText.enabled = true; }
            else { totalWhiteRabbitText.enabled = false; }

            if (totalRice > 0)
            { totalRiceText.enabled = true; }
            else { totalRiceText.enabled = false; }

            if (totalSoySauce > 0)
            { totalSoySauceText.enabled = true; }
            else { totalSoySauceText.enabled = false; }

            if (totalVinegar > 0)
            { totalVinegarText.enabled = true; }
            else { totalVinegarText.enabled = false; }

            if (totalJoy > 0)
            { totalJoyText.enabled = true; }
            else { totalJoyText.enabled = false; }

            if (totalSurf > 0)
            { totalSurfText.enabled = true; }
            else { totalSurfText.enabled = false; }

            if (totalPaylessXtraBig > 0)
            { totalPaylessXtraBigText.enabled = true; }
            else { totalPaylessXtraBigText.enabled = false; }

            if (totalLuckyMe > 0)
            { totalLuckyMeText.enabled = true; }
            else { totalLuckyMeText.enabled = false; }

            if (totalCupNoodle > 0)
            { totalCupNoodleText.enabled = true; }
            else { totalCupNoodleText.enabled = false; }

            if (totalColgate > 0)
            { totalColgateText.enabled = true; }
            else { totalColgateText.enabled = false; }

            if (totalRexona > 0)
            { totalRexonaText.enabled = true; }
            else { totalRexonaText.enabled = false; }

            if (totalSunsilk > 0)
            { totalSunsilkText.enabled = true; }
            else { totalSunsilkText.enabled = false; }

            if (totalChippy > 0)
            { totalChippyText.enabled = true; }
            else { totalChippyText.enabled = false; }

            if (totalNova > 0)
            { totalNovaText.enabled = true; }
            else { totalNovaText.enabled = false; }

            if (totalPiattos > 0)
            { totalPiattosText.enabled = true; }
            else { totalPiattosText.enabled = false; }

            if (totalCoke > 0)
            { totalCokeText.enabled = true; }
            else { totalCokeText.enabled = false; }

            if (totalPepsi > 0)
            { totalPepsiText.enabled = true; }
            else { totalPepsiText.enabled = false; }

            if (totalRoyal > 0)
            { totalRoyalText.enabled = true; }
            else { totalRoyalText.enabled = false; }

            if (totalZestoApple > 0)
            { totalZestoAppleText.enabled = true; }
            else { totalZestoAppleText.enabled = false; }

            if (totalZestoGrape > 0)
            { totalZestoGrapeText.enabled = true; }
            else { totalZestoGrapeText.enabled = false; }

            if (totalZestoOrange > 0)
            { totalZestoOrangeText.enabled = true; }
            else { totalZestoOrangeText.enabled = false; }

            if (totalAdobo > 0)
            { totalAdoboText.enabled = true; }
            else { totalAdoboText.enabled = false; }

            if (totalAfritada > 0)
            { totalAfritadaText.enabled = true; }
            else { totalAfritadaText.enabled = false; }

            if (totalFlakesInOil > 0)
            { totalFlakesInOilText.enabled = true; }
            else { totalFlakesInOilText.enabled = false; }

            if (totalCheeseSpread > 0)
            { totalCheeseSpreadText.enabled = true; }
            else { totalCheeseSpreadText.enabled = false; }

            if (totalNescafe > 0)
            { totalNescafeText.enabled = true; }
            else { totalNescafeText.enabled = false; }

            if (totalPeanutButter > 0)
            { totalPeanutButerText.enabled = true; }
            else { totalPeanutButerText.enabled = false; }

            if (totalArtisan > 0)
            { totalArtisanText.enabled = true; }
            else { totalArtisanText.enabled = false; }

            if (totalGardenia > 0)
            { totalGardeniaText.enabled = true; }
            else { totalGardeniaText.enabled = false; }
        }

        totalItemsText.text = $"Total Items: {totalItems}";
        totalGoyaCandyText.text = $"Goya: {totalGoyaCandy}";
        totalMentosText.text = $"Mentos: {totalMentos}";
        totalWhiteRabbitText.text = $"White Rabbit: {totalWhiteRabbit}";
        totalRiceText.text = $"Rice: {totalRice}";
        totalSoySauceText.text = $"Soy Sauce: {totalSoySauce}";
        totalVinegarText.text = $"Vinegar: {totalVinegar}";
        totalJoyText.text = $"Joy: {totalJoy}";
        totalSurfText.text = $"Surf: {totalSurf}";
        totalPaylessXtraBigText.text = $"Payless Xtra Big: {totalPaylessXtraBig}";
        totalLuckyMeText.text = $"Lucky Me: {totalLuckyMe}";
        totalCupNoodleText.text = $"Cup Noodle: {totalCupNoodle}";
        totalColgateText.text = $"Colgate: {totalColgate}";
        totalRexonaText.text = $"Rexona: {totalRexona}";
        totalSunsilkText.text = $"Sunsilk: {totalSunsilk}";
        totalChippyText.text = $"Chippy: {totalChippy}";
        totalNovaText.text = $"Nova: {totalNova}";
        totalPiattosText.text = $"Piattos: {totalPiattos}";
        totalCokeText.text = $"Coke: {totalCoke}";
        totalPepsiText.text = $"Pepsi: {totalPepsi}";
        totalRoyalText.text = $"Royal: {totalRoyal}";
        totalZestoAppleText.text = $"Zesto Apple: {totalZestoApple}";
        totalZestoGrapeText.text = $"Zesto Grape: {totalZestoGrape}";
        totalZestoOrangeText.text = $"Zesto Orange: {totalZestoOrange}";
        totalAdoboText.text = $"Adobo: {totalAdobo}";
        totalAfritadaText.text = $"Afritada: {totalAfritada}";
        totalFlakesInOilText.text = $"Flakes in Oil: {totalFlakesInOil}";
        totalCheeseSpreadText.text = $"Cheese Spread: {totalCheeseSpread}";
        totalNescafeText.text = $"Nescafe: {totalNescafe}";
        totalPeanutButerText.text = $"Peanut Butter: {totalPeanutButter}";
        totalArtisanText.text = $"Artisan: {totalArtisan}";
        totalGardeniaText.text = $"Gardenia: {totalGardenia}";
    }

    public void ClearCart()
    {
        cartItems.Clear();

        totalItems = 0;
        
        totalGoyaCandy = 0; totalMentos = 0; totalWhiteRabbit = 0;
        
        totalRice = 0; totalSoySauce = 0; totalVinegar = 0;

        totalJoy = 0; totalSurf = 0;

        totalPaylessXtraBig = 0; totalLuckyMe = 0; totalCupNoodle = 0;

        totalColgate = 0; totalRexona = 0; totalSunsilk = 0;

        totalChippy = 0; totalNova = 0; totalPiattos = 0;

        totalCoke = 0; totalPepsi = 0; totalRoyal = 0;

        totalZestoApple = 0; totalZestoGrape = 0; totalZestoOrange = 0;

        totalAdobo = 0; totalAfritada = 0; totalFlakesInOil = 0;

        totalCheeseSpread = 0; totalNescafe = 0; totalPeanutButter = 0;

        totalArtisan = 0; totalGardenia = 0;

        UpdateTotalText();
    }
    public int GetTotalItems()
    { return totalItems; }

    public List<string> GetCartItems()
    { return cartItems; }

    public int GetTotalGoyaCandy()
    { return totalGoyaCandy; }
    public int GetTotalMentos() 
    { return totalMentos; }
    public int GetTotalWhiteRabbit() 
    { return totalWhiteRabbit; }
    public int GetTotalRice() 
    { return totalRice; }
    public int GetTotalSoySauce() 
    { return totalSoySauce; }
    public int GetTotalVinegar() 
    { return totalVinegar; }
    public int GetTotalJoy() 
    { return totalJoy; }
    public int GetTotalSurf() 
    { return totalSurf; }
    public int GetTotalPaylessXtraBig() 
    { return totalPaylessXtraBig; }
    public int GetTotalLuckyMe() 
    { return totalLuckyMe; }
    public int GetTotalCupNoodle() 
    { return totalCupNoodle; }
    public int GetTotalColgate() 
    { return totalColgate; }
    public int GetTotalRexona() 
    { return totalRexona; }
    public int GetTotalSunsilk() 
    { return totalSunsilk; }
    public int GetTotalChippy() 
    { return totalChippy; }
    public int GetTotalNova() 
    { return totalNova; }
    public int GetTotalPiattos() 
    { return totalPiattos; }
    public int GetTotalCoke() 
    { return totalCoke; }
    public int GetTotalPepsi() 
    { return totalPepsi; }
    public int GetTotalRoyal() 
    { return totalRoyal; }
    public int GetTotalZestoApple() 
    { return totalZestoApple; }
    public int GetTotalZestoGrape() 
    { return totalZestoGrape; }
    public int GetTotalZestoOrange() 
    { return totalZestoOrange; }
    public int GetTotalAdobo() 
    { return totalAdobo; }
    public int GetTotalAfritada() 
    { return totalAfritada; }
    public int GetTotalFlakesInOil() 
    { return totalFlakesInOil; }
    public int GetTotalCheeseSpread() 
    { return totalCheeseSpread; }
    public int GetTotalNescafe() 
    { return totalNescafe; }
    public int GetTotalPeanutButter() 
    { return totalPeanutButter; }
    public int GetTotalArtisan() 
    { return totalArtisan; }
    public int GetTotalGardenia() 
    { return totalGardenia; }
}

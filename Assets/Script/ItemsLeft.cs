using UnityEngine;
using UnityEngine.UI;

public class ItemsLeft : MonoBehaviour
{
    private int goyaCandyLeft, mentosLeft, whiteRabbitLeft;
    private int riceLeft, soySauceLeft, vinegarLeft;
    private int joyLeft, surfLeft;
    private int paylessXtraBigLeft, luckyMeLeft, cupNoodleLeft;
    private int colgateLeft, rexonaLeft, sunsilkLeft;
    private int chippyLeft, novaLeft, piattosLeft;
    private int cokeLeft, pepsiLeft, royalLeft;
    private int zestoAppleLeft, zestoGrapeLeft, zestoOrangeLeft;

    public GameObject joyItem, surfItem;

    public Text goyaCandyLeftText, mentosLeftText, whiteRabbitLeftText;
    public Text riceLeftText, soySauceLeftText, vinegarLeftText;
    public Text joyLeftText, surfLeftText;
    public Text paylessXtraBigLeftText, luckyMeLeftText, cupNoodleLeftText;
    public Text colgateLeftText, rexonaLeftText, sunsilkLeftText;
    public Text chippyLeftText, novaLeftText, piattosLeftText;
    public Text cokeLeftText, spriteLeftText, royalLeftText;
    public Text zestoAppleLeftText, zestoGrapeLeftText, zestoOrangeLeftText; 

    void Start()
    {
        goyaCandyLeft = 10;
        mentosLeft = 10;
        whiteRabbitLeft = 10;
        riceLeft = 10;
        soySauceLeft = 10;
        vinegarLeft = 10;
        joyLeft = 10;
        surfLeft = 10;
        paylessXtraBigLeft = 10;
        luckyMeLeft = 10;
        cupNoodleLeft = 10;
        colgateLeft = 10;
        rexonaLeft = 10;
        sunsilkLeft = 10;
        chippyLeft = 10;
        novaLeft = 10;
        piattosLeft = 10;
        cokeLeft = 10;
        pepsiLeft = 10;
        royalLeft = 10;
        zestoAppleLeft = 10;
        zestoGrapeLeft = 10;
        zestoOrangeLeft = 10;

        UpdateGoyaCandyLeftText();
        UpdateMentosLeftText();
        UpdateWhiteRabbitLeftText();
        UpdateRiceLeftText();
        UpdateSoySauceLeftText();
        UpdateVinegarLeftText();
        UpdateSurfLeftText();
        UpdateJoyLeftText();
        UpdatePaylessXtraBigLeftText();
        UpdateLuckyMeLeftText();
        UpdateCupNoodleLeftText();
        UpdateColgateLeftText();
        UpdateRexonaLeftText();
        UpdateSunsilkLeftText();
        UpdateChippyLeftText();
        UpdateNovaLeftText();
        UpdatePiattosLeftText();
        UpdateCokeLeftText();
        UpdatePepsiLeftText();
        UpdateRoyalLeftText();
        UpdateZestoAppleLeftText();
        UpdateZestoGrapeLeftText();
        UpdateZestoOrangeLeftText();
    }
    public void DecreaseGoyaCandy()
    {
        if (goyaCandyLeft > 0)
        {
            goyaCandyLeft--;
        }
        UpdateGoyaCandyLeftText();
    }
    public void DecreaseMentos()
    {
        if (mentosLeft > 0)
        {
            mentosLeft--;
        }

        UpdateMentosLeftText();
    }
    public void DecreaseWhiteRabbit()
    {
        if (whiteRabbitLeft > 0)
        {
            whiteRabbitLeft--;
        }
        UpdateWhiteRabbitLeftText();
    }
    public void DecreaseRice()
    {
        if (riceLeft > 0)
        {
            riceLeft--;
        }
        UpdateRiceLeftText();
    }
    public void DecreaseSoySauce()
    {
        if (soySauceLeft > 0)
        {
            soySauceLeft--;
        }
        UpdateSoySauceLeftText();
    }
    public void DecreaseVinegar()
    {
        if (vinegarLeft > 0)
        {
            vinegarLeft--;
        }
        UpdateVinegarLeftText();
    }
    public void DecreaseJoy()
    {
        if (joyLeft > 0)
        {
            joyLeft--;
        }
        
        UpdateJoyLeftText();
    }
    public void DecreaseSurf()
    {
        if (surfLeft > 0)
        {
            surfLeft--;
        }
        
        UpdateSurfLeftText();
    }
    public void DecreasePaylessXtraBig()
    {
        if (paylessXtraBigLeft > 0)
        {
            paylessXtraBigLeft--;
        }
        UpdatePaylessXtraBigLeftText();
    }
    public void DecreaseLuckyMe()
    {
        if (luckyMeLeft > 0)
        {
            luckyMeLeft--;
        }
        UpdateLuckyMeLeftText();
    }
    public void DecreaseCupNoodle()
    {
        if (cupNoodleLeft > 0)
        {
            cupNoodleLeft--;
        }
        UpdateCupNoodleLeftText();
    }
    public void DecreaseColgate()
    {
        if (colgateLeft > 0)
        {
            colgateLeft--;
        }
        UpdateColgateLeftText();
    }
    public void DecreaseRexona()
    {
        if (rexonaLeft > 0)
        {
            rexonaLeft--;
        }
        UpdateRexonaLeftText();
    }
    public void DecreaseSunsilk()
    {
        if (sunsilkLeft > 0)
        {
            sunsilkLeft--;
        }
        UpdateSunsilkLeftText();
    }
    public void DecreaseChippy()
    {
        if (chippyLeft > 0)
        {
            chippyLeft--;
        }
        UpdateChippyLeftText();
    }
    public void DecreaseNova()
    {
        if (novaLeft > 0)
        {
            novaLeft--;
        }
        UpdateNovaLeftText();
    }
    public void DecreasePiattos()
    {
        if (piattosLeft > 0)
        {
            piattosLeft--;
        }
        UpdatePiattosLeftText();
    }
    public void DecreaseCoke()
    {
        if (cokeLeft > 0)
        {
            cokeLeft--;
        }
        UpdateCokeLeftText();
    }
    public void DecreasePepsi()
    {
        if (pepsiLeft > 0)
        {
            pepsiLeft--;
        }
        UpdatePepsiLeftText();
    }
    public void DecreaseRoyal()
    {
        if (royalLeft > 0)
        {
            royalLeft--;
        }
        UpdateRoyalLeftText();
    }
    public void DecreaseZestoApple()
    {
        if (zestoAppleLeft > 0)
        {
            zestoAppleLeft--;
        }
        UpdateZestoAppleLeftText();
    }
    public void DecreaseZestoGrape()
    {
        if (zestoGrapeLeft > 0)
        {
            zestoGrapeLeft--;
        }
        UpdateZestoGrapeLeftText();
    }
    public void DecreaseZestoOrange()
    {
        if (zestoOrangeLeft > 0)
        {
            zestoOrangeLeft--;
        }
        UpdateZestoOrangeLeftText();
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
        spriteLeftText.text = $"{pepsiLeft}";
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
}

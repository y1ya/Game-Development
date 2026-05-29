using UnityEngine;

public class ItemPrice : MonoBehaviour
{
    public float goyaCandyPrice = 2.00f;
    public float mentosPrice = 5.0f;
    public float ricePrice = 13.00f;
    public float soySaucePrice = 3.00f;
    public float vinegarPrice = 2.50f;
    public float whiteRabbitPrice = 0.25f;
    public float surfPrice = 2.00f;
    public float joyPrice = 2.00f;
    public float paylessXtraBigPrice = 6.00f;
    public float luckyMePrice = 5.00f;
    public float cupNoodlePrice = 12.00f;
    public float colgatePrice = 3.00f;
    public float rexonaPrice = 15.00f;
    public float sunsilkPrice = 2.00f;
    public float chippyPrice = 5.00f;
    public float novaPrice = 6.00f;
    public float piattosPrice = 7.00f;
    public float cokePrice = 7.00f;
    public float pepsiPrice = 6.00f;
    public float royalPrice = 6.00f;
    public float zestoApplePrice = 3.00f;
    public float zestoGrapePrice = 3.00f;
    public float zestoOrangePrice = 4.00f;
    public float adoboPrice = 7.00f;
    public float afritadaPrice = 7.00f;
    public float flakesInOil = 7.00f;
    public float cheeseSpreadPrice = 15.00f;
    public float nescafePrice = 15.00f;
    public float peanutButterPrice = 15.00f;
    public float artisanPrice = 25.00f;
    public float gardeniaPrice = 25.00f;

    private float totalPrice = 0f;

    public float GetPrice(string itemName)
    {
        switch (itemName.ToLower())
        {
            case "goya candy":
                return goyaCandyPrice;
            case "mentos":
                return mentosPrice;
            case "rice":
                return ricePrice;
            case "soy sauce":
                return soySaucePrice;
            case "vinegar":
                return vinegarPrice;
            case "white rabbit":
                return whiteRabbitPrice;
            case "joy":
                return joyPrice;
            case "surf":
                return surfPrice;
            case "payless xtra big":
                return paylessXtraBigPrice;
            case "lucky me":
                return luckyMePrice;
            case "cup noodle":
                return cupNoodlePrice;
            case "colgate":
                return colgatePrice;
            case "rexona":
                return rexonaPrice;
            case "sunsilk":
                return sunsilkPrice;
            case "chippy":
                return chippyPrice;
            case "nova":
                return novaPrice;
            case "piattos":
                return piattosPrice;
            case "coke":
                return cokePrice;
            case "pepsi":
                return pepsiPrice;
            case "royal":
                return royalPrice;
            case "zesto apple":
                return zestoApplePrice;
            case "zesto grape":
                return zestoGrapePrice;
            case "zesto orange":
                return zestoOrangePrice;
            case "adobo":
                return adoboPrice;
            case "afritada":
                return afritadaPrice;
            case "flakes in oil":
                return flakesInOil;
            case "cheese spread":
                return cheeseSpreadPrice;
            case "nescafe":
                return nescafePrice;
            case "peanut butter":
                return peanutButterPrice;
            case "artisan":
                return artisanPrice;
            case "gardenia":
                return gardeniaPrice;
            default:
                Debug.LogWarning("Unknown item: " + itemName);
                return 0f;
        }
    }

    public void SetTotalPrice(float price)
    {
        totalPrice += price;
        Debug.Log("[ITEMPRICE] Total price set to: ₱" + totalPrice);
    }

    public void ResetTotalPrice()
    {
        totalPrice = 0f;
        Debug.Log("[ITEMPRICE] Total price reset to: ₱" + totalPrice);
    }

    public float GetTotalPrice()
    {
        Debug.Log("[ITEMPRICE] Total price: ₱" + totalPrice);
        return totalPrice;
    }
}

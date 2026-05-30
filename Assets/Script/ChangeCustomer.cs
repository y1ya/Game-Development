using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCustomers : MonoBehaviour
{
    public LimitingCustomers limitCustomers;
    public OrderScript orderScript;

    public GameObject currentCustomer;
    public GameObject restartButton;
    public GameObject itemRequest;

    public Text targetCustomersText;

    public Image fillImage;
    public Slider customerProgress;

    public GameObject wellDoneText;

    public Sprite[] lineupCustomers;

    public Text textScore;

    private int maxCustomers;
    private int countCustomers;
    private int rotation = 0;
    private List<string> customerName = new List<string>();

    private void Start()
    {
        customerProgress.interactable = false;

        countCustomers = lineupCustomers.Length;

        maxCustomers = limitCustomers.GetMaxCustomers();
        targetCustomersText.text = $"Target Customers: {maxCustomers.ToString()}";

        customerProgress.minValue = 0;
        customerProgress.maxValue = maxCustomers;
        customerProgress.value = 0;

        Debug.Log($"[CHANGECUSTOMER] Total number of customers in lineup: {countCustomers}");
    }
    public void RandomCustomerPicker()
    {
        rotation += 1;
        SetTextScore();

        customerProgress.value = rotation;

        float fillPercent = customerProgress.value / customerProgress.maxValue;

        if (fillPercent < 0.33f)
            fillImage.color = Color.green;
        else if (fillPercent < 0.66f)
            fillImage.color = Color.yellow;
        else
            fillImage.color = Color.red;

        if (rotation == maxCustomers)
        {
            currentCustomer.SetActive(false);
            restartButton.SetActive(true);

            Debug.Log($"[CHANGECUSTOMER] Player Win");

            wellDoneText.SetActive(true);

            itemRequest.SetActive(false);

            return;
        }
        else { Debug.Log($"[CHANGECUSTOMER] Is winning? Score: {rotation} "); }
       
        Sprite currentSprite = currentCustomer.GetComponent<SpriteRenderer>().sprite;
        string currectCustomerName = currentSprite.name;

        Debug.Log($"[CHANGECUSTOMER] Current Customer Name: {currectCustomerName}");

        customerName.Add(currectCustomerName);

        int randomCustomer = Random.Range(0, maxCustomers);
        currentCustomer.GetComponent<SpriteRenderer>().sprite = lineupCustomers[randomCustomer];

        Sprite nextCustomer = currentCustomer.GetComponent<SpriteRenderer>().sprite;
        string nextCustomerName = nextCustomer.name;

        Debug.Log($"[CHANGECUSTOMER] Randomly picked customer index: {randomCustomer}, name: {lineupCustomers[randomCustomer].name}");

        while (isCustomerDone(nextCustomerName))
        {
            randomCustomer = Random.Range(0, maxCustomers);
            currentCustomer.GetComponent<SpriteRenderer>().sprite = lineupCustomers[randomCustomer];

            nextCustomer = currentCustomer.GetComponent<SpriteRenderer>().sprite;
            nextCustomerName = nextCustomer.name;
            Debug.Log($"[CHANGECUSTOMER] Customer {nextCustomerName} is already done. " +
                $"Picking another customer index: {randomCustomer}");
        }        
    }

    public void SetTextScore()
    {
        textScore.text = $"{rotation.ToString()}";
        Debug.Log($"[CHANGECUSTOMER] Updated score text: {rotation}");
    }

    private bool isCustomerDone(string name)
    {
        if (customerName.Contains(name))
        {
            Debug.Log($"[CHANGECUSTOMER] Customer {name} is already done.");
            return true;
        }
        
        return false;
    }

    public int GetMaxCustomers()
    { return countCustomers; }
}

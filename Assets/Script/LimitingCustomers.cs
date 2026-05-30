using UnityEngine;
using UnityEngine.UI;

public class LimitingCustomers : MonoBehaviour
{
    public ChangeCustomers changeCustomers;

    private int maxCustomers;

    private void Awake()
    {
        int maxCustomerCount = changeCustomers.lineupCustomers.Length - 8;

        int randomMaxCustomers = Random.Range(1, maxCustomerCount);

        maxCustomers = randomMaxCustomers;
        Debug.Log("[LIMITINGCUSTOMERS] Limiting customers to: " + maxCustomers);
    }
    public int GetMaxCustomers()
    {
        Debug.Log("[LIMITINGCUSTOMERS] Maximum customers allowed: " + maxCustomers);
        return maxCustomers;
    }
}

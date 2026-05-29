using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class NEWItemInCartScript : MonoBehaviour
{
    public Text totalItemsText;
    public Text itemsList;

    // Simple item model
    [System.Serializable]
    public class Item
    {
        public string itemName;
        public int quantity;

        public Item(string name, int qty)
        {
            itemName = name;
            quantity = qty;
        }
    }

    // Use a dictionary for quick lookup and a list for order if needed
    private Dictionary<string, Item> items = new Dictionary<string, Item>();
    private List<string> cartItems = new List<string>();

    // Add or increase quantity (matches ItemsInCart.cs behavior)
    public void AddItem(string name, int amount = 1)
    {
        if (string.IsNullOrEmpty(name) || amount <= 0) return;

        // Add to list for order tracking (like ItemsInCart.cs)
        for (int i = 0; i < amount; i++)
            cartItems.Add(name);

        // Track in dictionary for quick lookup
        if (items.TryGetValue(name, out Item existing))
        {
            existing.quantity += amount;
        }
        else
        {
            items[name] = new Item(name, amount);
        }

        Debug.Log($"Added {name} to cart");
        RefreshUI();
    }

    // Set exact quantity (0 removes)
    public void SetItemQuantity(string name, int quantity)
    {
        if (string.IsNullOrEmpty(name)) return;

        // Update list
        cartItems.RemoveAll(item => item.Equals(name));
        for (int i = 0; i < quantity; i++)
            cartItems.Add(name);

        // Update dictionary
        if (quantity <= 0)
        {
            items.Remove(name);
        }
        else
        {
            if (items.TryGetValue(name, out Item existing))
                existing.quantity = quantity;
            else
                items[name] = new Item(name, quantity);
        }

        RefreshUI();
    }

    // Remove an item completely
    public void RemoveItem(string name)
    {
        if (string.IsNullOrEmpty(name)) return;

        cartItems.RemoveAll(item => item.Equals(name));
        items.Remove(name);
        RefreshUI();
    }

    // Clear all items
    public void ClearCart()
    {
        items.Clear();
        cartItems.Clear();
        RefreshUI();
    }

    // Build the single text string and update UI
    private void RefreshUI()
    {
        // Update total items count (total items added, not unique items)
        if (totalItemsText != null)
            totalItemsText.text = $"{cartItems.Count}";

        // Build items list string with quantities
        if (itemsList != null)
        {
            var sb = new StringBuilder();
            foreach (var kv in items)
            {
                var it = kv.Value;
                sb.AppendLine($"{it.itemName} x{it.quantity}");
            }

            // If empty, show placeholder
            if (sb.Length == 0)
                itemsList.text = "Cart is empty";
            else
                itemsList.text = sb.ToString().TrimEnd();
        }
    }

    // Getter methods (like ItemsInCart.cs)
    public int GetTotalItems()
    {
        return cartItems.Count;
    }

    public List<string> GetCartItems()
    {
        return cartItems;
    }

    // Example usage for testing in the inspector
    [ContextMenu("Add Example Items")]
    public void AddExampleItems()
    {
        AddItem("Apple", 3);
        AddItem("Banana", 2);
        AddItem("Potion", 1);
    }
}

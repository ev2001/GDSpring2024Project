using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHandler : MonoBehaviour
{
    public static InventoryHandler Instance;

    public List<AllItems> inventoryItems = new List<AllItems>(); // Inventory Items

    private void Awake()
    {
        Instance = this;
    }

    public void AddItem(AllItems item) // Add items to inventory
    {
        if (!inventoryItems.Contains(item))
        {
            inventoryItems.Add(item);
        }
    }

    public void RemoveItem(AllItems item) // Remove items from inventory
    {
        if (!inventoryItems.Contains(item))
        {
            inventoryItems.Remove(item);
        }
    }

    public enum AllItems // All available inventory items in game
    {
        MintKeyCard,
        PinkKeyCard,
        OrangeKeyCard
    }
}

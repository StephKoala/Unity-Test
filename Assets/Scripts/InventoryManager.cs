using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [System.Serializable]
    public class InventorySlot
    {
        public Image icon;  
        public bool isEmpty = true;  
    }

    [SerializeField] private InventorySlot[] slots; // Inventory slots

    public bool AddToInventory(Sprite itemIcon)
    {
        foreach (InventorySlot slot in slots)
        {
            if (slot.isEmpty)
            {
                slot.icon.sprite = itemIcon;  // Assign the harvested item's icon
                slot.icon.enabled = true;    // Display the icon in the slot
                slot.isEmpty = false;        // Mark the slot as occupied
                return true;                 // Indicate that the item was successfully added
            }
        }
        Debug.Log("Inventory full");
        return false;  // Return false if there's no space
    }

    // Function to transfer icons to the Chest
    public void TransferItemsToChest(InventorySlot[] chestSlots)
    {
        foreach (InventorySlot playerSlot in slots)
        {
            if (!playerSlot.isEmpty) // If the player's slot is not empty
            {
                foreach (InventorySlot chestSlot in chestSlots)
                {
                    if (chestSlot.isEmpty) // Find the first empty slot in the chest
                    {
                        chestSlot.icon.sprite = playerSlot.icon.sprite;  // Assign the icon to the Chest slot
                        chestSlot.icon.enabled = true;                   // Make the icon visible in the Chest
                        chestSlot.isEmpty = false;                       // Mark the Chest slot as occupied

                        playerSlot.icon.enabled = false;                 // Deactivate the icon in the Inventory
                        playerSlot.isEmpty = true;                       // Mark the player's slot as empty
                        break; // Stop searching for slots in the chest for this item
                    }
                }
            }
        }
    }
}

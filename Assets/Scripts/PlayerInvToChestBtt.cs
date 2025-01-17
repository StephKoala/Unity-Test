using UnityEngine;
using UnityEngine.UI;

public class PlayerInvToChestBtt : MonoBehaviour
{
    [SerializeField] private InventoryManager playerInventoryManager; 
    [SerializeField] private ChestAcc chestScript; 

    private void Start()
    {
        // Bind the button to the transfer method
        GetComponent<Button>().onClick.AddListener(TransferAllToChest);
    }

    public void TransferAllToChest()
    {
        // Check if the player is near the chest before transferring
        if (chestScript.IsPlayerNear())
        {
            // Call the function to transfer all items from the inventory to the chest
            playerInventoryManager.TransferItemsToChest(chestScript.chestSlots);
            Debug.Log("Transfer completed.");
        }
        else
        {
            Debug.Log("You cannot transfer items. You need to be near the chest.");
        }
    }
}

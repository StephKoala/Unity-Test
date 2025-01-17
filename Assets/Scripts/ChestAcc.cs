using UnityEngine;

public class ChestAcc : MonoBehaviour
{
    [SerializeField] private GameObject chestInventory; // Chest where items are stored
    [SerializeField] private InventoryManager inventoryManager; // Reference to the InventoryManager
    [SerializeField] public InventoryManager.InventorySlot[] chestSlots; // Chest slots
    [SerializeField] private GameObject winScreen; // Reference to the WinScreen GameObject that will be activated upon winning
    [SerializeField] private GameObject playerInventory; // Reference to the player's Inventory GameObject
    [SerializeField] private GameObject player; // Reference to the player GameObject (if necessary for any action)

    private bool isInventoryOpen = false;
    private bool isPlayerNear = false;

    private void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            ToggleInventory();
        }

        // Check if the ChestInventory is full and activate the win screen
        CheckChestFull();
    }

    private void ToggleInventory()
    {
        isInventoryOpen = !isInventoryOpen;
        chestInventory.SetActive(isInventoryOpen);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }

    // Public method to check if the player is near the chest
    public bool IsPlayerNear()
    {
        return isPlayerNear;
    }

    // Checks if all the chest slots are occupied
    private void CheckChestFull()
    {
        foreach (var slot in chestSlots)
        {
            if (slot.isEmpty)  // If any slot is empty, the chest is not full
                return;
        }

        // If all the slots are full, activate the win screen
        WinGame();
    }

    // Activates the WinScreen, deactivates the inventories, and ends the game
    private void WinGame()
    {
        if (winScreen != null)
        {
            winScreen.SetActive(true);  // Activate the WinScreen GameObject
            Time.timeScale = 0;  // Pause the game
            Debug.Log("You win!");

            // Deactivate the PlayerInventory and ChestInventory
            if (playerInventory != null)
                playerInventory.SetActive(false);
            if (chestInventory != null)
                chestInventory.SetActive(false);
        }
    }
}

using UnityEngine;

public class ToggleInventory : MonoBehaviour
{
    [SerializeField] private GameObject inventory;  // The GameObject that contains the inventory

    private bool isInventoryOpen = false;  // State that indicates whether the inventory is open or closed

    void Update()
    {
        // Detects when the B key is pressed
        if (Input.GetKeyDown(KeyCode.B))
        {
            ToggleInventoryVisibility();  // Calls the function to toggle visibility
        }
    }

    // Toggles the visibility of the inventory
    private void ToggleInventoryVisibility()
    {
        isInventoryOpen = !isInventoryOpen;  // Changes the inventory state

        // Activates or deactivates the GameObject based on the state
        inventory.SetActive(isInventoryOpen);
    }
}

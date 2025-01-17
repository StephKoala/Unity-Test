using UnityEngine;

public class ChestAcc : MonoBehaviour
{
    [SerializeField] private GameObject chestInventory; // Chest donde se guardan los items
    [SerializeField] private InventoryManager inventoryManager; // Referencia al InventoryManager
    [SerializeField] public InventoryManager.InventorySlot[] chestSlots; // Slots del Chest

    private bool isInventoryOpen = false;
    private bool isPlayerNear = false;

    private void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            ToggleInventory();
        }
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

    // Método público para verificar si el jugador está cerca del cofre
    public bool IsPlayerNear()
    {
        return isPlayerNear;
    }
}

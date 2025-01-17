using UnityEngine;
using UnityEngine.UI;

public class ChestAcc : MonoBehaviour
{
    [SerializeField] private GameObject chestInventory; // Chest donde se guardan los items
    [SerializeField] private InventoryManager inventoryManager; // Referencia al InventoryManager
    [SerializeField] private InventoryManager.InventorySlot[] chestSlots; // Slots del Chest
    [SerializeField] public Button keepButton;  // Botón Keep para transferir los items

    private bool isInventoryOpen = false;
    private bool isPlayerNear = false;

    public void Start()
    {
        // Asignamos la función del botón Keep cuando se presiona
        keepButton.onClick.AddListener(OnKeepButtonPressed);
    }

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

    public void OnKeepButtonPressed()
    {
        // Transferir los íconos de los items del inventario a los slots del Chest
        inventoryManager.TransferItemsToChest(chestSlots);
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
}

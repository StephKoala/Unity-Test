using UnityEngine;

public class ChestAcc : MonoBehaviour
{
    [SerializeField] private GameObject chestInventory; // Chest donde se guardan los items
    [SerializeField] private InventoryManager inventoryManager; // Referencia al InventoryManager
    [SerializeField] public InventoryManager.InventorySlot[] chestSlots; // Slots del Chest
    [SerializeField] private GameObject winScreen; // Referencia al GameObject WinScreen que se activará al ganar
    [SerializeField] private GameObject playerInventory; // Referencia al GameObject del Inventario del jugador
    [SerializeField] private GameObject player; // Referencia al GameObject del jugador (si es necesario para alguna acción)

    private bool isInventoryOpen = false;
    private bool isPlayerNear = false;

    private void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            ToggleInventory();
        }

        // Verifica si el ChestInventory está lleno y activa la pantalla de victoria
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

    // Método público para verificar si el jugador está cerca del cofre
    public bool IsPlayerNear()
    {
        return isPlayerNear;
    }

    // Verifica si todos los slots del Chest están ocupados
    private void CheckChestFull()
    {
        foreach (var slot in chestSlots)
        {
            if (slot.isEmpty)  // Si algún slot está vacío, el cofre no está lleno
                return;
        }

        // Si todos los slots están llenos, activa la pantalla de victoria
        WinGame();
    }

    // Activa el WinScreen, desactiva los inventarios y finaliza el juego
    private void WinGame()
    {
        if (winScreen != null)
        {
            winScreen.SetActive(true);  // Activa el GameObject WinScreen
            Time.timeScale = 0;  // Detiene el juego
            Debug.Log("¡Has ganado!");

            // Desactiva el PlayerInventory y el ChestInventory
            if (playerInventory != null)
                playerInventory.SetActive(false);
            if (chestInventory != null)
                chestInventory.SetActive(false);
        }
    }
}

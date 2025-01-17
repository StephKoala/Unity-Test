using UnityEngine;
using UnityEngine.UI;

public class PlayerInvToChestBtt : MonoBehaviour
{
    [SerializeField] private InventoryManager playerInventoryManager; // Referencia al InventoryManager del jugador
    [SerializeField] private ChestAcc chestScript; // Referencia al script del cofre

    private void Start()
    {
        // Vincula el botón al método de transferencia
        GetComponent<Button>().onClick.AddListener(TransferAllToChest);
    }

    public void TransferAllToChest()
    {
        // Verifica si el jugador está cerca del cofre antes de transferir
        if (chestScript.IsPlayerNear())
        {
            // Llama a la función que transfiere todos los ítems del inventario al cofre
            playerInventoryManager.TransferItemsToChest(chestScript.chestSlots);
            Debug.Log("Transferencia completada.");
        }
        else
        {
            Debug.Log("No puedes transferir ítems. Necesitas estar cerca del cofre.");
        }
    }
}

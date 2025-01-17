using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [System.Serializable]
    public class InventorySlot
    {
        public Image icon;  // El icono que representa el objeto en este slot
        public bool isEmpty = true;  // Verifica si el slot está vacío
    }

    [SerializeField] private InventorySlot[] slots; // Slots de Inventario

    public bool AddToInventory(Sprite itemIcon)
    {
        foreach (InventorySlot slot in slots)
        {
            if (slot.isEmpty)
            {
                slot.icon.sprite = itemIcon;  // Asignar el icono del objeto cosechado
                slot.icon.enabled = true;    // Mostrar el icono en el slot
                slot.isEmpty = false;        // Marcar el slot como ocupado
                return true;                 // Indicar que el objeto fue agregado exitosamente
            }
        }
        Debug.Log("Inventario lleno");
        return false;  // Si no hay espacio, devolver falso
    }

    // Función para transferir los íconos al Chest
    public void TransferItemsToChest(InventorySlot[] chestSlots)
    {
        foreach (InventorySlot playerSlot in slots)
        {
            if (!playerSlot.isEmpty) // Si el slot del jugador no está vacío
            {
                foreach (InventorySlot chestSlot in chestSlots)
                {
                    if (chestSlot.isEmpty) // Encuentra el primer slot vacío en el cofre
                    {
                        chestSlot.icon.sprite = playerSlot.icon.sprite;  // Asigna el icono al slot del Chest
                        chestSlot.icon.enabled = true;                   // Hacer visible el ícono en el Chest
                        chestSlot.isEmpty = false;                       // Marcar el slot del cofre como ocupado

                        playerSlot.icon.enabled = false;                 // Desactivar el ícono en el Inventario
                        playerSlot.isEmpty = true;                       // Marcar el slot del jugador como vacío
                        break; // Deja de buscar slots en el cofre para este ítem
                    }
                }
            }
        }
    }
}

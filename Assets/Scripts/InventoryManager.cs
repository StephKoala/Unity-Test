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

    // Función para transferir los íconos al Chest (pasarlos de inventario a los slots del Chest)
    public void TransferItemsToChest(InventorySlot[] chestSlots)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (!slots[i].isEmpty && i < chestSlots.Length && chestSlots[i].isEmpty)
            {
                chestSlots[i].icon.sprite = slots[i].icon.sprite;  // Asigna el icono al slot del Chest
                chestSlots[i].icon.enabled = true;  // Hacer visible el ícono en el Chest
                slots[i].icon.enabled = false;     // Desactivar el ícono en el Inventario
                slots[i].isEmpty = true;           // Marcar el slot del inventario como vacío
            }
        }
    }
}

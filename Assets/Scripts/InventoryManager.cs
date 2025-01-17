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

    [SerializeField] private InventorySlot[] slots;

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
}

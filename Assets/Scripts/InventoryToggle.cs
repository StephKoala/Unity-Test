using UnityEngine;

public class ToggleInventory : MonoBehaviour
{
    [SerializeField] private GameObject inventory;  // El GameObject que contiene el inventario

    private bool isInventoryOpen = false;  // Estado que indica si el inventario está abierto o cerrado

    void Update()
    {
        // Detecta cuando se presiona la tecla B
        if (Input.GetKeyDown(KeyCode.B))
        {
            ToggleInventoryVisibility();  // Llama a la función para alternar la visibilidad
        }
    }

    // Alterna la visibilidad del inventario
    private void ToggleInventoryVisibility()
    {
        isInventoryOpen = !isInventoryOpen;  // Cambia el estado del inventario

        // Activa o desactiva el GameObject basado en el estado
        inventory.SetActive(isInventoryOpen);
    }
}

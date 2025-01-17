using UnityEngine;

public class ChestInteraction : MonoBehaviour
{
    [SerializeField] private GameObject chestInventory; // Arrastra el objeto ChestInventory aquí desde el inspector
    [SerializeField] private float interactionDistance = 2f; // Distancia de interacción, en caso de usarla adicionalmente

    private bool isInventoryOpen = false; // Estado de si el inventario está abierto o cerrado
    private bool isPlayerNear = false; // Estado que indica si el jugador está cerca del cofre

    private void Update()
    {
        // Solo permite abrir o cerrar el inventario si el jugador está cerca y presiona E
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E)) 
        {
            ToggleInventory(); // Abre o cierra el inventario
        }
    }

    // Cambia el estado del inventario (abierto/cerrado)
    private void ToggleInventory()
    {
        isInventoryOpen = !isInventoryOpen; // Cambia el estado

        // Activa o desactiva el ChestInventory dependiendo del estado
        chestInventory.SetActive(isInventoryOpen);
    }

    // Detecta cuando el jugador entra en el área de colisión del cofre
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Verifica si el objeto que entra tiene la etiqueta "Player"
        {
            isPlayerNear = true; // El jugador está cerca del cofre
        }
    }

    // Detecta cuando el jugador sale del área de colisión del cofre
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Verifica si el objeto que sale tiene la etiqueta "Player"
        {
            isPlayerNear = false; // El jugador ya no está cerca del cofre
        }
    }
}

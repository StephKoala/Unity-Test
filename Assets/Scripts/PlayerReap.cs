using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReap : MonoBehaviour
{
    [SerializeField] private float interactionDistance = 1f;  // Distancia de interacción
    [SerializeField] private InventoryManager inventory;  // Referencia al inventario

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlantGrowSys plant = GetNearPlant();
            if (plant != null && plant.ItsHarvested())
            {
                plant.Harvest(inventory);  // Cosechar y agregar al inventario
            }
        }
    }

    private PlantGrowSys GetNearPlant()
    {
        Collider2D[] nearbyColliders = Physics2D.OverlapCircleAll(transform.position, interactionDistance);
        foreach (Collider2D col in nearbyColliders)
        {
            PlantGrowSys plant = col.GetComponent<PlantGrowSys>();
            if (plant != null)
            {
                return plant;
            }
        }
        return null;
    }
}

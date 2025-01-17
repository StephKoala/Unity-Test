using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReap : MonoBehaviour
{
    [SerializeField] private float interactionDistance = 1f;  
    [SerializeField] private InventoryManager inventory;  

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))  // Check if the player presses the E key
        {
            PlantGrowSys plant = GetNearPlant();  // Get the nearest plant
            if (plant != null && plant.ItsHarvested())  // Check if the plant is ready to be harvested
            {
                plant.Harvest(inventory);  // Harvest the plant and add it to the inventory
            }
        }
    }

    private PlantGrowSys GetNearPlant()
    {
        Collider2D[] nearbyColliders = Physics2D.OverlapCircleAll(transform.position, interactionDistance);  // Check for colliders within the interaction range
        foreach (Collider2D col in nearbyColliders)
        {
            PlantGrowSys plant = col.GetComponent<PlantGrowSys>();  // Check if the collider is a plant
            if (plant != null)
            {
                return plant;  // Return the plant if found
            }
        }
        return null;  // Return null if no plant is found nearby
    }
}

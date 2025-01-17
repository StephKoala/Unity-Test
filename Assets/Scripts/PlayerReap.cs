using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReap : MonoBehaviour
{
    [SerializeField] private float interactionDistance = 1f; // Distancia de interacción

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))  
        {
            // Verificar si el jugador está cerca de la planta y si la planta está lista para cosechar
            PlantGrowSys plant = GetNearPlant();
            if (plant != null && plant.ItsHarvested())
            {
                plant.Harvest(); // Cosechar la planta
            }
        }
    }

    // Usar OverlapCircle para detectar plantas cercanas
    private PlantGrowSys GetNearPlant()
    {
        // Verifica todos los colliders dentro de un círculo alrededor del jugador
        Collider2D[] nearbyColliders = Physics2D.OverlapCircleAll(transform.position, interactionDistance);
        foreach (Collider2D col in nearbyColliders)
        {
            // Si encontramos un objeto con el script PlantGrowSys, lo devolvemos
            PlantGrowSys plant = col.GetComponent<PlantGrowSys>();
            if (plant != null)
            {
                return plant;
            }
        }
        return null;  // No se encontró ninguna planta cercana
    }
}

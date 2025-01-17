using System.Collections;
using UnityEngine;

public class PlantGrowSys : MonoBehaviour
{
    [SerializeField] protected float growingtime;
    [SerializeField] protected Sprite[] phases; // Sprites para cada fase de crecimiento
    [SerializeField] private Sprite harvestedIcon;  // Ícono que representa la planta cosechada

    protected int currentPhase = 0;  // Fase actual de la planta
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(Growing());
    }

    private IEnumerator Growing()
    {
        while (currentPhase < phases.Length - 1)  // Mientras no esté en la fase de cosecha
        {
            yield return new WaitForSeconds(growingtime);  // Esperar entre fases
            SwitchPhase();
        }
    }

    private void SwitchPhase()
    {
        currentPhase++;
        spriteRenderer.sprite = phases[currentPhase];  // Cambiar al sprite correspondiente
    }

    public bool Harvest(InventoryManager inventory)
    {
        if (currentPhase == phases.Length - 1)  // Si está en la fase de cosecha
        {
            if (inventory.AddToInventory(harvestedIcon))  // Intentar agregar al inventario
            {
                spriteRenderer.sprite = phases[0];  // Reiniciar la planta
                currentPhase = 0;
                Invoke("ResetGrowth", 5f);  // Reiniciar el crecimiento después de 5 segundos
                return true;
            }
        }
        return false;  // No se pudo cosechar (por ejemplo, inventario lleno)
    }

    private void ResetGrowth()
    {
        StartCoroutine(Growing());
    }

    public bool ItsHarvested()
    {
        return currentPhase == phases.Length - 1;  // Verificar si está lista para cosechar
    }
}

using System.Collections;
using UnityEngine;

public class PlantGrowSys : MonoBehaviour
{
    [SerializeField] protected float growingtime;
    [SerializeField] protected Sprite[] phases; 
    [SerializeField] private Sprite harvestedIcon;  

    protected int currentPhase = 0; 
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(Growing());
    }

    private IEnumerator Growing()
    {
        while (currentPhase < phases.Length - 1)  // While not in the harvest phase
        {
            yield return new WaitForSeconds(growingtime);  // Wait between phases
            SwitchPhase();
        }
    }

    private void SwitchPhase()
    {
        currentPhase++;
        spriteRenderer.sprite = phases[currentPhase];  // Change to the corresponding sprite
    }

    public bool Harvest(InventoryManager inventory)
    {
        if (currentPhase == phases.Length - 1)  // If it's in the harvest phase
        {
            if (inventory.AddToInventory(harvestedIcon))  // Try to add to the inventory
            {
                spriteRenderer.sprite = phases[0];  // Reset the plant
                currentPhase = 0;
                Invoke("ResetGrowth", 2f);  // Reset growth after 2 seconds
                return true;
            }
        }
        return false;  // Cannot harvest (e.g., inventory full)
    }

    private void ResetGrowth()
    {
        StartCoroutine(Growing());
    }

    public bool ItsHarvested()
    {
        return currentPhase == phases.Length - 1;  // Check if it's ready for harvesting
    }
}

using System.Collections;
using UnityEngine;

public class PlantGrowSys : MonoBehaviour
{
    [SerializeField] protected float growingtime;
    [SerializeField] protected Sprite[] phases; //Sprites for each growth phase
    
    protected int currentPhase = 0;  // Current phase of the plant (starts at 0, seed)
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(Growing());
    }

    
    private IEnumerator Growing()
    {
        while (currentPhase < phases.Length - 1)  // While it is not in the harvest phase
        {
            yield return new WaitForSeconds(growingtime); // Wait 7 seconds between phases
            SwitchPhase();  // Switch to the next phase
        }
    }

    // Switch to the next phase (growth phase)
    private void SwitchPhase()
    {
        currentPhase++;  // Advance to the next phase
        spriteRenderer.sprite = phases[currentPhase];  // Change the sprite to the next one in the array
    }

    // Method to harvest the plant
    public void Harvest()
    {
        if (currentPhase == phases.Length - 1)  // If it is in the harvest phase
        {
            spriteRenderer.sprite = phases[0];  // Reset the plant to the seed phase
            currentPhase = 0;  // Restart to seed phase
            Invoke("ResetGrowth", 5f);  // Wait 5 seconds and start again
        }
    }

    // Restart the plant's growth cycle
    private void ResetGrowth()
    {
        StartCoroutine(Growing());  
    }

    // Method to know if the plant is ready to be harvested
    public bool ItsHarvested()
    {
        return currentPhase == phases.Length - 1;  // If it is in the harvest phase
    }
}

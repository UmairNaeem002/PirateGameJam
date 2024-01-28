using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectionScript : MonoBehaviour
{

    [SerializeField] private string[] currentdiseases;
    [SerializeField] private HealthScript healthScript;
    //[SerializeField] private DamageScript damageScript;
    public List<string> DiseasesGreen = new List<string>();
    public List<string> DiseasesRed;

    [SerializeField] private float chestDamageGreen;
    [SerializeField] private float headDamageGreen;
    [SerializeField] private float legsDamageGreen;
    [SerializeField] private float chestDamageRed;
    [SerializeField] private float headDamageRed;
    [SerializeField] private float legsDamageRed;
    private float accumulatedDamage;
    private bool cantDamage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        accumulatedDamage = 0;
        if (DiseasesGreen.Contains("ChestGreen"))
        {
            accumulatedDamage += chestDamageGreen;
        }
        if (DiseasesGreen.Contains("HeadGreen"))
        {
            accumulatedDamage += headDamageGreen;
        }
        if (DiseasesGreen.Contains("LegsGreen"))
        {
            accumulatedDamage += legsDamageGreen;
        }
        if (DiseasesRed.Contains("ChestRed"))
        {
            accumulatedDamage += chestDamageRed;
        }
        if (DiseasesRed.Contains("HeadRed"))
        {
            accumulatedDamage += headDamageRed;
        }
        if (DiseasesRed.Contains("LegsRed"))
        {
            accumulatedDamage += legsDamageRed;
        }
        healthScript.TakeDamage(accumulatedDamage);
        accumulatedDamage = 0;
    }

    public float GetDamageAmount() 
    {
        accumulatedDamage = 0;
        if (DiseasesGreen.Contains("ChestGreen"))
        {
            accumulatedDamage += chestDamageGreen;
        }
        if (DiseasesGreen.Contains("HeadGreen"))
        {
            accumulatedDamage += headDamageGreen;
        }
        if (DiseasesGreen.Contains("LegsGreen"))
        {
            accumulatedDamage += legsDamageGreen;
        }
        if (DiseasesRed.Contains("ChestRed"))
        {
            accumulatedDamage += chestDamageRed;
        }
        if (DiseasesRed.Contains("HeadRed"))
        {
            accumulatedDamage += headDamageRed;
        }
        if (DiseasesRed.Contains("LegsRed"))
        {
            accumulatedDamage += legsDamageRed;
        }
        return accumulatedDamage;
    }
}

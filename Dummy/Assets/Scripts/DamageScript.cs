using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    [SerializeField] private string[] diseases;
    [SerializeField] private HealthScript healthScript;
    [SerializeField] private HealthScript maskHealth;
    [SerializeField] private RaycastingScript raycasting;
    [SerializeField] private InfectionScript infectionScript;
    [SerializeField] private float damage;
    private bool checkMask;
    private float checkMaskHealth;
    private int diseaseChance;
    private int diseaseChosen;
    private string playerDisease;
    private float infectionDamage;
    private float totalDamage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.GetComponent<PlayerMovementScript>())
        {
                infectionDamage = infectionScript.GetDamageAmount();
                totalDamage = infectionDamage + damage;
                healthScript.TakeDamage(totalDamage);
                diseaseChance = Random.Range(0, 100);
                if (diseaseChance == 2)
                {
                    diseaseChosen = Random.Range(0, diseases.Length);
                    playerDisease = diseases[diseaseChosen];
                    if (diseaseChosen >= 0 && diseaseChosen < 3)
                    {
                        if (!infectionScript.DiseasesGreen.Contains(playerDisease))
                        {
                            if (playerDisease == "ChestGreen" && !infectionScript.DiseasesRed.Contains("ChestRed"))
                            {
                                infectionScript.DiseasesGreen.Add(playerDisease);
                            }
                            else if (playerDisease == "LegsGreen" && !infectionScript.DiseasesRed.Contains("LegsRed"))
                            {
                                infectionScript.DiseasesGreen.Add(playerDisease);
                            }
                            else if (playerDisease == "HeadGreen" && !infectionScript.DiseasesRed.Contains("HeadRed"))
                            {
                                infectionScript.DiseasesGreen.Add(playerDisease);
                            }
                        }
                    }
                    else if (diseaseChosen >= 3 && diseaseChosen <= 5)
                    {
                        if (!infectionScript.DiseasesRed.Contains(playerDisease))
                        {
                            infectionScript.DiseasesRed.Add(playerDisease);
                            if (playerDisease == "ChestRed")
                            {
                                infectionScript.DiseasesGreen.Remove("ChestGreen");
                            }
                            else if (playerDisease == "LegsRed")
                            {
                                infectionScript.DiseasesGreen.Remove("LegsGreen");
                            }
                            else if (playerDisease == "HeadRed")
                            {
                                infectionScript.DiseasesGreen.Remove("HeadGreen");
                            }
                        }
                    }
                }
        }
    }
}

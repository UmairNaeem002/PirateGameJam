using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombiningScript : MonoBehaviour
{
    [SerializeField] private RaycastingScript raycast;
    [SerializeField] private Transform playerRightHand;
    [SerializeField] private InfectionScript infectionScript;
    [Header("Green Infections")]
    [SerializeField] private GameObject SES;
    [SerializeField] private GameObject GS;
    [SerializeField] private GameObject VS;
    [SerializeField] private GameObject SEGS;
    [SerializeField] private GameObject SEVS;
    [SerializeField] private GameObject GVS;
    [Header("RED Infections")]
    [SerializeField] private GameObject NES;
    [SerializeField] private GameObject DAS;
    [SerializeField] private GameObject NECS;
    [SerializeField] private GameObject NEDAS;
    [SerializeField] private GameObject CDAS;
    [Header("Inter Combined")]
    [SerializeField] private GameObject SEG;
    [SerializeField] private GameObject SEV;
    [SerializeField] private GameObject GV;
    [SerializeField] private GameObject NEC;
    [SerializeField] private GameObject NEDA;
    [SerializeField] private GameObject CDA;
    private Vector3 positionOfNewObject;
    private GameObject leftHand;
    private GameObject rightHand;
    // Start is called before the first frame update
    void Start()
    {
        positionOfNewObject = playerRightHand.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

            if (Input.GetKeyDown(KeyCode.P))
            {
                (leftHand, rightHand) = raycast.GetInHandItems();
                if(leftHand == null) 
                {
                    leftHand = new GameObject();
                }
                Debug.Log("COMBINE LEFT HAND: " + leftHand.name);
                Debug.Log("COMBINE RIGHT HAND: " + rightHand.name);
                if (leftHand.name == "SES" || rightHand.name == "SES")
                {
                    infectionScript.DiseasesGreen.Remove("ChestGreen");
                    if (leftHand.name == "SES")
                    {
                        raycast.DestroyLeft();
                    }
                    else if (rightHand.name == "SES")
                    {
                        raycast.DestroyRight();
                    }
                }
                else if (leftHand.name == "GS" || rightHand.name == "GS")
                {
                    infectionScript.DiseasesGreen.Remove("LegsGreen");
                    if (leftHand.name == "GS")
                    {
                        raycast.DestroyLeft();
                    }
                    else if (rightHand.name == "GS")
                    {
                        raycast.DestroyRight();
                    }
                }
                else if (leftHand.name == "VS" || rightHand.name == "VS")
                {
                    infectionScript.DiseasesGreen.Remove("HeadGreen");
                    if (leftHand.name == "VS")
                    {
                        raycast.DestroyLeft();
                    }
                    else if (rightHand.name == "VS")
                    {
                        raycast.DestroyRight();
                    }
                }
                else if (leftHand.name == "NES" || rightHand.name == "NES")
                {
                    infectionScript.DiseasesRed.Remove("ChestRed");
                    if (leftHand.name == "NES")
                    {
                        raycast.DestroyLeft();
                    }
                    else if (rightHand.name == "NES")
                    {
                        raycast.DestroyRight();
                    }
                }
                else if (leftHand.name == "Chlorosindrophon" || rightHand.name == "Chlorosindrophon")
                {
                    infectionScript.DiseasesRed.Remove("LegsRed");
                    if (leftHand.name == "Chlorosindrophon")
                    {
                        raycast.DestroyLeft();
                    }
                    else if (rightHand.name == "Chlorosindrophon")
                    {
                        raycast.DestroyRight();
                    }
                }
                else if (leftHand.name == "DAS" || rightHand.name == "DAS")
                {
                    infectionScript.DiseasesRed.Remove("HeadRed");
                    if (leftHand.name == "DAS")
                    {
                        raycast.DestroyLeft();
                    }
                    else if (rightHand.name == "DAS")
                    {
                        raycast.DestroyRight();
                    }
                }
                else if (leftHand.name == "SEGS" || rightHand.name == "SEGS")
                {
                    infectionScript.DiseasesGreen.Remove("ChestGreen");
                    infectionScript.DiseasesGreen.Remove("LegsGreen");
                    if (leftHand.name == "SEGS")
                    {
                        raycast.DestroyLeft();
                    }
                    else if (rightHand.name == "SEGS")
                    {
                        raycast.DestroyRight();
                    }
                }
                else if (leftHand.name == "SEVS" || rightHand.name == "SEVS")
                {
                    infectionScript.DiseasesGreen.Remove("ChestGreen");
                    infectionScript.DiseasesGreen.Remove("HeadGreen");
                    if (leftHand.name == "SEVS")
                    {
                        raycast.DestroyLeft();
                    }
                    else if (rightHand.name == "SEVS")
                    {
                        raycast.DestroyRight();
                    }
                }
                else if (leftHand.name == "GVS" || rightHand.name == "GVS")
                {
                    infectionScript.DiseasesGreen.Remove("LegsGreen");
                    infectionScript.DiseasesGreen.Remove("HeadGreen");
                    if (leftHand.name == "GVS")
                    {
                        raycast.DestroyLeft();
                    }
                    else if (rightHand.name == "GVS")
                    {
                        raycast.DestroyRight();
                    }
                }
                else if (leftHand.name == "NECS" || rightHand.name == "NECS")
                {
                    infectionScript.DiseasesRed.Remove("ChestRed");
                    infectionScript.DiseasesRed.Remove("LegsRed");
                    if (leftHand.name == "NECS")
                    {
                        raycast.DestroyLeft();
                    }
                    else if (rightHand.name == "NECS")
                    {
                        raycast.DestroyRight();
                    }
                }
                else if (leftHand.name == "NEDAS" || rightHand.name == "NEDAS")
                {
                    infectionScript.DiseasesRed.Remove("ChestRed");
                    infectionScript.DiseasesRed.Remove("HeadRed");
                    if (leftHand.name == "NEDAS")
                    {
                        raycast.DestroyLeft();
                    }
                    else if (rightHand.name == "NEDAS")
                    {
                        raycast.DestroyRight();
                    }
                }
                else if (leftHand.name == "CDAS" || rightHand.name == "CDAS")
                {
                    infectionScript.DiseasesRed.Remove("LegsRed");
                    infectionScript.DiseasesRed.Remove("HeadRed");
                    if (leftHand.name == "CDAS")
                    {
                        raycast.DestroyLeft();
                    }
                    else if (rightHand.name == "CDAS")
                    {
                        raycast.DestroyRight();
                    }
                }
            }
}

    public void Combining() 
    {
        (leftHand, rightHand) = raycast.GetInHandItems();
        //Debug.Log("COMBINE LEFT HAND: " + leftHand.name);
        //Debug.Log("COMBINE RIGHT HAND: " + rightHand.name);
        if (leftHand.name == "SYLVICEXTRACT")
        {
            if (rightHand.name == "SYRINGE")
            {
                raycast.DestroyObjects();
                GameObject instantiatedSES = Instantiate(SES, positionOfNewObject, Quaternion.identity);
                instantiatedSES.AddComponent<Target>();
                raycast.EquipRight(instantiatedSES);
            }
            else if (rightHand.name == "GALINTROL")
            {
                raycast.DestroyObjects();
                GameObject instantiatedSEG = Instantiate(SEG, positionOfNewObject, Quaternion.identity);
                instantiatedSEG.AddComponent<Target>();
                raycast.EquipRight(instantiatedSEG);
            }
            else if (rightHand.name == "VICZONIUMACID")
            {
                raycast.DestroyObjects();
                GameObject instantiatedSEV = Instantiate(SEV, positionOfNewObject, Quaternion.identity);
                instantiatedSEV.AddComponent<Target>();
                raycast.EquipRight(instantiatedSEV);
            }
        }
        else if (rightHand.name == "SYLVICEXTRACT")
        {
            if (leftHand.name == "SYRINGE")
            {
                raycast.DestroyObjects();
                GameObject instantiatedSES = Instantiate(SES, positionOfNewObject, Quaternion.identity);
                instantiatedSES.AddComponent<Target>();
                raycast.EquipRight(instantiatedSES);
            }
            else if (leftHand.name == "GALINTROL")
            {
                raycast.DestroyObjects();
                GameObject instantiatedSEG = Instantiate(SEG, positionOfNewObject, Quaternion.identity);
                instantiatedSEG.AddComponent<Target>();
                raycast.EquipRight(instantiatedSEG);
            }
            else if (leftHand.name == "VICZONIUMACID")
            {
                raycast.DestroyObjects();
                GameObject instantiatedSEV = Instantiate(SEV, positionOfNewObject, Quaternion.identity);
                instantiatedSEV.AddComponent<Target>();
                raycast.EquipRight(instantiatedSEV);
            }
        }
        //For Galintrol
        else if (leftHand.name == "GALINTROL")
        {
            if (rightHand.name == "SYRINGE")
            {
                raycast.DestroyObjects();
                GameObject instantiatedGS = Instantiate(GS, positionOfNewObject, Quaternion.identity);
                instantiatedGS.AddComponent<Target>();
                raycast.EquipRight(instantiatedGS);
            }
            else if (rightHand.name == "SYLVICEXTRACT")
            {
                raycast.DestroyObjects();
                GameObject instantiatedSEG = Instantiate(SEG, positionOfNewObject, Quaternion.identity);
                instantiatedSEG.AddComponent<Target>();
                raycast.EquipRight(instantiatedSEG);
            }
            else if (rightHand.name == "VICZONIUMACID")
            {
                raycast.DestroyObjects();
                GameObject instantiatedGV = Instantiate(GV, positionOfNewObject, Quaternion.identity);
                instantiatedGV.AddComponent<Target>();
                raycast.EquipRight(instantiatedGV);
            }
        }
        else if (rightHand.name == "GALINTROL")
        {
            if (leftHand.name == "SYRINGE")
            {
                raycast.DestroyObjects();
                GameObject instantiatedGS = Instantiate(GS, positionOfNewObject, Quaternion.identity);
                instantiatedGS.AddComponent<Target>();
                raycast.EquipRight(instantiatedGS);
            }
            else if (leftHand.name == "SYLVICEXTRACT")
            {
                raycast.DestroyObjects();
                GameObject instantiatedSEG = Instantiate(SEG, positionOfNewObject, Quaternion.identity);
                instantiatedSEG.AddComponent<Target>();
                raycast.EquipRight(instantiatedSEG);
            }
            else if (leftHand.name == "VICZONIUMACID")
            {
                raycast.DestroyObjects();
                GameObject instantiatedGV = Instantiate(GV, positionOfNewObject, Quaternion.identity);
                instantiatedGV.AddComponent<Target>();
                raycast.EquipRight(instantiatedGV);
            }
        }
        //For Viczonium Acid
        else if (leftHand.name == "VICZONIUMACID")
        {
            if (rightHand.name == "SYRINGE")
            {
                raycast.DestroyObjects();
                GameObject instantiatedVS = Instantiate(VS, positionOfNewObject, Quaternion.identity);
                instantiatedVS.AddComponent<Target>();
                raycast.EquipRight(instantiatedVS);
            }
            else if (rightHand.name == "SYLVICEXTRACT")
            {
                raycast.DestroyObjects();
                GameObject instantiatedSEV = Instantiate(SEV, positionOfNewObject, Quaternion.identity);
                instantiatedSEV.AddComponent<Target>();
                raycast.EquipRight(instantiatedSEV);
            }
            else if (rightHand.name == "GALINTROL")
            {
                raycast.DestroyObjects();
                GameObject instantiatedGV = Instantiate(GV, positionOfNewObject, Quaternion.identity);
                instantiatedGV.AddComponent<Target>();
                raycast.EquipRight(instantiatedGV);
            }
        }
        else if (rightHand.name == "VICZONIUMACID")
        {
            if (leftHand.name == "SYRINGE")
            {
                raycast.DestroyObjects();
                GameObject instantiatedVS = Instantiate(VS, positionOfNewObject, Quaternion.identity);
                instantiatedVS.AddComponent<Target>();
                raycast.EquipRight(instantiatedVS);
            }
            else if (leftHand.name == "SYLVICEXTRACT")
            {
                raycast.DestroyObjects();
                GameObject instantiatedSEV = Instantiate(SEV, positionOfNewObject, Quaternion.identity);
                instantiatedSEV.AddComponent<Target>();
                raycast.EquipRight(instantiatedSEV);
            }
            else if (leftHand.name == "GALINTROL")
            {
                raycast.DestroyObjects();
                GameObject instantiatedGV = Instantiate(GV, positionOfNewObject, Quaternion.identity);
                instantiatedGV.AddComponent<Target>();
                raycast.EquipRight(instantiatedGV);
            }
        }
        //For Sylvic Extract + Galintrol
        else if (leftHand.name == "SEG")
        {
            if (rightHand.name == "SYRINGE")
            {
                raycast.DestroyObjects();
                GameObject instantiatedSEGS = Instantiate(SEGS, positionOfNewObject, Quaternion.identity);
                instantiatedSEGS.AddComponent<Target>();
                raycast.EquipRight(instantiatedSEGS);
            }
        }
        else if (rightHand.name == "SEG")
        {
            if (leftHand.name == "SYRINGE")
            {
                raycast.DestroyObjects();
                GameObject instantiatedSEGS = Instantiate(SEGS, positionOfNewObject, Quaternion.identity);
                instantiatedSEGS.AddComponent<Target>();
                raycast.EquipRight(instantiatedSEGS);
            }
        }
        //For Sylvic Extract + Viczonium Acid
        else if (leftHand.name == "SEV")
        {
            if (rightHand.name == "SYRINGE")
            {
                raycast.DestroyObjects();
                GameObject instantiatedSEVS = Instantiate(SEVS, positionOfNewObject, Quaternion.identity);
                instantiatedSEVS.AddComponent<Target>();
                raycast.EquipRight(instantiatedSEVS);
            }
        }
        else if (rightHand.name == "SEV")
        {
            if (leftHand.name == "SYRINGE")
            {
                raycast.DestroyObjects();
                GameObject instantiatedSEVS = Instantiate(SEVS, positionOfNewObject, Quaternion.identity);
                instantiatedSEVS.AddComponent<Target>();
                raycast.EquipRight(instantiatedSEVS);
            }
        }
        //For Galintrol + Viczonium Acid
        else if (leftHand.name == "GV")
        {
            if (rightHand.name == "SYRINGE")
            {
                raycast.DestroyObjects();
                GameObject instantiatedGVS = Instantiate(GVS, positionOfNewObject, Quaternion.identity);
                instantiatedGVS.AddComponent<Target>();
                raycast.EquipRight(instantiatedGVS);
            }
        }
        else if (rightHand.name == "GV")
        {
            if (leftHand.name == "SYRINGE")
            {
                raycast.DestroyObjects();
                GameObject instantiatedGVS = Instantiate(GVS, positionOfNewObject, Quaternion.identity);
                instantiatedGVS.AddComponent<Target>();
                raycast.EquipRight(instantiatedGVS);
            }
        }
        //for Norvel Extract
        else if (leftHand.name == "NORVELEXTRACT")
        {
            if (rightHand.name == "SYRINGE")
            {
                raycast.DestroyObjects();
                GameObject instantiatedNES = Instantiate(NES, positionOfNewObject, Quaternion.identity);
                instantiatedNES.AddComponent<Target>();
                raycast.EquipRight(instantiatedNES);
            }
            else if (rightHand.name == "CHLOROSINDROPHON")
            {
                raycast.DestroyObjects();
                GameObject instantiatedNEC = Instantiate(NEC, positionOfNewObject, Quaternion.identity);
                instantiatedNEC.AddComponent<Target>();
                raycast.EquipRight(instantiatedNEC);
            }
            else if (rightHand.name == "DIMORPHIUMACETATE")
            {
                raycast.DestroyObjects();
                GameObject instantiatedNEDA = Instantiate(NEDA, positionOfNewObject, Quaternion.identity);
                instantiatedNEDA.AddComponent<Target>();
                raycast.EquipRight(instantiatedNEDA);
            }
        }
        else if (rightHand.name == "NORVELEXTRACT")
        {
            if (leftHand.name == "SYRINGE")
            {
                raycast.DestroyObjects();
                GameObject instantiatedNES = Instantiate(NES, positionOfNewObject, Quaternion.identity);
                instantiatedNES.AddComponent<Target>();
                raycast.EquipRight(instantiatedNES);
            }
            else if (leftHand.name == "CHLOROSINDROPHON")
            {
                raycast.DestroyObjects();
                GameObject instantiatedNEC = Instantiate(NEC, positionOfNewObject, Quaternion.identity);
                instantiatedNEC.AddComponent<Target>();
                raycast.EquipRight(instantiatedNEC);
            }
            else if (leftHand.name == "DIMORPHIUMACETATE")
            {
                raycast.DestroyObjects();
                GameObject instantiatedNEDA = Instantiate(NEDA, positionOfNewObject, Quaternion.identity);
                instantiatedNEDA.AddComponent<Target>();
                raycast.EquipRight(instantiatedNEDA);
            }
        }
        //for Chlorosindrophon
        else if (leftHand.name == "CHLOROSINDROPHON")
        {
            if (rightHand.name == "NORVELEXTRACT")
            {
                raycast.DestroyObjects();
                GameObject instantiatedNEC = Instantiate(NEC, positionOfNewObject, Quaternion.identity);
                instantiatedNEC.AddComponent<Target>();
                raycast.EquipRight(instantiatedNEC);
            }
            else if (rightHand.name == "DIMORPHIUMACETATE")
            {
                raycast.DestroyObjects();
                GameObject instantiatedCDA = Instantiate(CDA, positionOfNewObject, Quaternion.identity);
                instantiatedCDA.AddComponent<Target>();
                raycast.EquipRight(instantiatedCDA);
            }
        }
        else if (rightHand.name == "CHLOROSINDROPHON")
        {
            if (leftHand.name == "NORVELEXTRACT")
            {
                raycast.DestroyObjects();
                GameObject instantiatedNEC = Instantiate(NEC, positionOfNewObject, Quaternion.identity);
                instantiatedNEC.AddComponent<Target>();
                raycast.EquipRight(instantiatedNEC);
            }
            else if (leftHand.name == "DIMORPHIUMACETATE")
            {
                raycast.DestroyObjects();
                GameObject instantiatedCDA = Instantiate(CDA, positionOfNewObject, Quaternion.identity);
                instantiatedCDA.AddComponent<Target>();
                raycast.EquipRight(instantiatedCDA);
            }
        }
        //for Dimorphium Acetate
        else if (leftHand.name == "DIMORPHIUMACETATE")
        {
            if (rightHand.name == "SYRINGE")
            {
                raycast.DestroyObjects();
                GameObject instantiatedDAS = Instantiate(DAS, positionOfNewObject, Quaternion.identity);
                instantiatedDAS.AddComponent<Target>();
                raycast.EquipRight(instantiatedDAS);
            }
            else if (rightHand.name == "CHLOROSINDROPHON")
            {
                raycast.DestroyObjects();
                GameObject instantiatedCDA = Instantiate(CDA, positionOfNewObject, Quaternion.identity);
                instantiatedCDA.AddComponent<Target>();
                raycast.EquipRight(instantiatedCDA);
            }
            else if (rightHand.name == "NORVELEXTRACT")
            {
                raycast.DestroyObjects();
                GameObject instantiatedNEDA = Instantiate(NEDA, positionOfNewObject, Quaternion.identity);
                instantiatedNEDA.AddComponent<Target>();
                raycast.EquipRight(instantiatedNEDA);
            }
        }
        else if (rightHand.name == "DIMORPHIUMACETATE")
        {
            if (leftHand.name == "SYRINGE")
            {
                raycast.DestroyObjects();
                GameObject instantiatedDAS = Instantiate(DAS, positionOfNewObject, Quaternion.identity);
                instantiatedDAS.AddComponent<Target>();
                raycast.EquipRight(instantiatedDAS);
            }
            else if (leftHand.name == "CHLOROSINDROPHON")
            {
                raycast.DestroyObjects();
                GameObject instantiatedCDA = Instantiate(CDA, positionOfNewObject, Quaternion.identity);
                instantiatedCDA.AddComponent<Target>();
                raycast.EquipRight(instantiatedCDA);
            }
            else if (leftHand.name == "NORVELEXTRACT")
            {
                raycast.DestroyObjects();
                GameObject instantiatedNEDA = Instantiate(NEDA, positionOfNewObject, Quaternion.identity);
                instantiatedNEDA.AddComponent<Target>();
                raycast.EquipRight(instantiatedNEDA);
            }
        }
        //For Norvel Extract + Chlorosindrophon
        else if (leftHand.name == "NEC")
        {
            if (rightHand.name == "SYRINGE")
            {
                raycast.DestroyObjects();
                GameObject instantiatedNECS = Instantiate(NECS, positionOfNewObject, Quaternion.identity);
                instantiatedNECS.AddComponent<Target>();
                raycast.EquipRight(instantiatedNECS);
            }
        }
        else if (rightHand.name == "NEC")
        {
            if (leftHand.name == "SYRINGE")
            {
                raycast.DestroyObjects();
                GameObject instantiatedNECS = Instantiate(NECS, positionOfNewObject, Quaternion.identity);
                instantiatedNECS.AddComponent<Target>();
                raycast.EquipRight(instantiatedNECS);
            }
        }
        //For Norvel Extract + Dimorphium Acetate
        else if (leftHand.name == "NEDA")
        {
            if (rightHand.name == "SYRINGE")
            {
                raycast.DestroyObjects();
                GameObject instantiatedNEDAS = Instantiate(NEDAS, positionOfNewObject, Quaternion.identity);
                instantiatedNEDAS.AddComponent<Target>();
                raycast.EquipRight(instantiatedNEDAS);
            }
        }
        else if (rightHand.name == "NEDA")
        {
            if (leftHand.name == "SYRINGE")
            {
                raycast.DestroyObjects();
                GameObject instantiatedNEDAS = Instantiate(NEDAS, positionOfNewObject, Quaternion.identity);
                instantiatedNEDAS.AddComponent<Target>();
                raycast.EquipRight(instantiatedNEDAS);
            }
        }
        //For Chlorosindrophon + Dimorphium Acetate
        else if (leftHand.name == "CDA")
        {
            if (rightHand.name == "SYRINGE")
            {
                raycast.DestroyObjects();
                GameObject instantiatedCDAS = Instantiate(CDAS, positionOfNewObject, Quaternion.identity);
                instantiatedCDAS.AddComponent<Target>();
                raycast.EquipRight(instantiatedCDAS);
            }
        }
        else if (rightHand.name == "CDA")
        {
            if (leftHand.name == "SYRINGE")
            {
                raycast.DestroyObjects();
                GameObject instantiatedCDAS = Instantiate(CDAS, positionOfNewObject, Quaternion.identity);
                instantiatedCDAS.AddComponent<Target>();
                raycast.EquipRight(instantiatedCDAS);
            }
        }
    }
}

using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class RaycastingScript : MonoBehaviour
{

    [SerializeField] private int rayDistance;
    [SerializeField] private Camera cam;
    private GameObject rightHand;
    [SerializeField] private Transform leftItems;
    [SerializeField] private Transform rightItems;
    [SerializeField] private ItemSwitchingScript switching;
    [SerializeField] private CombiningScript combining;
    [SerializeField] private GameObject InvCanvas;
    [SerializeField] private GameObject Inv1;
    [SerializeField] private GameObject Inv2;
    [SerializeField] private GameObject Inv3;
    [SerializeField] private GameObject Inv4;
    [SerializeField] private Sprite sprite;
    private GameObject leftHand;
    //private int maxItems = 4;
    private float normalYScale;
    private int currentItems;
    private bool left = false;
    private bool right = false;
    private bool maskOn = false;
    private bool card1 = false;
    private bool card2 = false;
    private bool card3 = false;
    private GameObject temp;
    private bool inventoryBool = false;
    private GameObject inventory1;
    private GameObject inventory2;
    private GameObject inventory3;
    private GameObject inventory4;

    // Start is called before the first frame update
    void Start()
    {
        normalYScale = transform.localScale.y;
        //obj = hit.collider.gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) 
        {
            if (inventoryBool == false)
            {
                InvCanvas.SetActive(true);
                inventoryBool = true;
            }
            else 
            {
                InvCanvas.SetActive(false);
                inventoryBool = false;
            }
        }
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider.GetComponent<Target>() && Input.GetKeyDown(KeyCode.E))
            {
                if (right == false)
                {
                    rightHand = hit.collider.gameObject;
                    //currentItems++;
                    //Debug.Log("hit");
                    right = true;
                    EquipRight(hit.collider.gameObject);
                }
                else if (right == true && left == false)
                {
                    leftHand = hit.collider.gameObject;
                    //currentItems++;
                    //Debug.Log("hit");
                    left = true;
                    EquipLeft(hit.collider.gameObject);
                }
                else if (right == true && left == true)
                {
                    inventory1 = hit.collider.gameObject;
                    Inv1.GetComponent<Image>().enabled = true;
                    Inv1.GetComponent<Image>().sprite = sprite; 
                    //left = true;
                    //EquipLeft(hit.collider.gameObject);
                }
            }

            else if (hit.collider.gameObject.tag == "Podium" && Input.GetKeyDown(KeyCode.C))
            {
                combining.Combining();
            }
            else if (hit.collider.gameObject.tag == "Door1" && card1 == true && Input.GetKeyDown(KeyCode.E))  
            {
                hit.collider.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            }
            else if (hit.collider.gameObject.tag == "Door2" && card2 == true && Input.GetKeyDown(KeyCode.E))
            {
                hit.collider.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            }
            else if (hit.collider.gameObject.tag == "Door3" && card3 == true && Input.GetKeyDown(KeyCode.E))
            {
                hit.collider.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
        else
        {
            //Debug.Log("NOT HOT");
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            UnEquip();
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f || Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (right == true && left == true)
            {
                temp = leftHand;
                temp.transform.position = leftItems.transform.position;
                temp.transform.rotation = leftItems.transform.rotation;
                temp.transform.localScale = new Vector3(leftItems.transform.localScale.x, normalYScale, leftItems.transform.localScale.z);
                leftHand = rightHand;
                leftHand.transform.position = rightItems.transform.position;
                leftHand.transform.rotation = rightItems.transform.rotation;
                leftItems.transform.localScale = new Vector3(rightItems.transform.localScale.x, normalYScale, rightItems.transform.localScale.z);
                leftHand.transform.SetParent(rightItems);
                rightHand = temp;
                rightHand.transform.position = temp.transform.position;
                rightHand.transform.rotation = temp.transform.rotation;
                rightItems.transform.localScale = new Vector3(temp.transform.localScale.x, normalYScale, leftItems.transform.localScale.z);
                rightHand.transform.SetParent(leftItems);
            }
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log("LEFT HAND: " + leftHand.name);
            Debug.Log("RIGHT HAND: " + rightHand.name);
        }
    }

    public void EquipLeft(GameObject collider)
    {
        collider.GetComponent<Rigidbody>().isKinematic = true;
        collider.transform.position = leftItems.transform.position;
        collider.transform.rotation = leftItems.transform.rotation;
        collider.transform.localScale = new Vector3(leftItems.transform.localScale.x, normalYScale, leftItems.transform.localScale.z);
        collider.transform.SetParent(leftItems);
        leftHand = collider;
    }

    public void EquipRight(GameObject collider)
    {
        collider.GetComponent<Rigidbody>().isKinematic = true;
        collider.transform.position = rightItems.transform.position;
        collider.transform.rotation = rightItems.transform.rotation;
        collider.transform.localScale = new Vector3(rightItems.transform.localScale.x, normalYScale, rightItems.transform.localScale.z);
        collider.transform.SetParent(rightItems);
        rightHand = collider;
    }

    public void UnEquip()
    {
        if (right == true && left == true)
        {
            rightHand.transform.parent = null;
            rightHand.GetComponent<Target>().Falling();
            rightHand = leftHand;
            leftHand.transform.position = rightItems.transform.position;
            leftHand.transform.rotation = rightItems.transform.rotation;
            leftHand.transform.localScale = new Vector3(rightItems.transform.localScale.x, normalYScale, rightItems.transform.localScale.z);
            leftHand.transform.SetParent(rightItems);
            leftHand = null;
            //leftHand.transform.parent = null;
            left = false;
            //switching.DefaultItem();
            Debug.Log("UNEQUIP TOP");
        }
        else
        {
            rightHand.transform.parent = null;
            rightHand.GetComponent<Target>().Falling();
            //switching.DefaultItem();
            right = false;
            Debug.Log("UNEQUIP BOTTOM");
        }
        //currentItems--;
        //Debug.Log(currentItems);
    }

    public void SetItemInHand(GameObject obj)
    {
        obj = rightHand;
    }

    public (GameObject, GameObject) GetInHandItems()
    {
        //leftHandItem = leftHand;
        //rightHandItem = rightHand;
        return (leftHand, rightHand);
    }

    public void DestroyObjects()
    {
        Destroy(leftHand.gameObject);
        Destroy(rightHand.gameObject);
        left = false;
    }

    public void DestroyLeft() 
    {
        Destroy(leftHand.gameObject);
        left = false;
    }

    public void DestroyRight() 
    {
        Destroy(rightHand.gameObject);
        right = false;
    }

    public bool IsWearingMask() 
    {
        return maskOn;
    }

    public void InventoryLeft() 
    {

    }
}

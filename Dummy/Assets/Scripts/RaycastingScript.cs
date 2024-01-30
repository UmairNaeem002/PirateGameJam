using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RaycastingScript : MonoBehaviour
{

    [SerializeField] private int rayDistance;
    [SerializeField] private Camera cam;
    private GameObject rightHand;
    [SerializeField] private Transform leftItems;
    [SerializeField] private Transform rightItems;
    [SerializeField] private ItemSwitchingScript switching;
    private GameObject leftHand;
    //private int maxItems = 4;
    private float normalYScale;
    private int currentItems;
    private bool left = false;
    private bool right = false;
    private bool maskOn = false;
    private GameObject temp;

    // Start is called before the first frame update
    void Start()
    {
        normalYScale = transform.localScale.y;
        //obj = hit.collider.gameObject;

    }

    // Update is called once per frame
    void Update()
    {
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
                    Debug.Log("hit");
                    right = true;
                    EquipRight(hit.collider.gameObject);
                }
                else if (right == true && left == false)
                {
                    leftHand = hit.collider.gameObject;
                    //currentItems++;
                    Debug.Log("hit");
                    left = true;
                    EquipLeft(hit.collider.gameObject);
                }
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
    }

    public void EquipRight(GameObject collider)
    {
        collider.GetComponent<Rigidbody>().isKinematic = true;
        collider.transform.position = rightItems.transform.position;
        collider.transform.rotation = rightItems.transform.rotation;
        collider.transform.localScale = new Vector3(rightItems.transform.localScale.x, normalYScale, rightItems.transform.localScale.z);
        collider.transform.SetParent(rightItems);
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

    }

    public void DestroyRight() 
    {

    }

    public bool IsWearingMask() 
    {
        return maskOn;
    }
}

using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
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
    private int currentItems;
    private bool left = false;
    private bool right = false;
    private GameObject temp;

    // Start is called before the first frame update
    void Start()
    {
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
                    EquipRight(hit.collider);
                }
                else if (right == true && left == false) 
                {
                    leftHand = hit.collider.gameObject;
                    //currentItems++;
                    Debug.Log("hit");
                    left = true;
                    EquipLeft(hit.collider);
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
                leftHand = rightHand;
                leftHand.transform.position = rightItems.transform.position;
                leftHand.transform.rotation = rightItems.transform.rotation;
                leftHand.transform.SetParent(rightItems);
                rightHand = temp;
                rightHand.transform.position = temp.transform.position;
                rightHand.transform.rotation = temp.transform.rotation;
                rightHand.transform.SetParent(leftItems);
            }
        }
    }

    private void EquipLeft(Collider collider) 
    {
        collider.GetComponent<Rigidbody>().isKinematic = true;
        collider.transform.position = leftItems.transform.position;
        collider.transform.rotation = leftItems.transform.rotation;
        collider.transform.SetParent(leftItems);
    }

    private void EquipRight(Collider collider)
    {
        collider.GetComponent<Rigidbody>().isKinematic = true;
        collider.transform.position = rightItems.transform.position;
        collider.transform.rotation = rightItems.transform.rotation;
        collider.transform.SetParent(rightItems);
    }

    private void UnEquip() 
    {
        if (right == true && left == true)
        {
            rightHand.transform.parent = null;
            rightHand.GetComponent<Target>().Falling();
            rightHand = leftHand;
            leftHand.transform.position = rightItems.transform.position;
            leftHand.transform.rotation = rightItems.transform.rotation;
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
}

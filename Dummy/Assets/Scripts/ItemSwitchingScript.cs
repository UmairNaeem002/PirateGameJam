using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSwitchingScript : MonoBehaviour
{
    [SerializeField] private RaycastingScript raycas;
    [SerializeField] private int selectedItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) 
        {
            /*if (raycas.right == true && raycas.left == true)
            {
                temp = raycas.leftHand;
                temp.transform.position = raycas.leftHand.transform.position;
                temp.transform.rotation = raycas.leftHand.transform.rotation;
                raycas.rightHand = raycas.leftHand;
                raycas.leftHand.transform.position = raycas.rightItems.transform.position;
                raycas.leftHand.transform.rotation = raycas.rightItems.transform.rotation;
                raycas.leftHand.transform.SetParent(raycas.rightItems);
            }*/
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedItem <= 0)
            {
                selectedItem = transform.childCount - 1; ;
            }
            else
            {
                selectedItem--;
            }
        }
    }
    public void ItemSelect()
    {
        int i = 0;
        foreach (Transform item in transform)
        {
            if (i == selectedItem)
            {
                item.gameObject.SetActive(true);
                raycas.SetItemInHand(item.gameObject);

            }
            else
            {
                item.gameObject.SetActive(false);
            }
            i++;
        }
    }

    public void DefaultItem()
    {
        selectedItem = 0;
    }
}

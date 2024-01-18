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
            if (selectedItem >= transform.childCount - 1)
            {
                selectedItem = 0;
            }
            else 
            {
                selectedItem++;
            }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastingScript : MonoBehaviour
{

    [SerializeField] private int rayDistance;
    [SerializeField] private Camera cam;
    //private GameObject obj;
    [SerializeField] private Transform items;
    [SerializeField] private Target target;
    [SerializeField] private ItemSwitchingScript switching;
    private GameObject inHand;
    //private int maxItems = 4;
    private int currentItems;

    // Start is called before the first frame update
    void Start()
    {
        
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
                //obj = hit.collider.gameObject;
                //inHand = hit.collider.gameObject;
                //currentItems++;
                Debug.Log("hit");
                Equip(hit.collider);
            }
        }
        else 
        {
            //Debug.Log("NOT HOT");
        }
        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            UnEquip();
        }
    }

    private void Equip(Collider collider) 
    {
        collider.GetComponent<Rigidbody>().isKinematic = true;
        collider.transform.position = items.transform.position;
        collider.transform.rotation = items.transform.rotation;
        collider.transform.SetParent(items);
    }

    private void UnEquip() 
    {
        if (inHand.transform.parent != null) 
        {
            inHand.transform.parent = null;
            inHand.GetComponent<Target>().Falling();
            switching.DefaultItem();
            currentItems--;
            Debug.Log(currentItems);

        }
    }

    public void SetItemInHand(GameObject obj)
    {
        obj = inHand;
    }
}

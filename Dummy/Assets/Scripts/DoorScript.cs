using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    private bool closed = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (closed == false) 
        {
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    public void OpenDoor() 
    {
        closed = false;
    }
}

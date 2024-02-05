using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().localScale = Vector3.one;
    }

    public void Falling() 
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z - 45);
        GetComponent<Rigidbody>().isKinematic = false;
        transform.localScale = Vector3.one;
    }
}

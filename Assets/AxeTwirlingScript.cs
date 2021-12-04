using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeTwirlingScript : MonoBehaviour  //attached to the axe parent game object
{
    public Rigidbody RigidbodyToRotate;
    public bool BigAxe;


    // Start is called before the first frame update
    void Start()
    {
        RigidbodyToRotate = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ThrowTheAxe()
    {
        

        RigidbodyToRotate = GameObject.FindGameObjectWithTag("Axe").GetComponent<Rigidbody>();

        print("throw " + RigidbodyToRotate);
        RigidbodyToRotate.AddTorque(2000, 0, 0);
        RigidbodyToRotate.AddForce(0,350, 0);

       
    }
}

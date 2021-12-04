using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WhenFlyInFinishes : MonoBehaviour  //attached to SubstrateFlyIn Game Object
{
    public GameObject InstantiationManager;
    public GameObject ProductManager;

    
    //public GameObject H_Catalyst;
    

    // Start is called before the first frame update
    void Start()
    {
        InstantiationManager = GameObject.Find("InstantiationManager");
        ProductManager = GameObject.Find("ProductCountAndDisplayManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WhenFlyInIsDone()  //triggered from the SubstrateFlyIn Animation
    {
        print("FlyIn Done");
        if (InstantiationManager.GetComponent<InstantiationManagerScript>().EnzymeModelAtHighTemp)
        {
            GameObject.Find("DialForCollisionEnergy").GetComponent<DialForCollisionEnergyScript>().ChangeGreenZoneTo90();
        }

        InstantiationManager.GetComponent<InstantiationManagerScript>().InstantiateNewAxe();  //this makes a new axe appear on screen

        //if (InstantiationManager.GetComponent<InstantiationManagerScript>().ThisIsTheEnzymeModel)
        //{
        //    InstantiationManager.GetComponent<InstantiationManagerScript>().InstantiateEnzymeSubstrate();
        //}


          
    }
}

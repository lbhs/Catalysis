using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnimatedComplexScript : MonoBehaviour  //attached to SubstrateAnimatedComplex
{
    public GameObject InstantiationManager;
    public GameObject AxeCountDisplayManager;
    public GameObject ProductCountAndDisplayManager;

    // Start is called before the first frame update
    void Start()
    {
        InstantiationManager = GameObject.Find("InstantiationManager");
        AxeCountDisplayManager = GameObject.Find("AxeCountDisplayManager");
        ProductCountAndDisplayManager = GameObject.Find("ProductCountAndDisplayManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendInReplacementSubstrate()  //triggered by an Animation Event after animation is finished (new products have formed)
    {
               
        Destroy(gameObject);
        if(AxeCountDisplayManager.GetComponent<AxeCountDisplayManagerScript>().AxesRemaining > 0)  //AxesRemaining is decremented prior to AnimatedComplex Instantiation
        {
            InstantiationManager.GetComponent<InstantiationManagerScript>().BringInANewSubstrateMolecule();
        }
        

        
    }

    public void DisplayProductsFormed()
    {
        ProductCountAndDisplayManager.GetComponent<ProductCountAndDisplayScript>().IncreaseProducts();
    }

    

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiationManagerScript : MonoBehaviour  //Attached to InstantiationManager GameObject
{
    public GameObject SubstrateFlyIn;
    public GameObject SubstrateAnimatedComplex;

    public bool ThisIsTheEnzymeModel;  //used by ?? script
    public bool EnzymeModelAtHighTemp;
    public bool HighTemp;   //used by BondToBreakScript to increase the probability of bond breaking at high temp (stack the odds b/c small axes seem less effective at high temp)

    public GameObject Enzyme;
    public GameObject EnzymeSubstrate;
    public GameObject Enzyme_SubstrateComplex;
    public GameObject MeltedEnzyme;

    public GameObject NormalSubstrateFlyIn;    //In High Temp Enzyme Model, need to set "SubstrateFlyIn" to be the Normal Substrate after the first flyin, not the Enzyme Substrate

    public GameObject GreenZone;
    public Sprite GreenZone80;
    public Sprite GreenZone22;

    //public GameObject H_Catalyst;

    public GameObject BigAxe;
    public GameObject SmallAxe;

    public List<GameObject> AxeLineUp;   //This list maybe should be part of the AxeCountDisplayManagerScript
    public int AxeListIndex;

    public bool CatalystPresentInScene;
    //public bool EnzymePresentInScene;
    public Button ThrowAxeButton;

    
    // Start is called before the first frame update
    void Start()
    {
        BringInANewSubstrateMolecule();  //Axe instantiation occurs at the end of the fly-in
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowAnimatedComplex()
    {
        
        Instantiate(SubstrateAnimatedComplex);  //Activate animation of the substrate molecule--should show water atoms joining the glucose and fructose molecules--if catalyst was present, need to regenerate H+
    }

    public void BringInANewSubstrateMolecule()  //called from Start function of this script and from AnimatedComplexScript
    {
        Instantiate(SubstrateFlyIn);
        if (CatalystPresentInScene)
        {
            ThrowAxeButton.interactable = false;
        }
    }

    public void InstantiateNewAxe()  //called from WhenFlyInFinishes, which is only triggered on a Normal SubstrateFlyIn GameObject, NOT on the EnzymeSubstrate, 
                                     //but NormalSubstrate is flown in when Enzyme is at HT
    {
        //print(AxeListIndex);
        Instantiate(AxeLineUp[AxeListIndex]);
        AxeListIndex++;

        if (!CatalystPresentInScene)
        {
            ThrowAxeButton.interactable = true;   //if H+ catalyst is in this scene, No Axe Throwing until catalyst is positioned (H_BondingSiteScript line 33)
        }
        
        
    }


    public void InstantiateEnzymeSubstrate()   
    {
        Instantiate(EnzymeSubstrate);
    }

    public void InstantiateEnzyme_SubstrateComplex()  //this function is only called when an active enzyme collides with an Enzyme Substrate molecule (EnzymeDraggingScript line 70) 
    {
        Instantiate(Enzyme_SubstrateComplex);
        ThrowAxeButton.interactable = false;
    }

    public void InstantiateEnzymeAlone()  //called from BondToBreakScript line 107  
    {
        Instantiate(Enzyme);
    }

    public void InstantiateMeltedEnzyme()  //called from BondToBreakScript line 113
    {
        Instantiate(MeltedEnzyme);
        SubstrateFlyIn = NormalSubstrateFlyIn;
    }

    //public void ChangeGreenZoneTo80()  //this function is now on the DialForCollisionEnergyScript 
    //{
    //    GreenZone.GetComponent<SpriteRenderer>().sprite = GreenZone80;
    //    GreenZone.transform.position = new Vector2(2.86f, -1.24f);
    //}

    //public void ActivateTheAxeThrowingButton()
    //{
    //    ThrowAxeButton.interactable = true;
    //}


}

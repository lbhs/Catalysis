using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BondToBreakScript : MonoBehaviour  //This script is attached to the LeftBond in the SubstrateMolecule
{
    public AudioSource BondRemainsIntactSound;
    public AudioSource AxeBreaksBondSound;

    public GameObject DialForCollisionEnergy;  //used to change GreenZone upon addition of catalyst (or enzyme)

    //public GameObject ThrowingAxeBig;   Axe identities are managed in ___Script
    //public GameObject ThrowingAxeSmall;

    
    public float EnergyThreshold;  //0 to 1, with 0 meaning this bond will always be broken upon collision
    private float RandomChance;   //for small axe, this is 0f to 0.5f, for Big Axe, RandomChance 0.5f to 1.0f 
    public string AxeIdentity;  //Either "big" or "small"

    
    //public TMP_Text EnergyOfCollisionTextBox;  

    //public GameObject SubstrateAnimatedComplex;
    //public GameObject SubstrateFlyIn;  //this game object replaces the previous Substrate Molecule. . .

    public GameObject InstantiationManager;

    public GameObject AxeCountDisplayManager;

    private int Energy;
    


    // Start is called before the first frame update
    void Start()
    {
        InstantiationManager = GameObject.Find("InstantiationManager");
        AxeCountDisplayManager = GameObject.Find("AxeCountDisplayManager");
        BondRemainsIntactSound = GameObject.Find("BondRemainsIntactSound").GetComponent<AudioSource>();
        AxeBreaksBondSound = GameObject.Find("AxeBreaksBondSound").GetComponent<AudioSource>();
        DialForCollisionEnergy = GameObject.Find("DialForCollisionEnergy");
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        print("other.tag = " + other.tag);
        if(other.tag == "Axe" || other.tag == "AxePart")
        {
            if (other.transform.root.gameObject.GetComponent<AxeTwirlingScript>().BigAxe)
            {
                RandomChance = Random.Range(0.5f, 1.0f);
                print("BigAxe");
                AxeIdentity = "Big";

                if (InstantiationManager.GetComponent<InstantiationManagerScript>().HighTemp && AxeCountDisplayManager.GetComponent<AxeCountDisplayManagerScript>().SuccessCountForBigAxe == 0)
                {
                    if (RandomChance < 0.90)
                    {
                        RandomChance += 0.10f;  //increase chances of bond breakage at high temp without catalyst
                        print("Random Chance bumped up at high temp");
                    }

                    if (AxeCountDisplayManager.GetComponent<AxeCountDisplayManagerScript>().AxesRemaining == 1)
                    {
                        RandomChance += 0.98f;
                        print("sure thing");
                    }

                }
            }
            else 
            {
                RandomChance = Random.Range(0.1f, 0.5f);
                print("small axe");
                AxeIdentity = "Small";
                if (GameObject.Find("InstantiationManager").GetComponent<InstantiationManagerScript>().HighTemp && GameObject.Find("InstantiationManager").GetComponent<InstantiationManagerScript>().CatalystPresentInScene)
                {
                    RandomChance = Random.Range(0.20f, 0.5f);
                    if (RandomChance >.38f && RandomChance < .43f)
                    {
                        RandomChance += 0.05f;   //this is a boost to the odds of bond breaking at high temp--makes it more likely students will see increased bond breakage with catalyst at high temp

                    }
                }

                //if (!GameObject.Find("InstantiationManager").GetComponent<InstantiationManagerScript>().HighTemp && 
                //MAKE IT IMPOSSIBLE TO GET A BOND BREAK COUNT ABOVE 7 IN THE LOW TEMP WITH CATALYST SCENARIO--CHECK SMALLAXESUCCESSES AND MAKE RANDOMCHANCE SMALL IF AT THE LIMIT
                if(!InstantiationManager.GetComponent<InstantiationManagerScript>().HighTemp && AxeCountDisplayManager.GetComponent<AxeCountDisplayManagerScript>().SuccessCountForSmallAxe > 2)
                {
                    RandomChance = Random.Range(0.10f, 0.39f);
                    print("downgraded Random Chance, as already have broken enough bonds");
                }

                

            }
        }
       
        else
        {
            RandomChance = 0;
        }

        print(RandomChance);

        //Collision Energy is 100 times "RandomChance".  Send this value to AxeCountDisplayManager to show the numerical value and move the needle on the dial
        Energy =  Mathf.RoundToInt(RandomChance * 100);
        AxeCountDisplayManager.GetComponent<AxeCountDisplayManagerScript>().CollisionEnergyDisplay(Energy);  //IMPORTANT UPGRADE--need to store the energy value on each icon (green check or red "x")



        Destroy(other.transform.root.gameObject);  //other is the Axe!

        if (RandomChance > EnergyThreshold)   //EnergyThreshold is set in H_DraggingScript when Catalyst Is Positioned  ALSO in EnzymeDraggingScript if Enzyme is present!
        {
            print("bond breaks!");       
            AxeBreaksBondSound.Play();

            InstantiationManager.GetComponent<InstantiationManagerScript>().ThrowAxeButton.interactable = false;

            gameObject.transform.root.gameObject.SetActive(false);  //maybe should destroy the gameObject
            InstantiationManager.GetComponent<InstantiationManagerScript>().ShowAnimatedComplex();  


            //Product display is controlled by the WhenFlyInFinishes script attached to the SubstrateFlyIn GameObject

            AxeCountDisplayManager.GetComponent<AxeCountDisplayManagerScript>().UpdateTheAxeCount(AxeIdentity, 1);

            if (InstantiationManager.GetComponent<InstantiationManagerScript>().CatalystPresentInScene)
            {
                GameObject.Find("H+Catalyst").GetComponent<H_DraggingScript>().LetTheH_Float();
            }

            if (InstantiationManager.GetComponent<InstantiationManagerScript>().ThisIsTheEnzymeModel)
            {
                if(InstantiationManager.GetComponent<InstantiationManagerScript>().EnzymeModelAtHighTemp == false)
                {
                    InstantiationManager.GetComponent<InstantiationManagerScript>().InstantiateEnzymeAlone();
                }
                else
                {
                    if (!GameObject.FindGameObjectWithTag("EnzymeHT"))
                    {
                        InstantiationManager.GetComponent<InstantiationManagerScript>().InstantiateMeltedEnzyme();
                    }
                    
                    //InstantiationManager.GetComponent<InstantiationManagerScript>().InstantiateNewAxe();
                    //DialForCollisionEnergy.GetComponent<DialForCollisionEnergyScript>().ChangeGreenZoneTo90();   //This is now done by WhenFlyInFinishes Scripte
                    //NEED TO CHANGE ENERGY THRESHOLD TO 90 JOULES AND CHANGE THE DIAL TO SHOW THIS!!!
                }
                
            }


        }

        else
        {
            if(AxeIdentity == "Small")
            {
                BondRemainsIntactSound.pitch = 1.3f;
            }
            else
            {
                BondRemainsIntactSound.pitch = 1f;
            }

            BondRemainsIntactSound.Play();
            print("bond remains intact");
            if(AxeCountDisplayManager.GetComponent<AxeCountDisplayManagerScript>().AxesRemaining > 1)
            {
                InstantiationManager.GetComponent<InstantiationManagerScript>().InstantiateNewAxe();                
            }

            AxeCountDisplayManager.GetComponent<AxeCountDisplayManagerScript>().UpdateTheAxeCount(AxeIdentity, 0);

        }      
        

        

    }

    

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Display3DMolecule : MonoBehaviour    //This script is attached to the AdvanceToNextMolecule button MAYBE NOT ANYMORE!!!!
{
    public List<GameObject> ThreeDMolecules = new List<GameObject>();
    private GameObject ThreeDMoleculeToDisplay;
    private Rigidbody RigidbodyToRotate;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Display3DStructure()
    {
        //print("showing 3D structure now");
        //print(MoleculeNamesForCheckBox.WhichMoleculeAreWeOn);
        //ThreeDMoleculeToDisplay = ThreeDMolecules[MoleculeNamesForCheckBox.WhichMoleculeAreWeOn];
        //ThreeDMoleculeToDisplay.SetActive(true);
        //RigidbodyToRotate = ThreeDMoleculeToDisplay.GetComponent<Rigidbody>();
        //RigidbodyToRotate.AddTorque(5, 5, 0);
    }

    public void Hide3DStructure()
    {
        print("hiding 3D structure now");
        //MoleculeToDisplay = ThreeDMolecules[MoleculeNamesForCheckBox.WhichMoleculeAreWeOn];
        ThreeDMoleculeToDisplay.SetActive(false);
    }

}

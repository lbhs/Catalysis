using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AxeCountDisplayManagerScript : MonoBehaviour  //Attached to AxeCountDisplayManager GameObject.  AxeLineUp List is part of InstantiationManagerScript
{
    public GameObject BigAxeDisplayIcon;
    public GameObject SmallAxeDisplayIcon;

    public int AxesRemaining;               //AxeLineUp List is part of InstantiationManagerScript
    public int BigAxeCount;
    public int SmallAxeCount;
    public int SuccessCountForBigAxe;
    public int SuccessCountForSmallAxe;

    public TMP_Text AxesRemainingTextBox;
    public TMP_Text BondsBrokenTextBox;

    public TMP_Text BigAxeCountTextBox;
    public TMP_Text SmallAxeCountTextBox;
    public TMP_Text CollisionEnergyTextBox;
    public Rigidbody2D NeedleOnDial;

    public TMP_Text ThrowAxeButtonText;
    public Button ThrowAxeButton;

    public GameObject ReturnToMainMenuButton;

    public AudioSource Applause;





    // Start is called before the first frame update
    void Start()
    {
        AxesRemainingTextBox.text = AxesRemaining + " axes left to throw";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateTheAxeCount(string AxeType, int Success)  //Success = 1 if bond was broken, 0 if bond remained intact. Function is called from BondToBreakScript
    {
        AxesRemaining--;
        AxesRemainingTextBox.text = AxesRemaining + " axes left to throw";

        if (AxeType == "Big")  //The BigAxe has icons for success or failure pre-aligned as children.  Need to adjust this in High Temp scenes that have 9 Big Axes
        {
            SuccessCountForBigAxe += Success;
            BigAxeCount++;
            BigAxeCountTextBox.text = null;   //SuccessCountForBigAxe + " bond(s) broken out of " + BigAxeCount + " tries";
            BigAxeDisplayIcon.GetComponent<BigAxeIconScript>().ShowIcon(BigAxeCount, Success);  //This function displays either a green check or a red "x"
        }

        if (AxeType == "Small")
        {
            SuccessCountForSmallAxe += Success;
            SmallAxeCount++;
            SmallAxeCountTextBox.text = null;   //SuccessCountForSmallAxe + " bond(s) broken out of " + SmallAxeCount + " tries";
            SmallAxeDisplayIcon.GetComponent<SmallAxeIconScript>().ShowIcon(SmallAxeCount, Success);
        }

        if(SuccessCountForBigAxe + SuccessCountForSmallAxe == 1)
        {
            BondsBrokenTextBox.text = ((SuccessCountForBigAxe + SuccessCountForSmallAxe) + " bond broken");
        }
        else
        {
            BondsBrokenTextBox.text = ((SuccessCountForBigAxe + SuccessCountForSmallAxe) + " bonds broken");
        }
        

        if (AxesRemaining == 0)
        {
            print("game over!!!");
            ThrowAxeButtonText.text = "GAME OVER";
            ThrowAxeButton.interactable = false;

            if(SuccessCountForBigAxe + SuccessCountForSmallAxe > 7)
            {
                Applause.Play();
            }
        }

    
    }

    public void CollisionEnergyDisplay(int Energy)  //this function is called from BondToBreakScript line 73
    {
        CollisionEnergyTextBox.text = "Collision Energy: " + Energy + " J";
        if(Energy > GameObject.Find("LeftBond").GetComponent<BondToBreakScript>().EnergyThreshold*100)         //UPDATED THIS WITH ENERGY THRESHOLD value from LeftBond. . .
        {
            CollisionEnergyTextBox.color = Color.yellow;
        }
        else
        {
            CollisionEnergyTextBox.color = Color.white;
        }

        NeedleOnDial.MoveRotation(-Energy * 1.8f);

    }

}

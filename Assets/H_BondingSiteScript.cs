using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class H_BondingSiteScript : MonoBehaviour  //Attached to the Oxygen Atom that is a child in the SubstrateFlyIn GameObject. There is also an H_DraggingScript attached to H+
{
    public Button ThrowAxeButton;
    public AudioSource CatalystSound;

    // Start is called before the first frame update
    void Start()
    {
        ThrowAxeButton = GameObject.Find("ThrowTheAxeButton").GetComponent<Button>();
        CatalystSound = GameObject.Find("CatalystSound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {       
        print("Triggered by " + other.tag);

        if(other.tag == "H+")
        {
            other.transform.root.gameObject.GetComponent<H_DraggingScript>().PositionTheCatalyst();
            CatalystSound.Play();
            ThrowAxeButton.interactable = true;
        }

    }
    


}

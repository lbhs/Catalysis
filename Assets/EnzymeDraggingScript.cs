using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnzymeDraggingScript : MonoBehaviour
{

    //private bool isDragging;
    private Vector2 mousePosition;
    //private Vector2 MovePosition;
    private float deltaX;
    private float deltaY;
    private Rigidbody2D rb;

    public Button ThrowTheAxeButton;
    public GameObject InstantiationManager;

    public Sprite GreenZone20;
    public GameObject GreenZone;

    public AudioSource CatalystSound;
    public AudioSource EnzymeStretchingBondSound;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddTorque(5);
        InstantiationManager = GameObject.Find("InstantiationManager");
        ThrowTheAxeButton = GameObject.Find("ThrowTheAxeButton").GetComponent<Button>();
        CatalystSound = GameObject.Find("CatalystSound").GetComponent<AudioSource>();
        EnzymeStretchingBondSound = GameObject.Find("EnzymeStretchingBondSound").GetComponent<AudioSource>();

    }

    public void OnMouseDown()
    {

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        deltaX = mousePosition.x - transform.position.x;
        deltaY = mousePosition.y - transform.position.y;

    }

    public void OnMouseUp()
    {
        
    }



    void OnMouseDrag()
    {        
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rb.MovePosition(new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY));


        //transform.position = new Vector2(mousePosition.x-deltaX, mousePosition.y-deltaY);
        //rb.velocity = Vector3.zero;
        //rb.angularVelocity = 0f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("enzyme triggered by " + other.tag);
        if(other.tag == "EnzymeSubstrate")
        {
            CatalystSound.Play();
            Destroy(other.transform.root.gameObject);  //this destroys the substrate model (sprite)
            Destroy(gameObject);  //this destroys the enzyme alone (draggable sprite)
            InstantiationManager.GetComponent<InstantiationManagerScript>().InstantiateEnzyme_SubstrateComplex();

            GameObject.Find("DialForCollisionEnergy").GetComponent<DialForCollisionEnergyScript>().ChangeGreenZoneTo20();
            //GreenZone = GameObject.Find("GreenZone");                       //GreenZone modifications are handled by DialForCollisionEnergyScript 
            //GreenZone.GetComponent<SpriteRenderer>().sprite = GreenZone20;
            //GreenZone.transform.localPosition = new Vector2(0.55f, -0.26f);
            
            
            //InstantiationManager.GetComponent<InstantiationManagerScript>().InstantiateNewAxe();   This is done using an animation event on the EnzymeSubstrateComplex (after the bond has been stretched)

            GameObject.Find("LeftBond").GetComponent<BondToBreakScript>().EnergyThreshold = 0.20f;  //sets the EnergyThreshold that will be used in BondToBreak Script
            
            //ThrowTheAxeButton.interactable = true;
        }

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}

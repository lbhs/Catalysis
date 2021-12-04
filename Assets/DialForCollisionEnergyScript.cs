using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialForCollisionEnergyScript : MonoBehaviour  //This script is used to change the green zone displayed on the energy dial
{
    public GameObject GreenZone;
    public Sprite GreenZone90;
    public Sprite GreenZone20;
    public Sprite GreenZone43;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeGreenZoneTo90()  //this function is triggered from BondToBreakScript, line 115
    {
        GreenZone.GetComponent<SpriteRenderer>().sprite = GreenZone90;
        GreenZone.transform.localPosition = new Vector2(2.96f, -2.44f);
    }

    public void ChangeGreenZoneTo20()  //this function is called from EnzymeDraggingScript
    {
        GreenZone.GetComponent<SpriteRenderer>().sprite = GreenZone20;
        GreenZone.transform.localPosition = new Vector2(0.55f, -0.26f);
    }

    public void ChangeGreenZoneTo43()
    {
        GreenZone.GetComponent<SpriteRenderer>().sprite = GreenZone43;
        GreenZone.transform.localPosition = new Vector2(2.2f, -0.26f);
    }

}

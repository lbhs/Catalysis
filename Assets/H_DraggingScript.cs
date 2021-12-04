using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class H_DraggingScript : MonoBehaviour  //attached to the H+ Catalyst GameObject (the star)
{
    public bool IsDraggable;
    public Vector3 H_CatalystBondingPosition;
    

    // Start is called before the first frame update
    void Start()
    {
        IsDraggable = true;
        GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.x > 16 || gameObject.transform.position.x < -16)
        {
            RegenerateCatalyst();
        }

        if(gameObject.transform.position.y < -8)
        {
            RegenerateCatalyst();
        }
    }

    public void PositionTheCatalyst()  //this is called when the H+ ion is in the correct position to catalyze the breaking of the ether bond
    {
        IsDraggable = false;
        gameObject.transform.position = H_CatalystBondingPosition;  //this locks the catalyst in place atop the central oxygen atom
        //StartCoroutine(Countdown());
        gameObject.GetComponent<Rigidbody2D>().velocity = (new Vector2(0, 0));
        GameObject.Find("LeftBond").GetComponent<BondToBreakScript>().EnergyThreshold = 0.43f;  
        print("Ea barrier reduced");
        GameObject.Find("DialForCollisionEnergy").GetComponent<DialForCollisionEnergyScript>().ChangeGreenZoneTo43();

    }

    public void LetTheH_Float()
    {
        print("float begins");
        print("gameObject = " + gameObject);
        print(gameObject.GetComponent<Rigidbody2D>());
        IsDraggable = true;
        gameObject.transform.position = new Vector3 (transform.position.x, transform.position.y, -1);
        gameObject.GetComponent<Rigidbody2D>().velocity = (new Vector2(Random.Range (-1.2f,1.2f), -0.5f));            //(Random.Range(1f, 3f), Random.Range(-1f, 3f)));
        //if (GameObject.Find("LeftBond"))
        //{
        //    GameObject.Find("LeftBond").GetComponent<BondToBreakScript>().EnergyThreshold = 0.8f;  //ONLY NEEDED IF H+ IS ALLOWED TO FLOAT OFF THE CATALYTIC SITE. . .
        //    print("Ea Barrier restored");
        //}
        
        
    }

   

    public void RegenerateCatalyst()
    {
        gameObject.transform.position = new Vector2(-14, 7);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 0);
    }

    public IEnumerator Countdown()  //only used if the H+ has a limited time that it stays put. . .  
    {
        yield return new WaitForSeconds(5);
        LetTheH_Float();
        

        yield break;
    }

}

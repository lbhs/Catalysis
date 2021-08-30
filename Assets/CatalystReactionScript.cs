using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatalystReactionScript : MonoBehaviour
{
    public GameObject CatalystReactionProduct;
    public Vector2 CatalystPosition;
    public Animator Step1Animation;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        print("other collider = " + otherCollider);
        CatalystPosition = gameObject.transform.position;
        Instantiate(CatalystReactionProduct, CatalystPosition, Quaternion.identity);
        //otherCollider.GetComponent<SubstrateMoleculeScript>().SpawnProductMolecule();
        Step1Animation = GameObject.FindGameObjectWithTag("AnimatedComplex").GetComponent<Animator>();

        Step1Animation.SetTrigger("StartTheAnimation");


        //Destroy(gameObject);
        Destroy(otherCollider.gameObject);
    }



}

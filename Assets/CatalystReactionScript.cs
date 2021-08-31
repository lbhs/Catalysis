using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatalystReactionScript : MonoBehaviour
{
    public GameObject CatalystReactionProduct;  //This is the Animated Complex For Step #X  (e.g. Step1AnimatedComplex,  Step2AnimatedComplex)
    public Vector2 CatalystPosition;
    public Animator AnimatedComplexForThisStep;
    public string SubstrateTag;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D Substrate)
    {
        print("Substrate = " + Substrate);
        print("Substrate tag = " + Substrate.tag);

        if(Substrate.tag == SubstrateTag)
        {
            CatalystPosition = gameObject.transform.position;
            Instantiate(CatalystReactionProduct, CatalystPosition, Quaternion.identity);
            //otherCollider.GetComponent<SubstrateMoleculeScript>().SpawnProductMolecule();  //no longer valid, as the animated complex is a single GameObject containing both catalyst and substrate
            AnimatedComplexForThisStep = GameObject.FindGameObjectWithTag("AnimatedComplex").GetComponent<Animator>();

            AnimatedComplexForThisStep.SetTrigger("StartTheAnimation");

            Destroy(gameObject);   //this destroys the "CAT" or CAT complex
            Destroy(Substrate.gameObject);  //this destroys the substrate molecule, as both are replaced by the animated complex

        }
      
        
    }



}

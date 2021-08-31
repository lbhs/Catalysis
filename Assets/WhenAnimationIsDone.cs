using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenAnimationIsDone : MonoBehaviour  //THIS SCRIPT IS ATTACHED TO THE ANIMATED COMPLEXES (e.g. Step1AnimatedComplex).  Set "NextCatalystModel" in the prefab Animated Complex
{
    public GameObject NextCatalystModel;
    public Vector3 NextCatalystModelOffset;
    public GameObject NextSubstrateModel;
    public Vector3 NextSubstrateModelOffset;
    public Vector3 EulerAnglesForSubstrateModel;
    public GameObject ProductMoleculeCompleted;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void AnimationFinished()
    {
        print("Animation is finished");
        Vector2 NextCatalystModelPosition = gameObject.transform.position + NextCatalystModelOffset;  //new Vector3(-0.54f, 2.0f, 0);
        Instantiate(NextCatalystModel, NextCatalystModelPosition, Quaternion.identity);
        print("instantiated CAT at " + NextCatalystModelPosition);

        Vector2 NextSubstrateModelPosition = gameObject.transform.position + NextSubstrateModelOffset;
        Instantiate(NextSubstrateModel, NextSubstrateModelPosition, Quaternion.Euler(EulerAnglesForSubstrateModel));

        if(ProductMoleculeCompleted != null)
        {
            Instantiate(ProductMoleculeCompleted);
        }

        Destroy(gameObject);

        //NEED TO INSTANTIATE CATALYST-OH GAME OBJECT WITH OFFSET (-0.54, 2.0) RELATIVE TO POSITION OF ANIMATED COMPLEX.  

        //ALSO NEED TO INSTANTIATE OH RADICAL(B) WITH OFFSET (2, 6.5) RELATIVE TO POSITION OF ANIMATED COMPLEX
    }
}

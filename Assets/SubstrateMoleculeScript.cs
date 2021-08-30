using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubstrateMoleculeScript : MonoBehaviour
{
    public GameObject ReactionProduct;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnProductMolecule()
    {
        Instantiate(ReactionProduct, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

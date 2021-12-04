using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnzymeStretchingBondScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnzymeStretchingBond()  //called from the EnzymeSubstrateStretchAnimation
    {
        GameObject.Find("EnzymeStretchingBondSound").GetComponent<AudioSource>().Play();
    }

    public void InstantiateAxe()  //triggered from the EnzymeSubstrateStretchAnimation
    {
        GameObject.Find("InstantiationManager").GetComponent<InstantiationManagerScript>().InstantiateNewAxe();


    }

}

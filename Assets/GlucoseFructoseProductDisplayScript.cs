using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GlucoseFructoseProductDisplayScript : MonoBehaviour  //attached to Display Canvas game object. . .
{
    public GameObject ProductDisplayImage;
    public int NumberOfProductMolecules;
    public TMP_Text ProductCounterTextbox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowProductImage()
    {
        ProductDisplayImage.SetActive(true);
    }

   
}

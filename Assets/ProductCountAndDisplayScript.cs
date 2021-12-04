using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProductCountAndDisplayScript : MonoBehaviour  //Attached to ProductCountAndDisplayManager
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

    public void IncreaseProducts()  //function is called from AnimatedComplexScript
    {
        ProductDisplayImage.SetActive(true);
        NumberOfProductMolecules++;
        ProductCounterTextbox.text = "Products: <br>" + NumberOfProductMolecules + " glucose and <br>" + NumberOfProductMolecules + " fructose";

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigAxeIconScript : MonoBehaviour  //this script is attached to the BigAxe GameObject on the DisplayCanvas (child of AxeDisplay Prefab)
{
    public List<GameObject> IconList;
    public Sprite SuccessIcon;
    public Sprite FailureIcon;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowIcon(int BigAxeCount, int success)  //this function will activate the appropriate icon in the list of icons and make it either a green check or a red x
        //if success = 1, make it a green check. If success = 0, make it a red check
        //function is called from  AxeCountDisplayManagerScript
    {
        print("show icon");

        IconList[BigAxeCount].SetActive(true);

        if (success == 1)
        {
            IconList[BigAxeCount].GetComponent<Image>().sprite = SuccessIcon;
        }

        else
        {
            IconList[BigAxeCount].GetComponent<Image>().sprite = FailureIcon;
        }
    }
        


}

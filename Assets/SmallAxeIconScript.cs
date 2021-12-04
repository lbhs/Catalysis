using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmallAxeIconScript : MonoBehaviour  //this script is attached to the SmallAxeImage GameObject, a child of AxeDisplay on the Display Canvas
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

    public void ShowIcon(int SmallAxeCount, int success)  //this function will activate the appropriate icon in the list of icons and make it either a green check or a red x
                                                        //if success = 1, make it a green check. If success = 0, make it a red check
                                                        //function is called from  AxeCountDisplayManagerScript
    {
        print("show icon");

        IconList[SmallAxeCount].SetActive(true);

        if (success == 1)
        {
            IconList[SmallAxeCount].GetComponent<Image>().sprite = SuccessIcon;
        }

        else
        {
            IconList[SmallAxeCount].GetComponent<Image>().sprite = FailureIcon;
        }
    }

}

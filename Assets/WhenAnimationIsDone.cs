using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenAnimationIsDone : MonoBehaviour
{
    public GameObject CatalystOH;


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
        Instantiate(CatalystOH);
        //Destroy(gameObject);

        //NEED TO INSTANTIATE CATALYST-OH GAME OBJECT WITH OFFSET (-0.54, 2.0) RELATIVE TO POSITION OF ANIMATED COMPLEX.  
        //ALSO NEED TO INSTANTIATE OH RADICAL(B) WITH OFFSET (2, 6.5) RELATIVE TO POSITION OF ANIMATED COMPLEX
    }
}

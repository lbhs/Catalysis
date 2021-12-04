using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleScript : MonoBehaviour
{
    public int RotationAngle;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().MoveRotation(RotationAngle);
    }

    // Update is called once per frame
    void Update()
    {
    
    }



}

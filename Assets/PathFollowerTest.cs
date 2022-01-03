using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollowerTest : MonoBehaviour
{
    private PathFollower pathFollower;

    // Start is called before the first frame update
    void Start()
    {
        pathFollower = GetComponent<PathFollower>();
    }

    public void SufficientActivationEnergy()
    {
        pathFollower.MoveEnergyDiagramBall(53f, 47f);
    }

    public void InsufficientActivationEnergy()
    {
        pathFollower.MoveEnergyDiagramBall(47f, 53f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

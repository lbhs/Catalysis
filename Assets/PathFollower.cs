using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

// Path Creator Documentation: https://docs.google.com/document/d/1-FInNfD2GC-fVXO6KyeTSp9OSKst5AzLxDaBRb69b-Y/edit

public class PathFollower : MonoBehaviour
{
    #region Inspector Variables
    public PathCreator pathCreator;
    public float speedScale;
    #endregion

    private float time = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    #region Public Methods
    public void MoveEnergyDiagramBall(float providedActivationEnergy, float requiredActivationEnergy)
    {
        float targetPos;
        if (providedActivationEnergy < requiredActivationEnergy)
        {
            targetPos = Mathf.Lerp(0f, 0.3f, providedActivationEnergy / requiredActivationEnergy);
        }
        else
        {
            targetPos = 1f;
        }

        StartCoroutine(MoveToGivenTrackTime(targetPos));
    }

    public void ResetEnergyDiagramBall()
    {
        transform.position = pathCreator.path.GetPointAtTime(0f);
        time = 0f;
    }
    #endregion

    // targetTime ranges between 0 & 1
    private IEnumerator MoveToGivenTrackTime(float targetTime)
    {
        Vector3 currentPos = pathCreator.path.GetPointAtTime(time, EndOfPathInstruction.Stop);
        Vector3 targetPos = pathCreator.path.GetPointAtTime(targetTime, EndOfPathInstruction.Stop);

        while (currentPos.x < targetPos.x)
        {
            time += speedScale * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtTime(time, EndOfPathInstruction.Stop);
            currentPos = transform.position;
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}

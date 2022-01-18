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
    public IEnumerator MoveEnergyDiagramBall(float providedActivationEnergy, float requiredActivationEnergy)
    {
        if (providedActivationEnergy < requiredActivationEnergy)
        {
            // Even if the object is scaled, 0.3 represents a time (proportion) on the path
            float targetPos = Mathf.Lerp(0f, 0.3f, providedActivationEnergy / requiredActivationEnergy);

            // Move up to the crest of the hill
            yield return StartCoroutine(MoveToGivenTrackTime(targetPos));
            yield return new WaitForSeconds(1f);
            // Return to the base
            yield return StartCoroutine(MoveToGivenTrackTime(0f));
        }
        else
        {
            // Travel to the end of the path
            yield return StartCoroutine(MoveToGivenTrackTime(1f));
        }
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

        int direction = currentPos.x < targetPos.x ? 1 : -1;

        while (true)
        {
            // Moving backwards and the object is at or behind the requested position
            if (direction == -1 && currentPos.x <= targetPos.x)
                break;

            // Moving forwards and the object is at or ahead of the requested position
            if (direction == 1 && targetPos.x <= currentPos.x)
                break;

            time += direction * speedScale * Time.deltaTime;

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

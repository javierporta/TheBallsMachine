using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedBall : MonoBehaviour
{
    private bool hasToBeDeactivated=false;

    private float secondsToWaitUntilBallIsOut = 2f;

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }



    private void OnBecameInvisible()
    {
        hasToBeDeactivated = true;

        StartCoroutine(ExecuteCleaningAfterTime(secondsToWaitUntilBallIsOut));
    }

    private void OnBecameVisible()
    {
        hasToBeDeactivated = false;
    }

    IEnumerator ExecuteCleaningAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        if (hasToBeDeactivated)
        {
            Deactivate();
            GameManager.Instance.CheckIfLevelHasFinished();
        }
    }
}

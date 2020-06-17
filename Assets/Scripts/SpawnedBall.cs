using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedBall : MonoBehaviour
{
    

    private void OnEnable()
    {
        //ToDo: Spawned time live not necessary. It should die when go outside camera
        // Invoke(nameof(Deactivate), timeToLive);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }



    private void OnBecameInvisible()
    {
        Deactivate();
        GameManager.Instance.CheckIfLevelHasFinished();
    }
}

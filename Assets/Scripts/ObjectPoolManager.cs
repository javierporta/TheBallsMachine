using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager Instance { get; private set; } = null;

    [SerializeField]
    private GameObject spawnedBall;

    [SerializeField]
    private int initialAmountOfSpawnedBalls = 21; //ToDo: can we calclate this number automatically? Counting the number of prefabs and multiplying by balls spawned

    [SerializeField]
    private bool poolCanGrow = true;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        for (int i = 0; i < initialAmountOfSpawnedBalls; i++)
        {
            GameObject spawnedBallGameObject = Instantiate(spawnedBall, transform);
            spawnedBallGameObject.SetActive(false);
        }
    }

    public GameObject GetSpawnedBall()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            if (!child.activeInHierarchy)
            {
                return child;
            }
        }

        if (poolCanGrow)
        {
            GameObject newSpawnedBall = Instantiate(spawnedBall, transform);
            initialAmountOfSpawnedBalls++;
            return newSpawnedBall;
        }
        else
        {
            return null;
        }
    }
}


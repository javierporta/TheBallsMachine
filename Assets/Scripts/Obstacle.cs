using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private int obstacleLife = 5;

    [SerializeField]
    private Text lifeText;

    [SerializeField]
    private int ballsToSpawn = 3;

    [SerializeField]
    private float spawnedBallSpeed = 5f;

    [SerializeField]
    private GameObject ballPrefab;

    private void Awake()
    {
        lifeText.text = obstacleLife.ToString();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("MainBall"))
        {
            if (obstacleLife > 0)
            {
                SpawnBalls();
            }
        }

        if (col.gameObject.CompareTag("Ball") || col.gameObject.CompareTag("MainBall"))
        {
            if (obstacleLife > 1)
            {
                //TODO: Play sound

                obstacleLife--;
                lifeText.text = obstacleLife.ToString();
            }
            else
            {
                //ToDo: animation, explotion, sound, sum extra score!
                //dissapear
                Destroy(gameObject);

            }


        }
    }

    private void SpawnBalls()
    {
        GameObject ball = Instantiate(ballPrefab, transform.position, transform.rotation);
        ball.GetComponent<Rigidbody2D>().velocity = (transform.right) * spawnedBallSpeed;
    }
}

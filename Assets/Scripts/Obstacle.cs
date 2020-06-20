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
    private float spawnedBallSpeed = 7f;

    private int hitScore = 10;

    private int initialObstacleLife;


    private void Awake()
    {
        lifeText.text = obstacleLife.ToString();
        initialObstacleLife = obstacleLife;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("MainBall"))
        {
            if (obstacleLife > 0)
            {
                
                SpawnBalls(col);
            }
        }

        if (col.gameObject.CompareTag("Ball") || col.gameObject.CompareTag("MainBall"))
        {
            if (obstacleLife > 1)
            {
                BallsAudioManager.Instance.PlayHitSound();

                obstacleLife--;
                lifeText.text = obstacleLife.ToString();
                GameManager.Instance.AddScore(hitScore);
            }
            else
            {
                //ToDo: animation, explotion
                BallsAudioManager.Instance.PlayExplosionSound();

                //sum extra score!
                var destroyScore = hitScore * initialObstacleLife;
                GameManager.Instance.AddScore(destroyScore);

                //Object is gone
                Destroy(gameObject);
            }


        }
    }

    private void SpawnBalls(Collision2D col)
    {
        //ToDo: make it changeable
        var x = -1;
        for (int ballIndex = 0; ballIndex < ballsToSpawn; ballIndex++)
        {
            GameObject ball = ObjectPoolManager.Instance.GetSpawnedBall();
            ball.transform.position = col.transform.position;
            ball.transform.rotation = col.transform.rotation;
            ball.SetActive(true);
            ball.GetComponent<Rigidbody2D>().velocity = new Vector2(x, 1) * spawnedBallSpeed;
            x++;
        }
    }
}

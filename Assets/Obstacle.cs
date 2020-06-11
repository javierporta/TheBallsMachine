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

    private void Awake()
    {
        lifeText.text = obstacleLife.ToString();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ball"))
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
}

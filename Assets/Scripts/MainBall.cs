using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBall : MonoBehaviour
{
    public static MainBall Instance { get; private set; } = null;

    private Rigidbody2D ballRigidbody;
    [SerializeField]
    private float speed = 3.5f;

    private bool wasBallThrown = false;

    public bool HasBallFellDown = false;

    private void Awake()
    {
        ballRigidbody = GetComponent<Rigidbody2D>();

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (!wasBallThrown)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");

            if (Input.GetButtonDown("Fire1"))
            {
                ThrowBall();
            }


            ballRigidbody.velocity =
                  new Vector2(horizontalInput * speed,
                  ballRigidbody.velocity.y
                  );
        }
    }

    private void ThrowBall()
    {
        ballRigidbody.gravityScale = 1;
        wasBallThrown = true;
    }

    private void OnBecameInvisible()
    {
        HasBallFellDown = true;
        GameManager.Instance.CheckIfLevelHasFinished();

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class RoboticArm : MonoBehaviour
{

    private Animator myAnimator;

    private bool idOpen = false;

    private Rigidbody2D myRigidbody;

    [SerializeField]
    private float speed = 3.5f;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>(); 
    }

    private void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire1") && !idOpen)
        {
            myAnimator.SetTrigger("open_arm");
            idOpen = true;
        }
    }

    public void HorizontalMov(float horizontalInput) 
    {
        myRigidbody.velocity =
                 new Vector2(horizontalInput * speed,
                 myRigidbody.velocity.y
                 );
    }

    private void StopAnimation() //called by animation event
    {
        //Object is gone
        myAnimator.SetTrigger("open_arm_stop");
    }
}

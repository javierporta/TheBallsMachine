using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class RoboticArm : MonoBehaviour
{

    private Animator myAnimator;

    private bool idOpen = false;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = CrossPlatformInputManager.GetAxisRaw("Horizontal");

        if (CrossPlatformInputManager.GetButtonDown("Fire1") && !idOpen)
        {
            myAnimator.SetTrigger("open_arm");
            idOpen = true;
        }
    }

    private void StopAnimation() //called by animation event
    {
        //Object is gone
        myAnimator.SetTrigger("open_arm_stop");
    }
}

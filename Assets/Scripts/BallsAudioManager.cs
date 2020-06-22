using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsAudioManager : MonoBehaviour
{
    public static BallsAudioManager Instance { get; private set; } = null;
    
    private AudioSource myAudioSource;

    [SerializeField]
    private AudioClip hitAudioClip;

    [SerializeField]
    private AudioClip destroyAudioClip;

    [SerializeField]
    private AudioClip servoMotorAudioClip;

    private void Awake()
    {
        myAudioSource = GetComponent<AudioSource>();

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void PlayExplosionSound()
    {
        myAudioSource.PlayOneShot(destroyAudioClip);
    }

    public void PlayHitSound()
    {
        myAudioSource.PlayOneShot(hitAudioClip);
    }

    public void PlayServoMotorSound()
    {
        myAudioSource.PlayOneShot(servoMotorAudioClip);
    }
}


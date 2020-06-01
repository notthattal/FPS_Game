using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool isWalking = false;
    AudioSource audioSource = default;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        CheckMovement();
        if (isWalking && audioSource.isPlaying == false)
        {
            audioSource.Play();
        }
    }

    private void CheckMovement()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
            audioSource.Stop();
        }
    }
}

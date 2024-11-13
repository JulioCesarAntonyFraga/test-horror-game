using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceGateClose : MonoBehaviour
{
    private Animator gateAnimator;
    private AudioSource gateCloseAudioSource;
    void Start()
    {
        gateAnimator = GetComponent<Animator>();
        gateCloseAudioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && gateAnimator.GetBool("IsOpened"))
        {
            gateAnimator.SetTrigger("Close");
            gateCloseAudioSource.Play();
        }
    }

    public void OnGateClosed()
    {
        gateAnimator.SetBool("IsOpened", false);
    }
}

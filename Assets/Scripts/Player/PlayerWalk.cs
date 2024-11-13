using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    public float speed = 5.0f;
    public float stepRate = 0.5f;

    private float horizontalInput;
    private float verticalInput;
    private float stepCoolDown;

    private Transform playerTransform;
    public AudioClip footStep;
    public AudioSource footStepSource;
    private Player player;

    void Start()
    {
        playerTransform = GetComponent<Transform>();
        player = GetComponent<Player>();
    }

    void Update()
    {
        if (!player.canMove) return;
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        playerTransform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        playerTransform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);

        stepCoolDown -= Time.deltaTime;

        if ((horizontalInput != 0 || verticalInput != 0) && stepCoolDown < 0f)
        {
            footStepSource.pitch = 1f + Random.Range(-0.2f, 0.2f);
            footStepSource.PlayOneShot(footStep, 0.9f);
            stepCoolDown = stepRate;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public float Sensitivity
    {
        get { return sensitivity; }
        set { sensitivity = value; }
    }

    [Range(0.1f, 9f)]
    [SerializeField] 
    float sensitivity = 2f;

    [Tooltip("Limits vertical camera rotation. Prevents the flipping that happens when rotation goes above 90.")]
    [Range(0f, 90f)]
    [SerializeField] 
    float yRotationLimit = 88f;

    Vector2 rotation = Vector2.zero;
    const string xAxis = "Mouse X";
    const string yAxis = "Mouse Y";

    private Transform playerCameraTransform;
    Player player;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        playerCameraTransform = GetComponentInChildren<Camera>().GetComponent<Transform>();
        player = GetComponent<Player>();
    }

    void Update()
    {
        if (!player.canLook) return;
        rotation.x += Input.GetAxis(xAxis) * sensitivity;
        rotation.y += Input.GetAxis(yAxis) * sensitivity;

        rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);

        var xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
        var yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);

        playerCameraTransform.localRotation = yQuat;
        transform.localRotation = xQuat;
    }
}

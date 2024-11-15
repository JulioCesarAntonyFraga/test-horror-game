using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipItem : MonoBehaviour
{
    GameObject equipedItem;
    Camera camera;

    public float distanceToCamera = 1f;
    public float xPositionInCamera = 0.2f;
    public float yPositionInCamera = 0.2f;

    private void Start()
    {
        camera = Camera.main;
    }

    public void Equip(PickableItem item)
    {
        Debug.Log($"Equipping {item.Name}");

        if (equipedItem != null)
        {
            Destroy(equipedItem);
        }

        Vector3 itemPosition = transform.position + new Vector3(xPositionInCamera, yPositionInCamera, distanceToCamera);

        equipedItem = Instantiate(item.Prefab, itemPosition, Quaternion.Euler(Vector3.zero), camera.transform);
        equipedItem.layer = LayerMask.NameToLayer("Equiped Items");
        equipedItem.GetComponent<MeshCollider>().enabled = false;
        equipedItem.GetComponent<Transform>().localRotation = Quaternion.Euler(Vector3.forward);
        equipedItem.GetComponent<MeshRenderer>().receiveShadows = false;
        equipedItem.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
    }
}

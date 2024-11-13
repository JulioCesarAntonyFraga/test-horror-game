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

        equipedItem = Instantiate(item.Prefab, camera.transform.position + new Vector3(xPositionInCamera, yPositionInCamera, distanceToCamera), Quaternion.Euler(Vector3.up), transform);
        equipedItem.AddComponent<EquipedItem>();
    }
}

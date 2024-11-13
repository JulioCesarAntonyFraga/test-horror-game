using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject playerObj;
    public bool isOpened = false;

    public void AddItem(PickableItem item)
    {
        GameObject itemUI = new GameObject();
        itemUI.name = item.Name;

        Image itemIcon = itemUI.AddComponent<Image>();
        itemIcon.sprite = item.Icon;

        itemUI.GetComponent<RectTransform>().SetParent(transform);
    }

    public void OpenInventory()
    {
        isOpened = true;
        gameObject.SetActive(true);
    }

    public void CloseInventory()
    {
        isOpened = false;
        gameObject.SetActive(false);
    }
}

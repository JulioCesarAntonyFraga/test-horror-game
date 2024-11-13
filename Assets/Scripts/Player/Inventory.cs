using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<PickableItem> items = new List<PickableItem>();
    public GameObject inventoryUIObj;
    private InventoryUI inventoryUI;
    private Player player;

    private void Start()
    {
        player = GetComponent<Player>();
        inventoryUI = inventoryUIObj.GetComponent<InventoryUI>();
    }

    public void AddItem(PickableItem item)
    {
        items.Add(item);
        inventoryUI.AddItem(item);
    }

    public void RemoveItem(PickableItem item) 
    {
        items.Remove(item);
    }

    private void Update()
    {
        //TODO: replace with input manager
        if (Input.GetKeyDown(KeyCode.E) && !inventoryUI.isOpened && !player.isReadingLetter)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            player.canMove = false;
            player.canLook = false;
            player.inventoryOpened = true;
            inventoryUI.OpenInventory();
        }
        else if (Input.GetKeyDown(KeyCode.E) && inventoryUI.isOpened)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            player.canMove = true;
            player.canLook = true;
            player.inventoryOpened = false;
            inventoryUI.CloseInventory();
        }
    }
}

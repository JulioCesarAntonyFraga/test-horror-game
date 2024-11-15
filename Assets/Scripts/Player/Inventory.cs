using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    public List<PickableItem> items = new List<PickableItem>();
    public GridLayoutGroup inventoryUI;
    private Player player;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    public void AddItem(PickableItem item)
    {
        items.Add(item);

        GameObject itemUI = new GameObject();
        itemUI.name = item.Name;

        var inventoryButton = AddInventoryButton(itemUI, item.ItemImage);

        itemUI.GetComponent<RectTransform>().SetParent(inventoryUI.transform);
    }

    public void AddLetter(PickableLetter letter)
    {
        items.Add(letter);

        GameObject itemUI = new GameObject();
        itemUI.name = letter.Name;

        Button inventoryButton = AddInventoryButton(itemUI, letter.ItemImage);

        inventoryButton.onClick.AddListener(() => letter.ShowLetter());
        inventoryButton.onClick.AddListener(() => CloseInventory());
        inventoryButton.onClick.AddListener(() => player.DisablePlayer(false));

        itemUI.GetComponent<RectTransform>().SetParent(inventoryUI.transform);
    }

    public void RemoveItem(PickableItem item) 
    {
        items.Remove(item);
    }

    public void OpenInventory()
    {
        player.DisablePlayer(true);
        player.inventoryOpened = true;
        inventoryUI.gameObject.SetActive(true);
    }

    public void CloseInventory()
    {
        player.EnablePlayer();
        player.inventoryOpened = false;
        inventoryUI.gameObject.SetActive(false);
    }

    private Button AddInventoryButton(GameObject UIObject, Sprite image)
    {
        Button itemButton = UIObject.AddComponent<Button>();
        itemButton.AddComponent<Image>();
        itemButton.GetComponent<Image>().sprite = image;

        return itemButton;
    }
   
    private void Update()
    {
        //TODO: replace with input manager
        if (Input.GetKeyDown(KeyCode.E) && !player.inventoryOpened && !player.isReadingLetter)
        {
            OpenInventory();
        }
        else if (Input.GetKeyDown(KeyCode.E) && player.inventoryOpened)
        {
            CloseInventory();
        }
    }
}

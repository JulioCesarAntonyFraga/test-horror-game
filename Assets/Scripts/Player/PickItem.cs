using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItem : MonoBehaviour
{
    private Inventory inventory;
    private Player player;
    private EquipItem equipItem;
    public float pickRange = 2f;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GetComponent<Inventory>();
        player = GetComponent<Player>();
        equipItem = GetComponent<EquipItem>();
    }

    // Update is called once per frame
    void Update()
    {
        var raycast = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, pickRange);

        if (Input.GetMouseButtonDown(1)) 
        {
            inventory.items.ForEach(item => Debug.Log(item.Name));
        }

        if (hit.collider != null)
        {
            var pickableItem = hit.collider.GetComponent<PickableItem>();

            if (pickableItem != null)
            {
                //TODO: Use new input system here
                if (Input.GetMouseButtonDown(0) && !player.inventoryOpened && !player.isReadingLetter)
                {
                    var letter = hit.collider.GetComponent<PickableLetter>();

                    if (letter == null)
                    {
                        inventory.AddItem(pickableItem);
                        equipItem.Equip(pickableItem);
                    }
                    else
                    {
                        inventory.AddLetter(letter);
                    }
                    Destroy(pickableItem.gameObject);
                }
            }
        }
    }
}

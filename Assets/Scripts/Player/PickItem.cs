using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItem : MonoBehaviour
{
    private Inventory inventory;
    private Player player;
    public float pickRange = 2f;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GetComponent<Inventory>();
        player = GetComponent<Player>();
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
                    if (pickableItem.GetComponent<PickableLetter>() != null)
                    {
                        var letter = pickableItem.GetComponent<PickableLetter>();

                        if (!letter.isShowing)
                        {
                            inventory.AddItem(pickableItem);
                            pickableItem.GetComponent<PickableLetter>().ShowLetter();
                        }
                    }
                    else
                    {
                        inventory.AddItem(pickableItem);
                        Destroy(pickableItem.gameObject);
                    }
                }
            }
        }
    }
}

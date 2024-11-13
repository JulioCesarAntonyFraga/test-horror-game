using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickableLetter : MonoBehaviour
{
    public GameObject letter;
    public GameObject playerObj;
    private Player player;

    public bool isShowing = false;

    private void Start()
    {
        player = playerObj.GetComponent<Player>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isShowing)
        {
            DismissLetter();
        }
    }

    public void ShowLetter()
    {
        isShowing = true;
        player.canMove = false;
        player.canLook = false;
        player.isReadingLetter = true;
        letter.SetActive(true);
    }

    public void DismissLetter()
    {
        var player = playerObj.GetComponent<Player>();
        player.canMove = true;
        player.canLook = true;
        player.isReadingLetter = false;
        letter.SetActive(false);
        Destroy(gameObject);
    }
}

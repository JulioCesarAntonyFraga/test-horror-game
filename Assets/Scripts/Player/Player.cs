using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool canMove = true;
    public bool canLook = true;
    public bool isReadingLetter = false;
    public bool inventoryOpened = false;

    public void DisablePlayer(bool keepMouse)
    {
        Cursor.visible = keepMouse;
        Cursor.lockState = keepMouse ? CursorLockMode.None : CursorLockMode.Locked;
        canMove = false;
        canLook = false;
    }

    public void EnablePlayer()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        canMove = true;
        canLook = true;
    }
}

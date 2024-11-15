using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILetter : MonoBehaviour
{
    internal Player player;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DismissLetter();
        }
    }

    public void DismissLetter()
    {
        player.EnablePlayer();
        player.isReadingLetter = false;

        Destroy(gameObject);
    }
}

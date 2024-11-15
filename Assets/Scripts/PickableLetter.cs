using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class PickableLetter : PickableItem
{
    public Canvas lettersCanva;
    public Player player;

    public float letterWidthInCanvas = 200;
    public float letterHeightInCanvas = 200;

    public void ShowLetter()
    {
        player.isReadingLetter = true;
        var image = new GameObject();
        image.transform.parent = lettersCanva.transform;

        image.name = Name;
        image.AddComponent<Image>();
        image.GetComponent<Image>().sprite = ItemImage;
        image.GetComponent<RectTransform>().sizeDelta = new Vector2(letterWidthInCanvas, letterHeightInCanvas);
        image.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        image.AddComponent<UILetter>();

        var uiLetter = image.GetComponent<UILetter>();
        uiLetter.player = player;

        player.DisablePlayer(false);
    }

    
}

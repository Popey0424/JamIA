using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButton : MonoBehaviour
{
    public Image ImageOutline;

    public void OnPointerEnter()
    {
        Color color = ImageOutline.color;
        color.a = 1;
        ImageOutline.color = color;
    }

    public void OnPointerExit()
    {
        Color color = ImageOutline.color;
        color.a = 0;
        ImageOutline.color = color;
    }
}

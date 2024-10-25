using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class MainMenuButton3 : MonoBehaviour
{
    public Image ImageOutline;
    public TMP_Text UITextMeshPro;
    public Color InitialColor, OverColor;

    public void OnPointerEnter()
    {
        ImageOutline.DOKill();
        ImageOutline.DOFade(1, 0.3f);
        UITextMeshPro.DOKill();
        UITextMeshPro.DOColor(OverColor, 0.3f);

    }

    public void OnPointerExit()
    {
        ImageOutline.DOKill();
        ImageOutline.DOFade(0, 0.2f);
        UITextMeshPro.DOKill();
        UITextMeshPro.DOColor(InitialColor, 0.2f);
    }
}

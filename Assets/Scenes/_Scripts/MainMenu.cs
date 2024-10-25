using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class MainMenu : MonoBehaviour
{
    public Image ImageFade;
    public List<MainMenuButton> Buttons;

    private void Start()
    {
        ImageFade.DOFade(0, 0);
        ImageFade.gameObject.SetActive(false);
    }
    public void OnClickPlay()
    {
        ImageFade.gameObject.SetActive(true);
        ImageFade.DOFade(1, 0.8f).OnComplete(LoadGame);
    }

    private void LoadGame()
    {
        SceneManager.LoadScene("GameplayLouis");
    }
}

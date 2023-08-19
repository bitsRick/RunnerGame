

using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class DisplayGameOver:MonoBehaviour
{
    [SerializeField] private Button _buttonResetGame;   
    [SerializeField] private Button _buttonExitGame;
    [SerializeField] private Player _player;

    private CanvasGroup _canvasGroup;

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0;
    }

    private void OnEnable()
    {
        _player.Died += ShowUiGameOver;
        _buttonResetGame.onClick.AddListener(OnClickButtonReset);
        _buttonExitGame.onClick.AddListener(OnClickButtonExit);
    }

    private void OnDisable()
    {
        _player.Died -= ShowUiGameOver;
        _buttonResetGame.onClick.RemoveListener(OnClickButtonReset);
        _buttonExitGame.onClick.RemoveListener(OnClickButtonExit);
    }

    private void ShowUiGameOver()
    {
        Time.timeScale = 0;
        _canvasGroup.alpha = 1;
    }

    private void OnClickButtonReset() 
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    private void OnClickButtonExit() 
    {
        Application.Quit();
    }
}
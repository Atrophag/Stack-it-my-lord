using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;

    private GameObject _gameInterface;
    private bool _paused = false;

    public void Start()
    {
        _gameInterface = GameObject.Find("Game Interface");
        TogglePanel(_paused);
    }

    public void Pause()
    {
        _paused = !_paused;
        Time.timeScale = _paused ? 0f : 1f;
        TogglePanel(_paused);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    private void TogglePanel(bool active)
    {
        _gameInterface.SetActive(!active);
        pausePanel.SetActive(active);
    }
}

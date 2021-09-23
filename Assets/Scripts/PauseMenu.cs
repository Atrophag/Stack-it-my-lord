using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    private bool _paused = false;

    public void Start()
    {
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
        pausePanel.SetActive(active);
    }
}

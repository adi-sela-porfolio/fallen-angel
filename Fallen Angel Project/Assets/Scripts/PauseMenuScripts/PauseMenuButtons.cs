using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuButtons : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu;
    [SerializeField] AudioSource gameMusic;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void PauseButton()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void HomeButton()
    {
        SceneManager.LoadScene("OpeningScene");
        Time.timeScale = 1;
    }

    public void ResumeButton()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }


    public void MusicSlider(float value)
    {
        gameMusic.volume = value;
    }
}

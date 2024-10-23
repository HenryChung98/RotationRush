using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class ButtonManagerInGame : MonoBehaviour
{
    [SerializeField] private GameObject pauseBox;
    [SerializeField] private GameObject canvasPanel;
    [SerializeField] private GameObject gameOverBox;
    private GameManager gameManger;



    private void Start()
    {
        gameManger = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void PauseButton()
    {
        pauseBox.SetActive(true);
        canvasPanel.SetActive(true);
        gameManger.audioSource.volume = gameManger.audioVolume / 2;
        Time.timeScale = 0f;
    }
    public void ResumeButton()
    {
        pauseBox.SetActive(false);
        canvasPanel.SetActive(false);
        gameManger.audioSource.volume = gameManger.audioVolume;
        Time.timeScale = 1f;
    }
    public void RestartButton()
    {
        pauseBox.SetActive(false);
        canvasPanel.SetActive(false);
        gameOverBox.SetActive(false);
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
        Destroy(gameManger.gameObject);
        gameManger.setGameOver = false;
        Time.timeScale = 1f;
    }
    public void GoToMainMenu()
    {
        Destroy(gameManger.gameObject);
        SceneManager.LoadScene("MainMenuScene");
        Time.timeScale = 1f;
    }
}

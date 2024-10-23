using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score = 0;
    public int bestScore = 0;
    public bool setGameOver = false;

    // get components
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private GameObject gameOverBox;
    [SerializeField] private TextMeshProUGUI scoreTextInGameOver;

    // audio
    public GameObject audioObject;
    public AudioSource audioSource;
    public float audioVolume = 0.7f;

    

    private void Awake()
    {
        Time.timeScale = 1f;
        audioSource = audioObject.GetComponent<AudioSource>();
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource.volume = audioVolume;
            audioSource.Play();
        }
        else
        {
            Destroy(gameObject);
        }

    }
    void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        StartCoroutine(GetScorePerSec());
    }
    void Update()
    {
        scoreText.text = "Score: " + instance.score;
        bestScoreText.text = "Best Score: " + bestScore;
        scoreTextInGameOver.text = instance.score.ToString();
        if (setGameOver)
        {
            gameOverBox.SetActive(true);
            audioSource.volume = audioVolume / 2;
        }
    }
    public void AddScore(int points)
    {
        score += points;
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore); // save best score
        }
    }
    IEnumerator GetScorePerSec()
    {
        while (!setGameOver) { 
            AddScore(1);
            yield return new WaitForSeconds(0.5f);
        }
    }


}

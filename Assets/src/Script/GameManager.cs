using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private float gameSpeed = 5f;
    [SerializeField]
    private float speedIncrease = 0.15f;
    [SerializeField] private TextMeshProUGUI scoreText;
    private float score = 0;
    [SerializeField] private GameObject scoreTextObject;
    [SerializeField] private GameObject gameStartMess;
    [SerializeField] private GameObject gameOverMess;
    [SerializeField] private GameObject screenPause;
    [SerializeField] private GameObject buttonReturn;
    [SerializeField] private GameObject buttonMenu;
    private bool isGameOver = false;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        StartGame();
    }

    public float GetGameSpeed()
    {
        return gameSpeed;
    }
    
    void Update()
    {
        if (!isGameOver)
        {
            UpdateGameSpeed();
            nhanEnter();
            UpdateScore();
        }
        

    }
    private void UpdateGameSpeed()
    {
        gameSpeed += Time.deltaTime * speedIncrease;
    }
    private void UpdateScore()
    {
        score += Time.deltaTime;
        scoreText.text = "Score: " + Mathf.FloorToInt(score);
        if(score == 20)
        {
            score = 0;
        }
    }
    private void StartGame()
    {
        Time.timeScale = 0;
        scoreTextObject.SetActive(false);
        gameStartMess.SetActive(true);
        gameOverMess.SetActive(false);
    }
    private void nhanEnter()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Time.timeScale = 1;
            scoreTextObject.SetActive(true);
            gameStartMess.SetActive(false);
        }
    }
    public void GameOver()
    {
        isGameOver = true;
        gameOverMess.SetActive(true);
        Time.timeScale = 0;
        StartCoroutine(Tai_lai_Scene());
    }
    private IEnumerator Tai_lai_Scene()
    {
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        screenPause.SetActive(true);
        buttonMenu.SetActive(true);
        buttonReturn.SetActive(true);   
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Time.timeScale = 1;
            screenPause.SetActive(false);
            buttonMenu.SetActive(false);
            buttonReturn.SetActive(false);
        }

    }
    //public void quitGame()
    //{
    //    Application.Quit();
    //}
    public void ReturnMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void ReturnGame()
    {
        Time.timeScale = 1;
        scoreTextObject.SetActive(true);
        gameStartMess.SetActive(false);
        screenPause.SetActive(false);
        buttonMenu.SetActive(false);
        buttonReturn.SetActive(false);
    }
}

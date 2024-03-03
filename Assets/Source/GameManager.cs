using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;
    public int lives = 3;

    public Text scoreText;
    public GameObject[] lifeIcons;

    private void Awake()
    {
        // ���������, ��� ���������� ������ ���� ��������� GameManager
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        // �� ���������� ��� �������� ����� �����
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        UpdateScoreText();
        UpdateLivesDisplay();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    public void LoseLife()
    {
        if (lives > 0)
        {
            lives--;
            UpdateLivesDisplay();
            // ����� �������� ������ �������� ������ ��� ��������� ������������

            if (lives <= 0)
            {
                GameOver();
            }
        }
    }

    private void UpdateLivesDisplay()
    {
        for (int i = 0; i < lifeIcons.Length; i++)
        {
            if (i < lives)
            {
                lifeIcons[i].SetActive(true);
            }
            else
            {
                lifeIcons[i].SetActive(false);
            }
        }
    }

    private void GameOver()
    {
        // �������� ����� ���������
        // SceneManager.LoadScene("GameOverScene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void WinGame()
    {
        // �������� ����� ������
        // SceneManager.LoadScene("WinScene");
    }

    // ������ ��� ������ UI
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        lives = 3;
        score = 0;
        UpdateScoreText();
        UpdateLivesDisplay();
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
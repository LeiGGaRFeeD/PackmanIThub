using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int lives = 3;
    public GameObject[] lifeIcons;
    public int totalBonuses = 0; // ����� ���������� ������� �� ������
    private int collectedBonuses = 0; // ���������� ��������� �������

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // ���������, ��� GameManager �� ������������ ��� �������� ����� �����
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        totalBonuses = FindObjectsOfType<Bonus>().Length;
        ScoreManager.instance.UpdateScoreText(); // ��������� ����� ����� ����� ScoreManager
        UpdateLivesDisplay();
    }

    public void CollectBonus(int points)
    {
        ScoreManager.instance.AddScore(points); // ��������� ���� ����� ScoreManager
        collectedBonuses++;

        // ���������, ������� �� ��� ������
        if (collectedBonuses > totalBonuses)
        {
            WinGame();
        }
    }

    public void LoseLife()
    {
        if (lives > 0)
        {
            lives--;
            UpdateLivesDisplay();

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
            lifeIcons[i].SetActive(i < lives);
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // ������������ ������� �����
    }

    public void WinGame()
    {
        Debug.Log("Game win"); // ����� ����� ��������� ����� ������
    }

    // ������ ��� ������ UI
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        lives = 3;
        ScoreManager.instance.score = 0; // ����� ����� ����� ScoreManager
        ScoreManager.instance.UpdateScoreText(); // ��������� ����� ����� ����� ScoreManager
        UpdateLivesDisplay();
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
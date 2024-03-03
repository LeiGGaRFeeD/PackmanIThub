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
    public int totalBonuses = 0; // Общее количество бонусов на уровне
    private int collectedBonuses = 0; // Количество собранных бонусов

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Убедитесь, что GameManager не уничтожается при загрузке новой сцены
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        totalBonuses = FindObjectsOfType<Bonus>().Length;
        ScoreManager.instance.UpdateScoreText(); // Обновляем текст счета через ScoreManager
        UpdateLivesDisplay();
    }

    public void CollectBonus(int points)
    {
        ScoreManager.instance.AddScore(points); // Добавляем очки через ScoreManager
        collectedBonuses++;

        // Проверяем, собраны ли все бонусы
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Перезагрузка текущей сцены
    }

    public void WinGame()
    {
        Debug.Log("Game win"); // Здесь можно загрузить сцену победы
    }

    // Методы для кнопок UI
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        lives = 3;
        ScoreManager.instance.score = 0; // Сброс счета через ScoreManager
        ScoreManager.instance.UpdateScoreText(); // Обновляем текст счета через ScoreManager
        UpdateLivesDisplay();
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
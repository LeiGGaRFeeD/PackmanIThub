using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;
    public Text scoreText;
    public int pointsPerBonus = 10; // Количество очков за каждый бонус
    private int totalBonuses; // Общее количество бонусов на уровне
    private int collectedBonuses = 0; // Количество собранных бонусов

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateScoreText();
        // Инициализация totalBonuses
        totalBonuses = FindObjectsOfType<Bonus>().Length;
    }

    public void AddScore(int bonusPoints)
    {
        score += bonusPoints;
        UpdateScoreText();
        collectedBonuses++; // Увеличиваем количество собранных бонусов

        // Проверяем, собраны ли все бонусы
        if (collectedBonuses >= totalBonuses)
        {
            GameManager.instance.WinGame(); // Вызываем WinGame из GameManager
        }
    }

    public void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
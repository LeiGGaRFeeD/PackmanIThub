using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField]public int score = 0;
    [SerializeField] private Text scoreText;
    [SerializeField] public int pointsPerBonus = 10; // ���������� ����� �� ������ �����
    [SerializeField] private int totalBonuses; // ����� ���������� ������� �� ������
    [SerializeField] private int collectedBonuses = 0; // ���������� ��������� �������

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
        // ������������� totalBonuses
        totalBonuses = FindObjectsOfType<Bonus>().Length;
    }

    public void AddScore(int bonusPoints)
    {
        score += bonusPoints;
        UpdateScoreText();
        collectedBonuses++; // ����������� ���������� ��������� �������

        // ���������, ������� �� ��� ������
        if (collectedBonuses >= totalBonuses)
        {
            GameManager.instance.WinGame(); // �������� WinGame �� GameManager
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
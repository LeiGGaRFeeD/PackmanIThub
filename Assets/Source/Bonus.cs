using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bonus : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() == true)
        {
            // ��������� ���� � ������ �����
            ScoreManager.instance.AddScore(ScoreManager.instance.pointsPerBonus);

            // ������������� ���� ����� ������ (���� ������ ���� �������� � AudioSource ���������)
         //   GetComponent<AudioSource>().Play();

            // ���������� ����� ����� �����
            Destroy(gameObject);
        }
    }
}
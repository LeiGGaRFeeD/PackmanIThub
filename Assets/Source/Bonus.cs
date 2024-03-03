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
            // Добавляем очки к общему счету
            ScoreManager.instance.AddScore(ScoreManager.instance.pointsPerBonus);

            // Воспроизводим звук сбора бонуса (звук должен быть добавлен в AudioSource компонент)
         //   GetComponent<AudioSource>().Play();

            // Уничтожаем бонус после сбора
            Destroy(gameObject);
        }
    }
}
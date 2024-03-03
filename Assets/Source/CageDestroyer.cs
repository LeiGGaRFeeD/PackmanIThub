using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageDestroyer : MonoBehaviour
{
    [SerializeField] private int _time;
    void Start()
    {
        InvokeRepeating("TimeCount", 0, 1);
    }
    void TimeCount()
    {
        Debug.Log("Time to destroy cage: " + _time);
        _time--;
        if (_time <= 0)
        {
            Debug.Log("Cage destroyed!");
            Destroy(gameObject);
        }
    }

}

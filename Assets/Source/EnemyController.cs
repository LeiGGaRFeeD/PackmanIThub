using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3.0f;
    public Transform[] waypoints;
    private int waypointIndex = 0;
    private Vector2 target;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UpdateTarget();
    }

    void Update()
    {
        Move();
        if ((Vector2)transform.position == target)
        {
            UpdateWaypointIndex();
            UpdateTarget();
        }
    }

    private void Move()
    {
        Vector2 newPosition = Vector2.MoveTowards(rb.position, target, speed * Time.deltaTime);
        rb.MovePosition(newPosition);
    }

    private void UpdateTarget()
    {
        if (waypoints.Length > 0)
        {
            target = waypoints[waypointIndex].position;
        }
    }

    private void UpdateWaypointIndex()
    {
        waypointIndex = (waypointIndex + 1) % waypoints.Length;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>()==true)
        {
            // Здесь логика взаимодействия с игроком, например, уменьшение количества жизней
             GameManager.instance.LoseLife();
        }
    }
}
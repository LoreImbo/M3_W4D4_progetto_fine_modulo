using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float __bulletLife = 5;
    [SerializeField] private int _damage = 3;

    public void Shoot(Vector2 origin, Vector2 direction)
    {
        transform.position = origin;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        float lenght = direction.magnitude;
        if (lenght > 1)
        {
            direction /= lenght;
        }
        rb.velocity = direction * _speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool result = collision.collider.TryGetComponent<LifeController>(out LifeController life);
        if (result)
        {
            life.AddHp(-_damage);
        }
        Destroy(gameObject);
    }
    void Start()
    {
        Destroy(gameObject, __bulletLife); 
    }
}

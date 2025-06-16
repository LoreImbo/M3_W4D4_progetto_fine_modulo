using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _bulletLife = 5;
    [SerializeField] private int _damage = 3;
    private Rigidbody2D _rb;

    public void ShootBullet(Vector2 origin, Vector2 force, int damage)
    {
        transform.position = origin;
        _damage = damage;
        _rb = GetComponent<Rigidbody2D>();
        _rb.AddForce(force * _speed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        bool result = other.TryGetComponent<LifeController>(out LifeController life);
        if (result)
        {
            life.TakeDamage(_damage);
        }
        Destroy(gameObject);
    }
    void Start()
    {
        Destroy(gameObject, _bulletLife); 
    }
}

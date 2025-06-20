using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private int _damage = 10;
    private Transform _player;
    private Rigidbody2D _rb;
    private LifeController _life;

    public void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _life = GetComponent<LifeController>();
    }

    void Start()
    {
        SetTargetToPlayer();
    }

    void SetTargetToPlayer()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            _player = playerObj.transform;
        }
    }

    void FixedUpdate()
    {
        if (_player == null)
        {
            SetTargetToPlayer();
            return;
        }

        Vector2 direction = (_player.position - transform.position).normalized;
        _rb.MovePosition(_rb.position + direction * (_speed * Time.fixedDeltaTime));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<LifeController>().TakeDamage(_damage);
            _life.TakeDamage(_life.GetHp());
        }
    }
}

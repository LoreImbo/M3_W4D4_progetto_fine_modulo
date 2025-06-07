using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller2D : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    public Vector2 Direction { get; private set; }
    private Rigidbody2D _rb;

    public void UpdateDirection(Vector2 direction)
    {
        float lenght = direction.magnitude;
        if (lenght > 1)
        {
            direction /= lenght;
        }
        Direction = direction;
    }
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        if (Direction != Vector2.zero)
        {
            _rb.MovePosition(_rb.position + Direction * (speed * Time.deltaTime));
        }
    }
}

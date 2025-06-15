using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    public Vector2 Direction { get; private set; }
    private Rigidbody2D _rb;
    private float _horizontal;
    private float _vertical;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        Direction = new Vector2(_horizontal, _vertical).normalized;

        if (Direction != Vector2.zero)
        {
            _rb.MovePosition(_rb.position + Direction * (speed * Time.fixedDeltaTime));
        }
    }
}

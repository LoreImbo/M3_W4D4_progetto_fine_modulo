using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Controller2D _controller;
    private float _horizontal;
    private float _vertical;

    void Start()
    {
        _controller = GetComponent<Controller2D>();
    }

    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(_horizontal, _vertical);
        _controller.UpdateDirection(direction);
    }
}

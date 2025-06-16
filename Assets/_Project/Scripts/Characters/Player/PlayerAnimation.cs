using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private PlayerController _playerController;


    void Start()
    {
        _animator = GetComponent<Animator>();
        _playerController = GetComponentInParent<PlayerController>();
        _animator.SetFloat("Horizontal", 1);
    }

    private void SetAnimation()
    {
        float x = Mathf.Abs(_playerController.Direction.x);
        float y = Mathf.Abs(_playerController.Direction.y);

        //Walk
        if (x != 0 || y != 0)
        {
            _animator.SetBool("IsWalking", true);
            //Left or Right
            if (x > y)
            {
                _animator.SetFloat("Horizontal", (_playerController.Direction.x > 0) ? 1f : -1f);
                _animator.SetFloat("Vertical", 0f);
            }
            //Back or Front
            else
            {
                _animator.SetFloat("Horizontal", 0f);
                _animator.SetFloat("Vertical", (_playerController.Direction.y > 0) ? 1f : -1f);
            }
        }
        //Idle
        else
        {
            _animator.SetBool("IsWalking", false);
            //Fatto cos� resta impostata l'ultima direzione
        }
    }

    void Update()
    {
        SetAnimation();
    }
}

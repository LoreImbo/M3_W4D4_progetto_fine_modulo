using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    void LateUpdate()
    {
        if (_target != null && _target.gameObject != null)
        {
            transform.position = new Vector3 (_target.position.x, _target.position.y, transform.position.z);
        }
    }
}

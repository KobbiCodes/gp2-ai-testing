using System;
using UnityEngine;
using UnityEngine.UIElements;

public class Projectile : MonoBehaviour
{
    private float _speed;
    private Vector3 _direction;
    private Vector3 _target;

    public float Speed
    {
        get => _speed;
        set => _speed = value;
    }

    public Vector3 Direction
    {
        get => _direction;
        set {
            _direction = value.normalized;
            _target = transform.position + (_direction);
        }
    }
    
    public void OnEnable()
    {
        _direction = Vector3.zero;
        _speed = 0f;
        _target = Vector3.zero;
    }

    public void FixedUpdate()
    {
        Vector3.MoveTowards(transform.position, _target, _speed);
    }
    
    
    //TODO: On Collision enter.
}

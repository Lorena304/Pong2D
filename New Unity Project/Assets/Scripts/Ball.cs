using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float _velocity = 7.5f;
    public Rigidbody2D _rigidbody;
    public Vector2 _initialPosition = new Vector2(0, 0);
    Vector2 _direction = new Vector2(1, 1);
    public float _maxVelocity = 10f;

    // Start is called before the first frame update
    void Start()
    {
        ResetBall();
    }

    public void ResetBall()
    {
        gameObject.transform.position = _initialPosition;
        _direction.x = Random.Range(-1f, 1f);
        _direction.y = Random.Range(-1f, 1f);
        if (_direction.x == 0)
        {
            _direction.x = 0.5f;
        }
        if (_direction.y == 0)
        {
            _direction.y = 0.5f;
        }
        _rigidbody.velocity = _direction.normalized * _velocity;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_rigidbody.velocity.magnitude>_maxVelocity)
        {
            _rigidbody.velocity = _rigidbody.velocity.normalized * _maxVelocity;
        }
    }
}

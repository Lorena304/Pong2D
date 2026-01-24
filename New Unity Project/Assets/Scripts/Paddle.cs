using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float _speed = 7.5f;
    public Rigidbody2D _rigidbody;
    public KeyCode _upKey;
    public KeyCode _downKey;
    float _distance;
    Vector2 _direction = new Vector2(0, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _direction.y = 0;
        if (Input.GetKey(_upKey))
        {
            _direction.y += 1;
        }
        if (Input.GetKey(_downKey))
        {
            _direction.y -= 1;
        }

    }

    private void FixedUpdate()
    {
        if (_direction.magnitude != 0)
        {
            _distance = _speed * Time.fixedDeltaTime;
            _rigidbody.MovePosition((Vector2)gameObject.transform.position + new Vector2(0, _direction.y * _distance));
        }
    }
}

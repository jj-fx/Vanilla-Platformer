﻿using UnityEngine;

[RequireComponent(typeof(CharacterGrounding))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementController : MonoBehaviour, IMove
{
    public float Speed { get; private set; }

    private bool _jump;
    [SerializeField] private float _moveSpeed = 6.5f;
    [SerializeField] private float _jumpForce = 500;
    private Rigidbody2D _rigidbody2D;
    private CharacterGrounding _characterGrounding;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _characterGrounding = GetComponent<CharacterGrounding>();
    }

    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        Speed = horizontal;
        var jump = Input.GetButtonDown("Jump");

        if (Mathf.Abs(horizontal) >= 0.01f || jump)
        {
            var movement = new Vector3(horizontal, 0f);
            MovePlayer(movement);
        }
    }

    private void MovePlayer(Vector3 movement)
    {
        transform.position += movement * Time.deltaTime * _moveSpeed;

        if (Input.GetButtonDown("Jump") && _characterGrounding.IsGrounded)
        {
/*            if (_characterGrounding.GroundedDirection != Vector3.down && _characterGrounding.GroundedDirection.HasValue)
            {
                _rigidbody2D.AddForce(_characterGrounding.GroundedDirection.Value * _jumpForce * -1.3f);
            }
            else
            {*/
                _rigidbody2D.AddForce(Vector2.up * _jumpForce);
            //}
        }
    }

    internal void Bounce()
    {
        _rigidbody2D.AddForce(Vector2.up * _jumpForce * 0.6f);
    }

    /*    public void StopPlayer()
        {
            _rigidbody2D.velocity = Vector2.zero;
            Speed = 0;
        }*/
}

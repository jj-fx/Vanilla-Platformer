using System;
using UnityEngine;

[RequireComponent(typeof(CharacterGrounding))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementController : MonoBehaviour, IMove
{
    public float Speed { get; private set; }
    public bool Jumped { get; private set; }
    public float VerticalVelocity { get; private set; }

    [SerializeField] private float _moveSpeed = 6.5f;
    [SerializeField] private float _jumpForce = 500;

    private Rigidbody2D _rigidbody2D;
    private CharacterGrounding _characterGrounding;
    private RunLoopAudio _runLoopAudio;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _characterGrounding = GetComponent<CharacterGrounding>();
        _runLoopAudio = GetComponentInChildren<RunLoopAudio>();
    }

    private void Update()
    {
        Speed = Input.GetAxis("Horizontal");
        Jumped = Input.GetButtonDown("Jump") && _characterGrounding.IsGrounded;
        VerticalVelocity = _rigidbody2D.velocity.y;

        HandleRunAudio();

        if (Mathf.Abs(Speed) >= 0.01f || Input.GetButtonDown("Jump"))
        {
            var movement = new Vector3(Speed, 0f);
            MovePlayer(movement);
        }
    }

    private void HandleRunAudio()
    {
        if (Mathf.Abs(Speed) >= 0.1f && _characterGrounding.IsGrounded)
        {
            _runLoopAudio.PlayAudio();
        }
        else
        {
            _runLoopAudio.StopAudio();
        }
    }

    private void MovePlayer(Vector3 movement)
    {
        transform.position += movement * Time.deltaTime * _moveSpeed;
        
        if (Jumped)
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce);
        }
    }

    internal void Bounce()
    {
        _rigidbody2D.AddForce(Vector2.up * _jumpForce * 0.6f);
    }

    public void StopPlayer()
    {
        Speed = 0;
    }
}

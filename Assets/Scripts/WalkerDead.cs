using System;
using UnityEngine;

public class WalkerDead : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;

    private Collider2D _collider;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _direction = Vector2.zero;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(_direction.x * _speed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.WasHitByPlayer())
        {
            HandlePlayerCollision(collision);
        }
        else
        {
            if (collision.WasHitFromSide())
            {
                LaunchDeadWalker(collision);

                var takeHits = collision.collider.GetComponent<ITakeHits>();

                if (takeHits != null)
                {
                    takeHits.HandleHit(this);
                }
            }
        }
    }

    private void HandlePlayerCollision(Collision2D collision)
    {
        var player = collision.collider.GetComponent<PlayerMovementController>();

        if (_direction.magnitude == 0)
        {
            LaunchDeadWalker(collision);
            player.Bounce();
        }
        else
        {
            if (collision.WasHitFromTop())
            {
                _direction = Vector2.zero;
            }
            else
            {
                GameManager.Instance.KillPlayer();
            }
        }
    }

    private void LaunchDeadWalker(Collision2D collision)
    {
        var launchDirection = collision.contacts[0].normal.x > 0 ? 1f : -1f;

        _direction = new Vector2(launchDirection, 0);
    }
}

using UnityEngine;

public class Walker : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    [SerializeField] private GameObject _spawnOnDeath;
    private Collider2D _collider;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _sprite;
    private Vector2 _direction = Vector2.left;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.WasHitByPlayer())
        {
            if (collision.WasHitFromTop())
            {
                HandleWalkerJumpedOn(collision.collider.GetComponent<PlayerMovementController>());
            }
            else
            {
                GameManager.Instance.KillPlayer();
            }
        }
    }

    private void HandleWalkerJumpedOn(PlayerMovementController player)
    {
        if (_spawnOnDeath != null)
        {
            Instantiate(_spawnOnDeath, transform.position, transform.rotation);
        }

        player.Bounce();

        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _direction * _speed * Time.deltaTime);
    }

    private void LateUpdate()
    {
        if (ReachedEnd() || HitWall())
        {
            SwitchDirection();
        }
    }

    private bool ReachedEnd()
    {
        Vector2 point = GetRaycastPoint();

        var hit = Physics2D.Raycast(point, Vector2.down, 0.15f);

        if (hit.collider == null)
        {
            return true;
        }

        return false;
    }

    private bool HitWall()
    {
        Vector2 point = GetRaycastPoint();
        //point.y += _collider.bounds.size.y * 0.5f;

        var hit = Physics2D.Raycast(point, _direction, 0.05f);

        if (hit.collider == null)
        {
            return false;
        }

        if (hit.collider.isTrigger)
        {
            return false;
        }

        if (hit.collider.GetComponentInChildren<PlayerMovementController>() != null)
        {
            return false;
        }

        return true;
    }

    private Vector2 GetRaycastPoint()
    {
        var x = _direction.x == 1 ?
            _collider.bounds.max.x + 0.1f :
            _collider.bounds.min.x - 0.1f;

        var y = _collider.bounds.min.y;

        Vector2 point = new Vector2(x, y);
        return point;
    }

    private void SwitchDirection()
    {
        _direction *= -1;
        _sprite.flipX = !_sprite.flipX;
    }
}

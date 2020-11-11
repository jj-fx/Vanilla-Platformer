using UnityEngine;

public class Walker : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
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

    private void FixedUpdate()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _direction * _speed * Time.deltaTime);
    }

    private void LateUpdate()
    {
        if (ReachedEnd())
        {
            SwitchDirection();
        }
    }

    private bool ReachedEnd()
    {
        var x = _direction.x == 1 ? 
            _collider.bounds.max.x + 0.1f : 
            _collider.bounds.min.x - 0.1f;

        var y = _collider.bounds.min.y;

        Vector2 point = new Vector2(x, y);

        var hit = Physics2D.Raycast(point, Vector2.down, 0.15f);

        if (hit.collider == null)
        {
            return true;
        }

        return false;
    }

    private void SwitchDirection()
    {
        _direction *= -1;
        _sprite.flipX = !_sprite.flipX;
    }
}

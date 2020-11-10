using UnityEngine;

[RequireComponent(typeof(CharacterGrounding))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementController : MonoBehaviour, IMove
{
    [SerializeField] private float _moveSpeed = 6.5f;
    [SerializeField] private float _jumpForce = 500;
    private Rigidbody2D _rigidbody2D;
    private CharacterGrounding _characterGrounding;
    public float Speed { get; private set; }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _characterGrounding = GetComponent<CharacterGrounding>();
    }

    private void Update()
    {
        float _horizontal = Input.GetAxis("Horizontal");
        Speed = _horizontal;

        Vector3 _movement = new Vector3(_horizontal, 0);

        MovePlayer(_movement);
    }

    private void MovePlayer(Vector3 movement)
    {
        transform.position += movement * Time.deltaTime * _moveSpeed;

        if (Input.GetButtonDown("Jump") && _characterGrounding.IsGrounded)
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce);
        }
    }
}

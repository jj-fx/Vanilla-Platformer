using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 6.5f;
    [SerializeField] private float _jumpForce = 500;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float _horizontal = Input.GetAxis("Horizontal");

        Vector3 _movement = new Vector3(_horizontal, 0);

        MovePlayer(_movement);
    }

    private void MovePlayer(Vector3 movement)
    {
        transform.position += movement * Time.deltaTime * _moveSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce);
        }
    }
}

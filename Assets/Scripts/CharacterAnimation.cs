using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class CharacterAnimation : MonoBehaviour
{
    private Animator _animator;
    private IMove _mover;
    private SpriteRenderer _spriteRenderer;
    private CharacterGrounding _characterGrounding;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _mover = GetComponent<IMove>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _characterGrounding = GetComponent<CharacterGrounding>();
    }

    private void Update()
    {
        var speed = _mover.Speed;

        _animator.SetFloat("Speed", Mathf.Abs(speed));

        if (!_characterGrounding.IsGrounded)
        {
            _animator.SetFloat("Speed", 0);
        }

        _animator.SetFloat("VerticalVelocity", Mathf.Abs(_mover.VerticalVelocity));

        if (speed != 0)
        {
            _spriteRenderer.flipX = speed < 0;
        }
    }
}

using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class CharacterAnimation : MonoBehaviour
{
    private Animator _animator;
    private IMove _mover;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _mover = GetComponent<IMove>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        var speed = _mover.Speed;

        _animator.SetFloat("Speed", Mathf.Abs(speed));

        if (speed != 0)
        {
            _spriteRenderer.flipX = speed < 0;
        }
    }
}

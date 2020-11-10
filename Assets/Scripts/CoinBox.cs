using TMPro;
using UnityEngine;

public class CoinBox : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _enabled;
    [SerializeField] private SpriteRenderer _disabled;
    [SerializeField] private int _maxCoins = 3;
    private int _remainingCoins;
    private Animator _animator;

    private void Awake()
    {
        _remainingCoins = _maxCoins;
        _animator = GetComponentInChildren<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var isPlayer = collision.collider.GetComponent<PlayerMovementController>();
        var hitPoint = collision.contacts[0].normal;

        if (isPlayer && _remainingCoins > 0 && hitPoint.y > 0.5f)
        {
            GameManager.Instance.AddCoin();
            _remainingCoins--;
            _animator.SetTrigger("FlipCoin");

            if (_remainingCoins <= 0)
            {
                _enabled.enabled = false;
                _disabled.enabled = true;
            }
        }
    }
}

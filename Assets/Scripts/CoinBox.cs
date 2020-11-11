using TMPro;
using UnityEngine;

public class CoinBox : MonoBehaviour, ITakeHits
{
    [SerializeField] private SpriteRenderer _enabled;
    [SerializeField] private SpriteRenderer _disabled;
    [SerializeField] private int _maxCoins = 3;
    private int _remainingCoins;
    private Animator _animator;

    public void HandleHit(WalkerDead walkerDead)
    {
        if (_remainingCoins > 0)
        {
            TakeCoin();
        }
    }

    private void Awake()
    {
        _remainingCoins = _maxCoins;
        _animator = GetComponentInChildren<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.WasHitByPlayer() && _remainingCoins > 0 && collision.WasHitFromBottom())
        {
            TakeCoin();
        }
    }

    private void TakeCoin()
    {
        GameManager.Instance.GainCoin();
        _remainingCoins--;
        _animator.SetTrigger("FlipCoin");

        if (_remainingCoins <= 0)
        {
            _enabled.enabled = false;
            _disabled.enabled = true;
        }
    }
}

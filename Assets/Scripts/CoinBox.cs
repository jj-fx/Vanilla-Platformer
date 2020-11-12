using UnityEngine;

public class CoinBox : MonoBehaviour, ITakeHits
{
    public int CoinCount => _maxCoins;

    [SerializeField] private SpriteRenderer _enabled;
    [SerializeField] private SpriteRenderer _disabled;
    [SerializeField] private int _maxCoins = 3;

    private int _remainingCoins;
    private Animator _animator;
    private PlatformEffector2D _platformEffector2D;
    private BoxCollider2D _boxCollider2D;

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
        _platformEffector2D = GetComponent<PlatformEffector2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
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

            _boxCollider2D.usedByEffector = true;
            _platformEffector2D.enabled = true;
        }
    }
}

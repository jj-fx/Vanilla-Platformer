using UnityEngine;

public class UIGainCoin : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        GameManager.Instance.OnCoinsChanged += CoinPulse;
    }

    private void CoinPulse(int coins)
    {
        _animator.SetTrigger("CoinPulse");
    }
}

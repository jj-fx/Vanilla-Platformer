using UnityEngine;

public class LevelExit : MonoBehaviour
{
    private Coin[] _coins;
    private CoinBox[] _coinBox;
    private int _coinCount;
    private ParticleSystem _particleSystem;

    private void Start()
    {
        _coins = FindObjectsOfType<Coin>();
        _coinBox = FindObjectsOfType<CoinBox>();
        _coinCount = _coins.Length - _coinBox.Length;

        foreach (var box in _coinBox)
        {
            _coinCount += box.CoinCount;
        }

        _particleSystem = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.Instance.Coins == _coinCount)
        {
            if (collision.GetComponent<PlayerMovementController>() != null)
            {
                GameManager.Instance.GoToNextLevel();
            }
        }
        else
        {
            _particleSystem.Play();
        }
    }
}

using System;
using UnityEngine;

public class CoinAudio : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        GameManager.Instance.OnCoinsChanged += PlayCoinAudio;
    }

    private void PlayCoinAudio(int coins)
    {
        _audioSource.Play();
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnCoinsChanged -= PlayCoinAudio;
    }
}

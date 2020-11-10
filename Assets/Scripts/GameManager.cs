using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private int _maxLives = 3;
    private int _coins;

    public int Lives { get; private set; }
    public int Coins { get; private set; }

    public event Action<int> OnLivesChanged;
    public event Action<int> OnCoinsChanged;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            Lives = _maxLives;
            Coins = _coins;
        }

    }

    internal void GainCoin()
    {
        _coins++;
        if (OnCoinsChanged != null)
        {
            OnCoinsChanged(_coins);
        }
    }

    internal void KillPlayer()
    {
        Lives--;
        if (OnLivesChanged != null)
        {
            OnLivesChanged(Lives);
        }

        if (Lives <= 0)
        {
            RestartGame();
        } 
        else
        {
            SendPlayerToCheckpoint();
        }
    }

    private void SendPlayerToCheckpoint()
    {
        var lastCheckpoint = FindObjectOfType<CheckpointManager>().GetLastCheckpoint();
        FindObjectOfType<PlayerMovementController>().transform.position = lastCheckpoint.transform.position;
    }

    private void RestartGame()
    {
        Lives = _maxLives;
        _coins = 0;
        OnCoinsChanged(_coins);
        SceneManager.LoadScene(0);
    }
}

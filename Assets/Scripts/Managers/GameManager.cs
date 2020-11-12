using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private int _maxLives = 3;
    private int _coins;
    private int _currentLevel;

    public int Lives { get; private set; }
    public int Coins { get; private set; }

    public event Action<int> OnLivesChanged;
    public event Action<int> OnCoinsChanged;
    public event Action<int> OnDied;

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

    public void GoToNextLevel()
    {
        _currentLevel++;
        SceneManager.LoadScene(_currentLevel);
    }

    private void RestartGame()
    {
        Lives = _maxLives;
        _coins = 0;
        OnCoinsChanged(_coins);
        SceneManager.LoadScene(_currentLevel);
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
            StartCoroutine(WaitToRestart(0.5f));
        } 
        else
        {
            StartCoroutine(WaitToDie(0.5f));
        }
    }

    private IEnumerator WaitToRestart(float time)
    {
        BeforeDied();

        yield return new WaitForSeconds(time);

        RestartGame();
    }

    private IEnumerator WaitToDie(float time)
    {
        BeforeDied();

        yield return new WaitForSeconds(time);

        SendPlayerToCheckpoint();
    }
    private void SendPlayerToCheckpoint()
    {
        var player = FindObjectOfType<PlayerMovementController>();

        player.transform.rotation = Quaternion.identity;

        player.GetComponent<SpriteRenderer>().enabled = true;

        var lastCheckpoint = FindObjectOfType<CheckpointManager>().GetLastCheckpoint();

        player.transform.position = lastCheckpoint.transform.position;

        player.GetComponent<HandlePlayerDeath>().DisablePlayerForTime(0.5f);
    }

    private static void BeforeDied()
    {
        var player = FindObjectOfType<PlayerMovementController>();

        player.GetComponentInChildren<LifeLossAudio>().PlayAudio();

        player.GetComponent<SpriteRenderer>().enabled = false;

        player.StopPlayer();

        var blood = player.GetComponentInChildren<ParticleSystem>();

        blood.Play();
    }
}

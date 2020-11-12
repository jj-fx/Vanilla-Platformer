﻿using System.Collections;
using UnityEngine;

public class HandlePlayer : MonoBehaviour
{
    [SerializeField] private float _delayTime;
    private PlayerMovementController _playerMovementController;

    private void Awake()
    {
        _playerMovementController = GetComponent<PlayerMovementController>();
    }

    private void Start()
    {
        DisablePlayerForTime(_delayTime);
    }

    private IEnumerator WaitToEnablePlayer(float time)
    {
        _playerMovementController.enabled = false;

        yield return new WaitForSeconds(time);

        _playerMovementController.enabled = true;
    }

    public void DisablePlayerForTime(float time)
    {
        if (time > 0)
        {
            StartCoroutine(WaitToEnablePlayer(time));
        }
    }
}
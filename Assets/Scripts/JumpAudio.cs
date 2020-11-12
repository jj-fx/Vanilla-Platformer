using UnityEngine;

public class JumpAudio : MonoBehaviour
{
    private AudioSource _audioSource;
    private IMove _mover;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _mover = GetComponentInParent<IMove>();
    }

    private void Update()
    {
        if (_mover.Jumped)
        {
            _audioSource.Play();
        }
    }
}

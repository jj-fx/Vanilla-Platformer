using System.Linq;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private Checkpoint[] _checkpoints;

    private void Start()
    {
        _checkpoints = GetComponentsInChildren<Checkpoint>();
    }

    public Checkpoint GetLastCheckpoint()
    {
        var lastCheckpoint = _checkpoints.Last(t => t.Passed);
        return lastCheckpoint;
    }
}

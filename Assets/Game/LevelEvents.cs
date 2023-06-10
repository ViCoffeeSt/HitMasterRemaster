using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class LevelEvents : MonoBehaviour
{
    [SerializeField] private TMP_Text startPlayText;
    [SerializeField] private NavMeshAgent player;

    private void Start()
    {
        player.isStopped = true;
    }

    public void StartPlayGame()
    {
        startPlayText.enabled = false;
        player.isStopped = false;
    }
}

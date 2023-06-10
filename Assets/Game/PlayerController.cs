using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private Animator animator;
    [SerializeField] private NavMeshAgent agent;

    private int _currentWaypointIndex = 0;

    private float _startSpeed;
    private float _enemiesKilled;
    private float _enemiesNeedKill = 3;

    private readonly float _minSpeedAnimation = 0f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        agent.SetDestination(waypoints[_currentWaypointIndex].position);
        _startSpeed = agent.speed;
    }

    private void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.isStopped = true;

            StartCoroutine(DelayedMovePlayer());

            ProceedToNextWaypoint();
        }

        animator.SetFloat("Speed", agent.speed);

        if (agent.speed < 0.1f)
        {
            animator.SetFloat("Speed", _minSpeedAnimation);
        }
    }

    private IEnumerator DelayedMovePlayer()
    {
        agent.speed = 0f;
        _enemiesKilled = 0;

        while (_enemiesKilled < _enemiesNeedKill)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GetComponentInChildren<Shooting>().ShootBullet();
            }

            yield return null;

            if (_enemiesKilled >= _enemiesNeedKill)
            {
                break;
            }
        }

        agent.speed = _startSpeed;
    }

    private void ProceedToNextWaypoint()
    {
        _currentWaypointIndex++;
        if (_currentWaypointIndex >= waypoints.Length)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            agent.isStopped = false;
            agent.SetDestination(waypoints[_currentWaypointIndex].position);
        }
    }

    public void IncrementEnemiesKilled()
    {
        _enemiesKilled++;
    }
}

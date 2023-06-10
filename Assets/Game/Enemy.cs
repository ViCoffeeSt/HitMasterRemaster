using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, IDamage
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private ParticleSystem particleKillEnemy;

    private float _health = 10f;
    private float _minHealth = 0f;

    public void TakeDamage(int damage)
    {
        Instantiate(particleKillEnemy, transform.position + Vector3.up, Quaternion.identity);

        _health -= damage;

        healthBar.value = _health;

        if (_health <= _minHealth)
        {
            PlayerController player = FindObjectOfType<PlayerController>();
            player.IncrementEnemiesKilled();
            Destroy(gameObject);
        }
    }
}

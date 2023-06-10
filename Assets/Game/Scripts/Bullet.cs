using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<IDamage>(out var idamageOBject))
        {
            idamageOBject.TakeDamage(5);
        }

        gameObject.SetActive(false);
    }
}

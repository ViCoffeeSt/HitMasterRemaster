using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;

    public void ShootBullet()
    {
        Vector3 tapPosition = Input.mousePosition;
        tapPosition.z = 10f;

        Vector3 bulletDirection = Camera.main.ScreenToWorldPoint(tapPosition) - transform.position;
        bulletDirection.Normalize();

        GameObject bullet = ObjectPoolBullet.Instance.GetPooledObject();

        bullet.transform.position = transform.position + transform.up/2;
        bullet.SetActive(true);

        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = bulletDirection * bulletSpeed;

        StartCoroutine(DisableBulletAfterDelay(bullet));
    }

    private IEnumerator DisableBulletAfterDelay(GameObject bullet)
    {
        yield return new WaitForSeconds(1f);

        bullet.SetActive(false);
    }
}


using UnityEngine;

namespace SlingShot
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private GameObject cloudParticlePrefab;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Bird bird = collision.collider.GetComponent<Bird>();
            if (bird != null)
            {
                Instantiate(cloudParticlePrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
                return;
            }

            Enemy enemy = collision.collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                return;
            }
            if (collision.contacts[0].normal.y < -0.5)
            {
                Instantiate(cloudParticlePrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

        }
    }
}


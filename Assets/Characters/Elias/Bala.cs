using UnityEngine;

public class Bala : MonoBehaviour
{
    public GameObject bloodSplatterPrefab;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Da�o a enemigos normales
        if (other.CompareTag("Enemy"))
        {
            Instantiate(bloodSplatterPrefab, other.transform.position, Quaternion.identity);
            Destroy(other.transform.root.gameObject);
            Destroy(gameObject);
        }

        // Da�o al jefe (boss_prueba)
        else if (other.CompareTag("Boss"))
        {
            Instantiate(bloodSplatterPrefab, other.transform.position, Quaternion.identity);

            BossHealth bossHealth = other.GetComponent<BossHealth>();
            if (bossHealth != null)
            {
                bossHealth.TakeDamage(1); // Cada bala le hace 1 de da�o
            }

            Destroy(gameObject);
        }

        // Impacto con obst�culo
        else if (other.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}

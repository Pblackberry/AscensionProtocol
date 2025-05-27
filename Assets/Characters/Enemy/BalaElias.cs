using UnityEngine;

public class BalaElias : MonoBehaviour
{
    public int damage = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }

            Destroy(gameObject); // Destruye solo la bala, no al jugador
        }
        if (other.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}

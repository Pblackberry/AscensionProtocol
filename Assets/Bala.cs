using UnityEngine;

public class Bala : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject); // Eliminar enemigo
            Destroy(gameObject);       // Elimina la bala también
        }
    }
}

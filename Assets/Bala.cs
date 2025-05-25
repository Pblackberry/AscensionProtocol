using UnityEngine;

public class Bala : MonoBehaviour
{
    public GameObject bloodSplatterPrefab;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Instantiate(bloodSplatterPrefab, other.transform.position, Quaternion.identity);
            Destroy(other.transform.root.gameObject);
            Destroy(gameObject);       // Elimina la bala también
        }
        if (other.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}

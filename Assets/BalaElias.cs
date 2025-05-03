using UnityEngine;

public class BalaElias : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            GameController gameController = Object.FindFirstObjectByType<GameController>(); // Usando la nueva función
            if (gameController != null)
            {
                gameController.GameOver();  
            }
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}

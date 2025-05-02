using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5f;
    private Transform player;
    private Vector3 personalOffset; // Offset único para este enemigo

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }

        // Asigna un offset aleatorio UNA SOLA VEZ
        personalOffset = new Vector3(
            Random.Range(-1.5f, 1.5f),
            Random.Range(-1.5f, 1.5f),
            0f
        );
    }

    void Update()
    {
        if (player != null)
        {
            // Suma el offset fijo al objetivo del jugador
            Vector3 targetPosition = new Vector3(
                player.position.x + personalOffset.x,
                player.position.y + personalOffset.y,
                transform.position.z
            );

            Vector3 direction = (targetPosition - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}

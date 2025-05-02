using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5f;
    public Transform visual; // Asigna aquí el objeto hijo "Visual"

    private Transform player;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    void Update()
    {
        if (player == null) return;

        // Movimiento hacia el jugador
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        // Voltear visualmente según la dirección
        if (visual != null)
        {
            if (player.position.x < transform.position.x)
            {
                visual.localScale = new Vector3(1, 1, 1); // Ahora mirar a la izquierda
            }
            else
            {
                visual.localScale = new Vector3(-1, 1, 1); // Ahora mirar a la derecha
            }
        }
    }
}

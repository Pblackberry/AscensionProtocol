using UnityEngine;

public class BossFollow : MonoBehaviour
{
    public float speed = 3f;
    private Transform target;

    void Start()
    {
        // Buscar el objeto llamado "Elias"
        GameObject player = GameObject.Find("Elias");
        if (player != null)
        {
            target = player.transform;
        }
        else
        {
            Debug.LogError("No se encontró el objeto 'Elias'");
        }
    }

    void Update()
    {
        if (target != null)
        {
            // Movimiento hacia el jugador
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            // Opcional: rotar hacia el jugador si es 2D con flipX
            if (target.position.x < transform.position.x)
                transform.localScale = new Vector3(1, 1, 1);
            else
                transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}

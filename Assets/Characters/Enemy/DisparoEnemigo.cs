using UnityEngine;

public class DisparoEnemigo : MonoBehaviour
{
    public GameObject balaPrefab;
    public Transform puntoDisparo; // Lugar desde donde el enemigo dispara
    public float velocidadBala = 10f;
    public float tiempoEntreDisparos = 3f;


    private float temporizador;
    private Transform objetivo; // Aquí se guardará la referencia de Elias

    void Start()
    {
        // Buscar a Elias automáticamente usando su tag (asegúrate de que Elias tenga el tag "Player")
        GameObject elias = GameObject.FindWithTag("Player");

        if (elias != null)
        {
            objetivo = elias.transform; // Asignamos a Elias como el objetivo
        }
    }

    void Update()
    {
        if (objetivo == null) return;

        temporizador += Time.deltaTime;

        if (temporizador >= tiempoEntreDisparos)
        {
            Disparar();
            temporizador = 0f;
        }
    }

    void Disparar()
    {
        // Asegurarnos de que la bala siempre dispare hacia la posición actual de Elias
        if (objetivo != null)
        {
            Vector2 direccion = (objetivo.position - puntoDisparo.position).normalized;

            // Instanciamos la bala y le asignamos la dirección de disparo
            GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, Quaternion.identity);
            Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                // La velocidad de la bala será la dirección hacia Elias multiplicada por la velocidad
                rb.linearVelocity = direccion * velocidadBala;
            }

            // Agregar movimiento dentro de este script (opcional si lo quieres en uno solo)
            Destroy(bala, 4f); // Destruir la bala después de 3 segundos
        }
    }
}

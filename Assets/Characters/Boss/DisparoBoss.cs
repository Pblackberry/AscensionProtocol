using UnityEngine;

public class DisparoBoss : MonoBehaviour
{
    public GameObject balaPrefab;
    public Transform puntoDisparo;
    public float velocidadBala = 10f;
    public float tiempoEntreBalas = 0.3f; // Tiempo entre cada bala de la ráfaga
    public float tiempoEsperaEntreRafagas = 2f;
    public float rangoDeDisparo = 10f;

    private float temporizador;
    private Transform objetivo;

    private int balasDisparadas = 0;
    private bool enEspera = false;

    void Start()
    {
        GameObject elias = GameObject.FindWithTag("Player");
        if (elias != null)
        {
            objetivo = elias.transform;
        }
    }

    void Update()
    {
        if (objetivo == null) return;

        float distancia = Vector2.Distance(transform.position, objetivo.position);
        if (distancia > rangoDeDisparo) return;

        temporizador += Time.deltaTime;

        if (enEspera)
        {
            if (temporizador >= tiempoEsperaEntreRafagas)
            {
                // Fin del descanso: reiniciar la ráfaga
                enEspera = false;
                balasDisparadas = 0;
                temporizador = 0f;
            }
        }
        else
        {
            if (temporizador >= tiempoEntreBalas)
            {
                Disparar();
                balasDisparadas++;
                temporizador = 0f;

                if (balasDisparadas >= 7)
                {
                    enEspera = true;
                    temporizador = 0f;
                }
            }
        }
    }

    void Disparar()
    {
        if (objetivo != null)
        {
            Vector2 direccion = (objetivo.position - puntoDisparo.position).normalized;
            GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, Quaternion.identity);
            Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.linearVelocity = direccion * velocidadBala;
            }

            Destroy(bala, 4f);
        }
    }
}

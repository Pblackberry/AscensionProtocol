using UnityEngine;

public class Disparo : MonoBehaviour
{
    public GameObject balaPrefab;
    public Transform puntoDisparo;
    public Camera mainCamera;
    public float velocidadBala = 20f;

    public bool tieneArma = false;
    public GameObject armaEquipada; // ← Referencia al arma actual equipada
    public GameObject armaPrefab;   // ← Prefab del arma para soltar

    void Update()
    {
        if (tieneArma && Input.GetButtonDown("Fire1"))
        {
            Disparar();
        }

        if (tieneArma && Input.GetKeyDown(KeyCode.Q))
        {
            SoltarArma();
        }
    }

    void Disparar()
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direccion = (mousePosition - puntoDisparo.position).normalized;

        GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, Quaternion.identity);
        Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.linearVelocity = direccion * velocidadBala;
        }

        Destroy(bala, 3f);
    }

    void SoltarArma()
    {
        if (armaEquipada != null && armaPrefab != null)
        {
            // Crear una copia del arma en el suelo
           // GameObject armaEnSuelo = Instantiate(armaPrefab, armaEquipada.transform.position, Quaternion.identity);

            // Activar físicas y colisiones para que pueda recogerse
            // Collider2D col = armaEnSuelo.GetComponent<Collider2D>();
            // if (col != null) col.enabled = true;

            // Rigidbody2D rb = armaEnSuelo.GetComponent<Rigidbody2D>();
            // if (rb != null) rb.simulated = true;

            // Eliminar el arma del jugador
            Destroy(armaEquipada);

            // Deshabilitar disparo
            tieneArma = false;
            armaEquipada = null;

            Debug.Log("🔄 Arma soltada.");
        }
    }
}



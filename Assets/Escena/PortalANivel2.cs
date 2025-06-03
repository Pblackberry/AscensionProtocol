using UnityEngine;
using Unity.Cinemachine; // Usa el namespace correcto según tu versión

public class PortalANivel2 : MonoBehaviour
{
    public Transform puntoDestino;
    public Collider2D nuevoConfiner;
    public CinemachineCamera cam; // Asignar la cámara Cinemachine desde el Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Mover al jugador al punto destino
            other.transform.position = puntoDestino.position;

            // Cambiar el área de confinamiento de la cámara
            var confiner = cam.GetComponent<CinemachineConfiner2D>();
            confiner.BoundingShape2D = nuevoConfiner;

            // ✅ Reiniciar el componente para que actualice los límites
            confiner.enabled = false;
            confiner.enabled = true;

            //Borrar los enemigos
            GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (GameObject enemigo in enemigos)
            {
                Destroy(enemigo);
            }

        }
    }
}
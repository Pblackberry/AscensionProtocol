using UnityEngine;
using Unity.Cinemachine; // o Cinemachine según tu versión

public class PortalANivel2 : MonoBehaviour
{
    public Transform puntoDestino;
    public Collider2D nuevoConfiner;
    public CinemachineCamera cam; // Asignar desde el Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = puntoDestino.position;

            var confiner = cam.GetComponent<CinemachineConfiner2D>();
            confiner.BoundingShape2D = nuevoConfiner;
        }
    }
}

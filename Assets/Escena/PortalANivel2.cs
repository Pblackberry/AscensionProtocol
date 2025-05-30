using UnityEngine;
using Unity.Cinemachine; // o Cinemachine seg�n tu versi�n

public class PortalANivel2 : MonoBehaviour
{
    public Transform puntoDestino;
    public Collider2D nuevoConfiner;
    public CinemachineCamera cam; // Asignar desde el Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Mover al jugador al punto destino
            other.transform.position = puntoDestino.position;

            // Cambiar el �rea de confinamiento de la c�mara
            var confiner = cam.GetComponent<CinemachineConfiner2D>();
            confiner.BoundingShape2D = nuevoConfiner;

            // Buscar al jefe
            GameObject boss = GameObject.Find("boss_prueba");
            if (boss != null)
            {
                BossHealth bossHealth = boss.GetComponent<BossHealth>();
                if (bossHealth != null)
                {
                    bossHealth.ActivateHealthBar();
                }
            }
        }
    }
}

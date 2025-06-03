using UnityEngine;

public class SpawnZoneDetector : MonoBehaviour
{
    public string grupoDeSpawn;

    private bool activado = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (activado) return;

        if (other.CompareTag("Player"))
        {
            ActivarSpawners();
            activado = true;
        }
    }

    void ActivarSpawners()
    {
        GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner");

        foreach (GameObject s in spawners)
        {
            SpawnPointEnemy es = s.GetComponent<SpawnPointEnemy>();
            if (es != null && es.grupoDeSpawn == grupoDeSpawn)
            {
                es.Activar();
            }
        }
    }
}
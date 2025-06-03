using UnityEngine;

public class PuertaSpawnWatcher : MonoBehaviour
{
    public string grupoDeSpawn;
    public ParticleSystem efectoExplosion;
    public GameObject portalSiguienteRoom; // Nuevo: referencia al portal

    private bool puertaAbierta = false;

    void Update()
    {
        if (!puertaAbierta && NoQuedanSpawners() && NoQuedanEnemigos())
        {
            AbrirPuerta();
        }
    }

    bool NoQuedanSpawners()
    {
        GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner");

        foreach (GameObject s in spawners)
        {
            SpawnPointEnemy es = s.GetComponent<SpawnPointEnemy>();
            if (es != null && es.grupoDeSpawn == grupoDeSpawn)
            {
                return false;
            }
        }

        return true;
    }

    bool NoQuedanEnemigos()
    {
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemy");
        return enemigos.Length == 0;
    }

    void AbrirPuerta()
    {
        puertaAbierta = true;

        if (efectoExplosion != null)
            Instantiate(efectoExplosion, transform.position, Quaternion.identity);

        if (portalSiguienteRoom != null)
            portalSiguienteRoom.SetActive(true); // Activa el portal al siguiente cuarto

        Destroy(gameObject);
    }
}
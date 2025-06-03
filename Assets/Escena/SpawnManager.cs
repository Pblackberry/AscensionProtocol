using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance { get; private set; }

    private Dictionary<string, List<SpawnPointEnemy>> grupos = new Dictionary<string, List<SpawnPointEnemy>>();

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void RegistrarSpawner(string grupo, SpawnPointEnemy spawner)
    {
        if (!grupos.ContainsKey(grupo))
            grupos[grupo] = new List<SpawnPointEnemy>();

        grupos[grupo].Add(spawner);
    }

    public void ActivarGrupo(string grupo)
    {
        if (grupos.ContainsKey(grupo))
        {
            foreach (SpawnPointEnemy spawner in grupos[grupo])
            {
                spawner.Activar();
            }
        }
    }

    public bool ExistenSpawnersActivos(string grupo)
    {
        if (grupos.ContainsKey(grupo))
        {
            foreach (SpawnPointEnemy spawner in grupos[grupo])
            {
                if (spawner != null)
                    return true;
            }
        }
        return false;
    }

}
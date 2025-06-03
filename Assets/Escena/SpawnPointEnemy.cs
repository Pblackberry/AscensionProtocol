using UnityEngine;
public class SpawnPointEnemy : MonoBehaviour
{
    public string grupoDeSpawn;
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public int maxEnemies = 5;

    private int enemyCount = 0;
    private bool activado = false;

    public void Activar()
    {
        if (!activado)
        {
            activado = true;
            InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);
        }
    }

    void SpawnEnemy()
    {
        if (enemyCount >= maxEnemies)
        {
            CancelInvoke(nameof(SpawnEnemy));
            Destroy(gameObject); // Elimina el spawnpoint cuando termina
            return;
        }

        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        enemyCount++;
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public float spawnRangeX = 10f;
    public float minSpeed = 3f;
    public float maxSpeed = 8f;
    public int maxEnemies = 5;
    public GameObject gameOverCanvas;
    public GameObject puertaDeTransicion;

    private int enemyCount = 0;
    private int enemigosVivos = 0;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
        gameOverCanvas.SetActive(false);
        if (puertaDeTransicion != null)
        {
            puertaDeTransicion.SetActive(false); // Desactiva la puerta al inicio
        }
    }

    void SpawnEnemy()
    {
        if (enemyCount >= maxEnemies)
        {
            CancelInvoke(nameof(SpawnEnemy));
            return;
        }

        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPosition = new Vector3(transform.position.x + randomX, transform.position.y, 0f);

        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        EnemyController enemyScript = newEnemy.GetComponent<EnemyController>();
        if (enemyScript != null)
        {
            enemyScript.speed = Random.Range(minSpeed, maxSpeed);
            enemyScript.SetGameController(this); // Asigna referencia a este GameController
        }

        enemyCount++;
        enemigosVivos++;
    }

    public void NotificarMuerteEnemigo()
    {
        enemigosVivos--;

        VerificarPuerta();
    }

    private void VerificarPuerta()
    {
        if (enemigosVivos <= 0 && enemyCount >= maxEnemies)
        {
            if (puertaDeTransicion != null)
            {
                puertaDeTransicion.SetActive(true);
            }
        }
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

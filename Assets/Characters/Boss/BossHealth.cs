using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 15;
    private int currentHealth;

    public GameObject healthBarUI; // Asigna el panel que contiene la barra
    public Slider healthSlider;    // Asigna la barra
    public GameObject deathEffectPrefab; //Efecto muerte

    void Start()
    {
        currentHealth = maxHealth;
        //if (healthBarUI != null) healthBarUI.SetActive(false);
    }

    public void ActivateHealthBar()
    {
        if (healthBarUI != null) healthBarUI.SetActive(true);
        if (healthSlider != null) healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);
        healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Aquí puedes poner animación de muerte, etc.
        if (deathEffectPrefab != null)
        {
            Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
        if (healthBarUI != null) healthBarUI.SetActive(false);
    }
}

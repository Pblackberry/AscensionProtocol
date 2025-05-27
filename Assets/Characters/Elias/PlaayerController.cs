using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    public int maxHealth = 5;
    private int currentHealth;
    public Slider vidaSlider;

    public GameObject gameOverScreen;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;

        if (vidaSlider != null)
        {
            vidaSlider.maxValue = maxHealth;
            vidaSlider.value = currentHealth;
        }

    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 moveDirection = new Vector2(moveX, moveY).normalized;

        rb.linearVelocity = moveDirection * speed;

        bool isWalking = moveDirection.magnitude > 0;
        animator.SetBool("isWalking", isWalking);
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Vida restante: " + currentHealth);

        if (vidaSlider != null)
        {
            vidaSlider.value = currentHealth;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Jugador ha muerto");
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
            Time.timeScale = 0f;
            vidaSlider.gameObject.SetActive(false);
        }
    }
}





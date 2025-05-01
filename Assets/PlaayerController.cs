using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 moveDirection = new Vector2(moveX, moveY).normalized;

        rb.linearVelocity = moveDirection * speed;

        bool isWalking = moveDirection.magnitude > 0;
        animator.SetBool("isWalking", isWalking);

        // Voltear al personaje dependiendo de la dirección en X
        // if (moveX < 0)
        // {
        //     transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        // }
        // else if (moveX > 0)
        // {
        //     transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        // }
        // Si moveX == 0, no cambia la escala (se mantiene como estaba)
    }
}





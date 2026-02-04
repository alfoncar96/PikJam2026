using UnityEngine;
using UnityEngine.InputSystem; // Importante para el Input System moderno

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public Animator animator;

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 input = new Vector2(x, y);

        if (input.magnitude > 1)
            input.Normalize();

        float animX = 0;
        float animY = 0;

        if (Mathf.Abs(x) > Mathf.Abs(y))
        {
            animX = Mathf.Sign(x);
            animY = 0;
        }
        else if (Mathf.Abs(y) > Mathf.Abs(x))
        {
            animY = Mathf.Sign(y);
            animX = 0;
        }

        bool moving = input != Vector2.zero;

        animator.SetBool("IsMoving", moving);

        if (moving)
        {
            animator.SetFloat("MoveX", animX);
            animator.SetFloat("MoveY", animY);
        }

        rb.linearVelocity = input * speed;
    }
}

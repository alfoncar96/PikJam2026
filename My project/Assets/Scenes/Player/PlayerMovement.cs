using UnityEngine;
using UnityEngine.InputSystem; // Importante para el Input System moderno

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4f;          // Velocidad del Player
    private Rigidbody2D rb;           // Rigidbody del Player
    private Animator anim;            // Animator para las animaciones
    private Vector2 movement;         // Vector de movimiento

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Reinicia movimiento
        movement = Vector2.zero;

        // Detecta las teclas presionadas usando Input System moderno
        if (Keyboard.current.wKey.isPressed) movement.y += 1;
        if (Keyboard.current.sKey.isPressed) movement.y -= 1;
        if (Keyboard.current.aKey.isPressed) movement.x -= 1;
        if (Keyboard.current.dKey.isPressed) movement.x += 1;

        // Actualiza el Animator
        anim.SetFloat("MoveX", movement.x);
        anim.SetFloat("MoveY", movement.y);
        anim.SetBool("IsMoving", movement != Vector2.zero);
    }

    void FixedUpdate()
    {
        // Movimiento físico del Player
        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }
}

using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //private Animator animator;

    public float speed = 12;

    Vector3 velocity;

    private new Rigidbody2D rigidbody;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //animator = GetComponent<Animator>();

        rigidbody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        float x = Input.GetAxisRaw("Horizontal");

        float y = Input.GetAxisRaw("Vertical");

        if (x != 0 || y != 0)
        {

            //animator.SetFloat("Horizontal", x);

            //animator.SetFloat("Vertical", y);

            //animator.SetFloat("Speed", 1);

            Vector3 direction = (Vector3.up * y + Vector3.right * x).normalized;

            velocity = speed * direction;

        }
        else
        {

            //animator.SetFloat("Speed", 0);

            velocity = Vector3.zero;

        }

    }

    void FixedUpdate()
    {

        rigidbody.MovePosition(transform.position + velocity * Time.fixedDeltaTime);

    }

}

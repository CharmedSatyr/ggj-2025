using Player;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Controller thePlayer;
    public GameObject death;

    public float speed = 0.3f;

    private float turnTimer = 0f;

    [SerializeField]
    float timeTrigger = 3f;

    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        thePlayer = FindFirstObjectByType<Controller>();
        rb = GetComponent<Rigidbody2D>();


        RestoreSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        turnTimer += Time.deltaTime;

        if (turnTimer >= timeTrigger)
        {
            TurnAround();
            turnTimer = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            TurnAround();
            rb.linearVelocity = Vector3.zero;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            GameController.EmitCollisionEvent(GameController.CollisionType.Hazard);
        }
    }

    void TurnAround()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        rb.linearVelocity = new Vector3(rb.transform.localScale.x * speed, rb.linearVelocity.y, 0f);
    }

    void RestoreSpeed()
    {
        rb.linearVelocity = new Vector3(rb.transform.localScale.x * speed, rb.linearVelocity.y, 0f);
    }
}

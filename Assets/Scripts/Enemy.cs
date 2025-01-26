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

    private Rigidbody2D myRigidbody;

    // Use this for initialization
    void Start()
    {
        thePlayer = FindFirstObjectByType<Controller>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody.linearVelocity = new Vector3(myRigidbody.transform.localScale.x * speed, myRigidbody.linearVelocity.y, 0f);

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
            Instantiate(death, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            GameController.EmitCollisionEvent(GameController.CollisionType.Hazard);
        }
    }

    void TurnAround()
    {
        if (transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }
}

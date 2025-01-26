using UnityEngine;

public class AirBubbleController : MonoBehaviour
{
    [SerializeField]
    float upwardSpeed = -1f;

    [SerializeField]
    float upperBound = 400f;

    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocityY = upwardSpeed;
    }

    void Update()
    {
        if (transform.position.y >= upperBound)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameController.EmitCollisionEvent(GameController.CollisionType.AirBubble);
        }
    }
}

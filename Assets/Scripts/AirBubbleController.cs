using UnityEngine;

public class AirBubbleController : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameController.EmitCollisionEvent(GameController.CollisionType.AirBubble);
        }
    }
}

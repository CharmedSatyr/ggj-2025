using UnityEngine;

public class AirBubbleInstance : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AirBubbleController.EmitCollectionEvent();
        }
    }
}

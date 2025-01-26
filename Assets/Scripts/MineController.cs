using UnityEngine;

public class MineController : MonoBehaviour
{

    public GameObject explosion;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
            GameController.EmitCollisionEvent(GameController.CollisionType.Hazard);
        }
    }
}

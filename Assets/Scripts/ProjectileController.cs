using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ProjectileController : MonoBehaviour
{
    [SerializeField]
    float timeout = 3f;

    void Start()
    {
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(timeout);

        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            GameController.EmitCollisionEvent(GameController.CollisionType.AirBubble);
            gameObject.SetActive(false);
        }
    }
}

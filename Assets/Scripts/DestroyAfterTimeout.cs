using System.Collections;
using UnityEngine;

public class DestroyAfterTimeout : MonoBehaviour
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
}

using System.Collections;
using UnityEngine;

namespace Player
{
    public class Controller : MonoBehaviour
    {
        public delegate void PlayerDeathEvent();
        public static event PlayerDeathEvent PlayerDeathInstance;

        void OnEnable()
        {
            GameController.HazardCollision += Die;
        }

        void OnDisable()
        {
            GameController.HazardCollision -= Die;
        }

        void Die()
        {
            PlayerDeathInstance.Invoke();

            StartCoroutine(Reset());

            GetComponent<SpriteRenderer>().enabled = false;
        }

        IEnumerator Reset()
        {
            yield return new WaitForSeconds(2);

            gameObject.transform.localPosition = Vector3.zero;

            GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
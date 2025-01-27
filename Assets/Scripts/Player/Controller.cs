using System.Collections;
using UnityEngine;

namespace Player
{
    public class Controller : MonoBehaviour
    {
        public delegate void PlayerDeathEvent();
        public static event PlayerDeathEvent PlayerDeathInstance;


        AudioSource audioSource;
        [SerializeField]
        AudioClip deathSound;

        void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        void OnEnable()
        {
            GameController.HazardCollision += Die;
            Victory.PlayerVictory += Win;
        }

        void OnDisable()
        {
            GameController.HazardCollision -= Die;
            Victory.PlayerVictory -= Win;
        }

        void Die()
        {
            PlayerDeathInstance.Invoke();

            audioSource.PlayOneShot(deathSound);

            GetComponent<SpriteRenderer>().enabled = false;

            StartCoroutine(ResetWithDelay(2));
        }

        void Win()
        {
            StartCoroutine(Wait());

            UnityEngine.SceneManagement.SceneManager.LoadScene("Title");
        }

        IEnumerator Wait()
        {
            yield return new WaitForSeconds(10f);
        }

        IEnumerator ResetWithDelay(int seconds)
        {
            yield return new WaitForSeconds(seconds);

            gameObject.transform.localPosition = Vector3.zero;

            GetComponent<SpriteRenderer>().enabled = true;
        }

    }
}
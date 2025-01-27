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
            StartCoroutine(ReturnToTitleAfterWait());
        }

        IEnumerator ReturnToTitleAfterWait()
        {
            float fadeDuration = 10f;

            AudioSource[] audioSources = FindObjectsByType<AudioSource>(FindObjectsSortMode.None);

            float[] initialVolumes = new float[audioSources.Length];
            for (int i = 0; i < audioSources.Length; i++)
            {
                initialVolumes[i] = audioSources[i].volume;
            }

            float elapsedTime = 0f;

            while (elapsedTime < fadeDuration)
            {
                elapsedTime += Time.deltaTime;

                float t = elapsedTime / fadeDuration;

                for (int i = 0; i < audioSources.Length; i++)
                {
                    if (audioSources[i] != null)
                    {
                        audioSources[i].volume = Mathf.Lerp(initialVolumes[i], 0f, t);
                    }
                }

                yield return null;
            }

            yield return new WaitForSeconds(fadeDuration);

            UnityEngine.SceneManagement.SceneManager.LoadScene("Title");
        }

        IEnumerator ResetWithDelay(int seconds)
        {
            yield return new WaitForSeconds(seconds);

            gameObject.transform.localPosition = Vector3.zero;

            GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
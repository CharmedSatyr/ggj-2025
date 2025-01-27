using System.Collections;
using TMPro;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    AudioSource audioSource;
    TextMeshProUGUI text;

    [SerializeField]
    AudioClip fartNoise;
    [SerializeField]
    AudioClip unthinkableNoise;

    void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        audioSource = GameObject.Find("Audio Source").GetComponent<AudioSource>();
    }

    void Start()
    {
        StartCoroutine(RunIntro());
    }

    IEnumerator RunIntro()
    {
        text.SetText("A diver swam in dangerous waters...");

        yield return new WaitForSeconds(3);

        text.SetText("A diver swam in dangerous waters...\n\nThe unthinkable happened.");

        yield return new WaitForSeconds(2);

        audioSource.PlayOneShot(unthinkableNoise);

        yield return new WaitForSeconds(3);

        text.SetText("As their last act, the diver made a solitary sound.");

        yield return new WaitForSeconds(2);

        audioSource.PlayOneShot(fartNoise);

        yield return new WaitForSeconds(3);

        text.SetText("As their last act, the diver made a solitary sound.\n\nYou are a resulting bubble.");

        yield return new WaitForSeconds(3);

        text.SetText("Find your way to the surface.");

        yield return new WaitForSeconds(3);

        text.SetText("Find your way to the surface.\n\nIt's probably what the diver would have wanted.");

        yield return new WaitForSeconds(5);

        UnityEngine.SceneManagement.SceneManager.LoadScene("Demo");
    }
}

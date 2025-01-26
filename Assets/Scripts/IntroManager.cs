using System.Collections;
using TMPro;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    TextMeshProUGUI text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
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

        yield return new WaitForSeconds(3);

        text.SetText("As their last act, the diver made a solitary sound.");

        yield return new WaitForSeconds(3);

        text.SetText("As their last act, the diver made a solitary sound.\n\nYou are the resulting bubble.");

        yield return new WaitForSeconds(3);

        text.SetText("Find your way to freedom.");

        yield return new WaitForSeconds(3);

        text.SetText("Find your way to freedom.\n\nIt's probably what the diver would have wanted.");

        yield return new WaitForSeconds(5);

        UnityEngine.SceneManagement.SceneManager.LoadScene("Demo");
    }
}

using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{
    [SerializeField] float backgroundFadeDuration = 1f;
    [SerializeField] float textAppearDuration = 3f;
    [SerializeField] float secondsToReset = 10f;

    TextMeshProUGUI youPopped;
    Image background;

    void OnEnable()
    {
        Player.Controller.PlayerDeathInstance += ShowDeathUI;
    }

    void OnDisable()
    {
        Player.Controller.PlayerDeathInstance -= ShowDeathUI;
    }

    void Start()
    {
        youPopped = GetComponentInChildren<TextMeshProUGUI>();
        background = GetComponentInChildren<Image>();
    }

    void ShowDeathUI()
    {
        StartCoroutine(FadeIn());
        StartCoroutine(Reset());
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(secondsToReset);

        Color textColor = youPopped.color;
        Color bgColor = background.color;

        textColor.a = 0f;
        bgColor.a = 0f;

        youPopped.color = textColor;
        background.color = bgColor;
    }

    IEnumerator FadeIn()
    {
        float timer = 0f;

        Color textColor = youPopped.color;
        Color bgColor = background.color;

        textColor.a = 0f;
        bgColor.a = 0f;

        youPopped.color = textColor;
        background.color = bgColor;

        while (timer < backgroundFadeDuration)
        {
            timer += Time.deltaTime;

            float bgAlpha = timer / backgroundFadeDuration;
            bgColor.a = Mathf.Lerp(0f, 1f, bgAlpha);

            background.color = bgColor;

            yield return null;
        }

        timer = 0f;

        while (timer < textAppearDuration)
        {
            timer += Time.deltaTime;

            float textAlpha = timer / textAppearDuration;
            textColor.a = Mathf.Lerp(0f, 1f, textAlpha);

            youPopped.color = textColor;

            yield return null;
        }

        textColor.a = 1f;
        bgColor.a = 1f;

        youPopped.color = textColor;
        background.color = bgColor;
    }
}

using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{
    [SerializeField] float backgroundFadeDuration = 1f;
    [SerializeField] float textAppearDuration = 3f;
    [SerializeField] float secondsToReset = 10f;

    TextMeshProUGUI text;
    Image background;

    void OnEnable()
    {
        Player.Controller.PlayerDeathInstance += ShowDeathUI;
        Victory.PlayerVictory += ShowVictoryUI;
    }

    void OnDisable()
    {
        Player.Controller.PlayerDeathInstance -= ShowDeathUI;
        Victory.PlayerVictory -= ShowVictoryUI;
    }

    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        background = GetComponentInChildren<Image>();
    }

    void ShowDeathUI()
    {
        text.SetText("You Popped");
        if (ColorUtility.TryParseHtmlString("#D92828", out Color color))
        {
            text.color = color;
        }
        background.color = Color.black;
        text.textWrappingMode = TextWrappingModes.NoWrap;

        StartCoroutine(FadeIn());
        StartCoroutine(ResetWithDelay(secondsToReset));
    }

    void ShowVictoryUI()
    {
        text.SetText("You honor the diver from whence you came and join the bubbles in the sky");
        if (ColorUtility.TryParseHtmlString("#C4AE40", out Color color))
        {
            text.color = color;
        }
        background.color = Color.white;
        text.textWrappingMode = TextWrappingModes.Normal;

        StartCoroutine(FadeIn());
        StartCoroutine(ResetWithDelay(10f));
    }

    IEnumerator ResetWithDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        Color textColor = text.color;
        Color bgColor = background.color;

        textColor.a = 0f;
        bgColor.a = 0f;

        text.color = textColor;
        background.color = bgColor;
    }

    IEnumerator FadeIn()
    {
        float timer = 0f;

        Color textColor = text.color;
        Color bgColor = background.color;

        textColor.a = 0f;
        bgColor.a = 0f;

        text.color = textColor;
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

            text.color = textColor;

            yield return null;
        }

        textColor.a = 1f;
        bgColor.a = 1f;

        text.color = textColor;
        background.color = bgColor;
    }
}

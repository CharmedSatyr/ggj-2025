using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{
    [SerializeField] float backgroundFadeDuration = 2f;
    [SerializeField] float textAppearDuration = 3f;


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
    }

    IEnumerator FadeIn()
    {
        float timer = 0f;

        Color textColor = youPopped.color;
        Color bgColor = background.color;

        textColor.a = 0f;
        bgColor.a = 0f;

        youPopped.color = textColor;
        background.color = textColor;

        while (timer < backgroundFadeDuration)
        {
            timer += Time.deltaTime;

            float bgAlpha = timer / backgroundFadeDuration;
            bgColor.a = Mathf.Lerp(0f, 1f, bgAlpha);

            float textAlpha = timer / textAppearDuration;
            textColor.a = Mathf.Lerp(0f, 1f, textAlpha);

            youPopped.color = textColor;
            background.color = bgColor;

            yield return null;
        }

        textColor.a = 1f;
        bgColor.a = 1f;

        youPopped.color = textColor;
        background.color = bgColor;
    }
}

using System.Collections;
using UnityEngine;

public class Size : MonoBehaviour
{
    Attack attackController;
    SpriteRenderer spriteRenderer;

    [SerializeField]
    float shrinkMultiplier = 0.9f;

    [SerializeField]
    float growMultiplier = 1.1f;

    [SerializeField]
    float resizeDuration = 1f;

    [SerializeField]
    Vector3 minSize = new(0.5f, 0.5f, 0.5f);

    [SerializeField]
    Vector3 maxSize = new(3, 3, 3);

    public bool IsMinSize { get; private set; } = false;
    public bool IsMaxSize { get; private set; } = false;

    Vector3 originalSize;

    void Awake()
    {
        attackController = GetComponent<Attack>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        originalSize = GetComponent<Transform>().localScale;
    }

    void OnEnable()
    {
        GameController.CollectedAirBubble += Grow;
        attackController.AttackEventInstance += Shrink;
        Player.Controller.PlayerDeathInstance += Reset;
    }

    void OnDisable()
    {
        GameController.CollectedAirBubble -= Grow;
        attackController.AttackEventInstance -= Shrink;
        Player.Controller.PlayerDeathInstance -= Reset;

    }

    void Reset()
    {
        spriteRenderer.transform.localScale = originalSize;
    }

    void Shrink()
    {
        if (spriteRenderer.transform.localScale.magnitude <= minSize.magnitude)
        {
            IsMinSize = true;
            return;
        }

        if (IsMinSize)
        {
            IsMinSize = false;
        }

        StartCoroutine(Resize(shrinkMultiplier));
    }

    void Grow()
    {
        if (spriteRenderer.transform.localScale.magnitude >= maxSize.magnitude)
        {
            IsMaxSize = true;
            return;
        }

        if (IsMaxSize)
        {
            IsMaxSize = false;
        }

        StartCoroutine(Resize(growMultiplier));
    }


    IEnumerator Resize(float multiplier)
    {
        float timer = 0f;

        Vector3 startScale = spriteRenderer.transform.localScale;
        Vector3 endScale = spriteRenderer.transform.localScale * multiplier;

        while (timer < resizeDuration)
        {
            timer += Time.deltaTime;
            float t = timer / resizeDuration;

            spriteRenderer.transform.localScale = Vector3.Lerp(startScale, endScale, t);

            yield return null;
        }

        spriteRenderer.transform.localScale = endScale;
    }
}

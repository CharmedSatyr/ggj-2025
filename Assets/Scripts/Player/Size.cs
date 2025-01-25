using UnityEngine;

public class Size : MonoBehaviour
{
    Attack attackController;
    SpriteRenderer spriteRenderer;

    [SerializeField]
    float shrinkMultiplier = 0.9f;

    [SerializeField]
    Vector3 minSize;

    public bool IsMinSize { get; private set; } = false;

    void Awake()
    {
        attackController = GetComponent<Attack>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnEnable()
    {
        attackController.AttackEventInstance += Shrink;
    }

    void OnDisable()
    {
        attackController.AttackEventInstance -= Shrink;
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

        spriteRenderer.transform.localScale = spriteRenderer.transform.localScale * shrinkMultiplier;
    }
}

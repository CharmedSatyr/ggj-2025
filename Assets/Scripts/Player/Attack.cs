using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D projectile;

    [SerializeField]
    float projectileForce;

    Transform playerTransform;
    Size sizeController;

    bool canAttack = true;

    [SerializeField]
    float attackCooldown = 0.5f;

    public delegate void AttackEvent();
    public event AttackEvent AttackEventInstance;

    void Awake()
    {
        playerTransform = GetComponent<Transform>();
        sizeController = GetComponent<Size>();
    }

    void OnAttack(InputValue inputValue)
    {
        Vector2 normalizedInput = inputValue.Get<Vector2>().normalized;

        if (normalizedInput == Vector2.zero) { return; }
        if (sizeController.IsMinSize) { return; }
        if (!canAttack) { return; }

        Execute(normalizedInput);
    }

    void Execute(Vector2 direction)
    {
        AttackEventInstance?.Invoke();

        Rigidbody2D p = Instantiate(projectile, playerTransform.position, projectile.transform.rotation);
        p.AddForce(direction * projectileForce);

        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown()
    {
        canAttack = false;

        yield return new WaitForSeconds(attackCooldown);

        canAttack = true;
    }
}

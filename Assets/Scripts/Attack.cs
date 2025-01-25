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

    bool canAttack = true;
    float attackCooldown = 0.5f;

    void Start()
    {
        playerTransform = GameObject.Find("Bubble").transform;
    }

    void OnAttack(InputValue inputValue)
    {
        Vector2 normalizedInput = inputValue.Get<Vector2>().normalized;

        if (normalizedInput == Vector2.zero) { return; }
        if (!canAttack) { return; }

        Execute(normalizedInput);
    }

    void Execute(Vector2 direction)
    {
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

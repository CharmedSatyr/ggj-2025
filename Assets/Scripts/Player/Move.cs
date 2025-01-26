using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    Vector2 moveInput;

    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        Player.Controller.PlayerDeathInstance += Reset;
    }

    void OnDisable()
    {
        Player.Controller.PlayerDeathInstance -= Reset;
    }

    void Reset()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Execute();
    }

    void OnMove(InputValue inputValue)
    {
        moveInput = inputValue.Get<Vector2>();
    }

    void Execute()
    {
        rb.AddForce(moveInput * moveSpeed);
    }
}

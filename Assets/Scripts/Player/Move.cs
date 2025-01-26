using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    Vector2 moveInput;

    [SerializeField]
    float victoryRiseSpeed = 2f;

    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GetComponent<PlayerInput>().enabled = true;
    }

    void OnEnable()
    {
        Player.Controller.PlayerDeathInstance += Reset;
        Victory.PlayerVictory += HandleVictory;
    }

    void OnDisable()
    {
        Player.Controller.PlayerDeathInstance -= Reset;
        Victory.PlayerVictory -= HandleVictory;
    }

    void Reset()
    {
        GetComponent<PlayerInput>().enabled = false;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = 0f;
        GetComponent<PlayerInput>().enabled = true;
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

    void HandleVictory()
    {
        Reset();
        GetComponent<PlayerInput>().enabled = false;
        rb.linearVelocity = new Vector3(0f, victoryRiseSpeed);
    }
}

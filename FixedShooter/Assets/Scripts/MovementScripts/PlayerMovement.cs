using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 5.0f;
    [SerializeField] private float sprintMultiplier = 1.5f;


    private Rigidbody2D rigidBody;
    
    
    private PlayerInputHandler inputHandler;
    private float horizontalInput;
    private float verticalInput;


    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        inputHandler = PlayerInputHandler.Instance;
    }

    private void Start()
    {
        inputHandler = PlayerInputHandler.Instance;
    }

    private void Update()
    {
        horizontalInput = inputHandler.MoveInput.x;
        verticalInput = inputHandler.MoveInput.y;
    }

    private void FixedUpdate()
    {
        ApplyMovement();
    }

    void ApplyMovement()
    {
        float speed = walkSpeed * (inputHandler.SprintValue > 0 ? sprintMultiplier : 1f);
        rigidBody.linearVelocity = new Vector2(horizontalInput, verticalInput) * speed;
    }

}

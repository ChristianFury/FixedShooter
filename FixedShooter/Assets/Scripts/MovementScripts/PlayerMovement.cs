using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 3.0f;
    [SerializeField] private float sprintMultiplier = 1.5f;


    private Rigidbody2D rigidBody;
    private Camera mainCamera;
    private PlayerInputHandler inputHandler;
    private Vector2 currentMovement;


    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        inputHandler = GetComponent<PlayerInputHandler>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       HandleMovement();

    }

    void HandleMovement()
    {
        float speed = walkSpeed * (inputHandler.SprintValue > 0 ? sprintMultiplier : 1f);

        Vector2 inputDirection = new Vector2(inputHandler.MoveInput.x, inputHandler.MoveInput.y);
        Vector2 worldDirection = transform.TransformDirection(inputDirection);
        worldDirection.Normalize();

        currentMovement.x = worldDirection.x * speed;
        currentMovement.y = worldDirection.y * speed;

        rigidBody.Move(currentMovement * Time.deltaTime);
    }
}

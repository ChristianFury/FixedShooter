using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    //Brings in the player input file that we made, mapping controls to different keys
    [SerializeField] private InputActionAsset playerControls;

    //Referencing the specific control mapping, the one for this game.
    [SerializeField] private string actionMapName = "Player2DTopDown";

    //These two reference the specific controls within the Player2DTopDown map
    [SerializeField] private string move = "Move";
    [SerializeField] private string sprint = "Sprint";

    //Creating the variables to use in the script
    private InputAction moveAction;
    private InputAction sprintAction;

    //Properties for each value to know when buttons are pressed
    //The get and private set are used to make them more protected
    //Boolean is for true or false, float is for great than a certain value
    public Vector2 MoveInput { get; private set; }
    public float SprintValue { get; private set; }

    //This allows me to reference this script from other scripts
    public static PlayerInputHandler Instance { get; private set; }

    //This makes sure this instance won't be duplicated
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        //finds the action on the action map
        moveAction = playerControls.FindActionMap(actionMapName).FindAction(move);
        sprintAction = playerControls.FindActionMap(actionMapName).FindAction(sprint);      
    
        RegisterInputActions();
    }

    //This registers the inputs and connects them with the above variables, taking the correct input.
    void RegisterInputActions()
    {
        moveAction.performed += context => MoveInput = context.ReadValue<Vector2>();
        moveAction.canceled += context => MoveInput = Vector2.zero;

        sprintAction.performed += context => SprintValue = context.ReadValue<float>();
        sprintAction.canceled += context => SprintValue = 0f;
    
    }

    private void OnEnable()
    {
        moveAction.Enable();
        sprintAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        sprintAction.Disable();
    }


}

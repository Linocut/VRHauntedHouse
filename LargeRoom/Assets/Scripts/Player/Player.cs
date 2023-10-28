using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    #region Singleton
    private static Player _singleton;
    public static Player Singleton
    {
        get => _singleton;
        private set
        {
            if (_singleton == null)
            {
                _singleton = value;
                DontDestroyOnLoad(value);
            }
            else if (_singleton != value)
            {
                Debug.Log($"{nameof(Player)} instance already exists, destoying duplicate");
                Destroy(value);
            }
        }
    }

    private void Awake()
    {
        Singleton = this;
    }
    #endregion

    public bool canMove = true;
    public float speed = 0.0625f;
    public float turnSpeed = 65f;
    public float gravity = -9.81f;

    [Header("XR Input")]
    public InputActionProperty moveInputSource;
    public InputActionProperty turnInputSource;

    [Header("Body")]
    public GameObject rig;
    public LayerMask groundLayer;
    public Transform directionSource;
    public Transform turnSource;
    public CapsuleCollider bodyCollider;
    public CharacterController charController;

    private float gravityAcceleration;
    private float yVelocity;
    private Vector2 inputMoveAxis;
    private float inputTurnAxis;

    // Start is called before the first frame update
    void Start()
    {
        gravityAcceleration = gravity * Time.fixedDeltaTime * Time.fixedDeltaTime; // Calculate gravity acceleration
    }

    // Update is called once per frame
    void Update()
    {
        inputMoveAxis = moveInputSource.action.ReadValue<Vector2>(); // Get move button
        inputTurnAxis = turnInputSource.action.ReadValue<Vector2>().x; // Get turn button
    }

    private void FixedUpdate()
    {
        charController.height = bodyCollider.height;
        charController.center = bodyCollider.center;
        charController.radius = bodyCollider.radius;

        bool isGrounded = CheckIfGrounded();
        Vector3 movement = Vector3.zero;

        Quaternion yaw = Quaternion.Euler(0, directionSource.eulerAngles.y, 0); // Take into account where player is facing
        if (canMove)
        {
            Vector3 direction = yaw * new Vector3(inputMoveAxis.x * speed, 0, inputMoveAxis.y * speed); // Get direction player is looking and move according to it
            movement = direction;
        }

        if (isGrounded)
        {
            yVelocity = 0;
        }

        Vector3 axis = Vector3.up;
        float angle = turnSpeed * Time.fixedDeltaTime * inputTurnAxis;
        Quaternion q = Quaternion.AngleAxis(angle, axis);
        rig.transform.rotation = charController.transform.rotation * q; // Rotate camera


        yVelocity += gravityAcceleration;
        movement.y = yVelocity;

        movement *= Time.deltaTime;
        charController.Move(movement);
    }

    public bool CheckIfGrounded()
    {
        Vector3 start = charController.transform.TransformPoint(charController.center); // Get charController's center
        float rayLength = charController.height / 2 - charController.radius + 0.05f; // Distance from 'start' to end of charController + bit extra to detect ground

        bool hasHit = Physics.SphereCast(start, charController.radius, Vector3.down, out RaycastHit hitInfo, rayLength, groundLayer); // Detect if ground layer was found

        return hasHit;
    }
}

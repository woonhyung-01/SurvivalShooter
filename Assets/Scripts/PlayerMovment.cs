using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 10f;
    
    private Animator playerAnimator;
    private PlayerInput playerInput;
    private Rigidbody playerRigidbody;

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
        
    }

    private void FixedUpdate()
    {
        moveSpeed = 15f;
        Vector3 direction = Vector3.zero;
         direction.x = Input.GetAxis("Horizontal"); //a, d
         direction.z = Input.GetAxis("Vertical"); // w. s
         if(direction.magnitude > 1f)
        {
            direction.Normalize();
        }
        playerRigidbody.linearVelocity = direction * moveSpeed;
        playerAnimator.SetBool("IsMoving", direction.magnitude > 0);
    }
}

using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 10f;
    [SerializeField]
    private bool isRotation = true;
    
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
        if (isRotation == false) return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.up);

        if(plane.Raycast(ray, out float distance))
        {
            Vector3 direction = ray.GetPoint(distance) - transform.position;
            transform.rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        }
        
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

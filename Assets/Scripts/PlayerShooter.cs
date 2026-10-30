using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Gun gun;
    private Animator playerAnimator;
    private PlayerInput playerInput;

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        if (playerInput.Fire)
        {
            gun.Fire();
        }
    }
}

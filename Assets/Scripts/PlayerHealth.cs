using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class PlayerHealth : LivingEntity
{
    public static readonly int IdDeath = Animator.StringToHash("Death");

    public Image uiHealth;

    public AudioClip hitClip;
    public AudioClip deathClip;

    private AudioSource playerAuioSource;
    private Animator playerAnimator;
    private PlayerMovment playerMovment;
    private PlayerInput playerInput;

    private void Awake()
    {
        playerAuioSource = GetComponent<AudioSource>();
        playerAnimator = GetComponent<Animator>();
        playerMovment = GetComponent<PlayerMovment>();
        playerInput = GetComponent<PlayerInput>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        playerMovment.enabled = true;
        playerInput.enabled = true;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnDamage(30, Vector3.zero, Vector3.zero);
            Debug.Log(-30);
        }
        
    }

    public override void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal)
    {
        if (!IsDead)
        {
            playerAuioSource.PlayOneShot(hitClip);
        }
        base.OnDamage(damage, hitPoint, hitNormal);

    }

    public override void Death()
    {
        base.Death();

        playerAnimator.SetTrigger(IdDeath);
        playerAuioSource.PlayOneShot(deathClip);

        playerMovment.enabled = false;
        playerInput.enabled = false;

    }
}

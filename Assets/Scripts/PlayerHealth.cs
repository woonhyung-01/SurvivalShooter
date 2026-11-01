using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : LivingEntity
{
    public static readonly int IdDeath = Animator.StringToHash("Death");

    public Slider hpSlider;

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

    private void Start()
    {
        hpSlider.maxValue = startingHealth;
        hpSlider.value = Health;
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        playerMovment.enabled = true;
        playerInput.enabled = true;

        hpSlider.gameObject.SetActive(true);

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

        hpSlider.value = Health;
        

    }

    public override void Death()
    {
        base.Death();

        hpSlider.value = Health;

        playerAnimator.SetTrigger(IdDeath);
        playerAuioSource.PlayOneShot(deathClip);

        playerMovment.enabled = false;
        playerInput.enabled = false;

        GameManager.instance.EndGame();
        

    }

    public void RestartLevel()
    {
        
    }
}

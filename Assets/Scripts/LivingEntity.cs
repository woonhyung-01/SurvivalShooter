using UnityEngine;
using UnityEngine.Events;

public class LivingEntity : MonoBehaviour, IDamageable
{
    public float startingHealth = 100f;
    public float Health {get; private set;}
    public bool IsDead {get; private set;}

    public UnityEvent OnDead;
    protected virtual void OnEnable()
    {
        IsDead = false;
        Health = startingHealth;
    }
    public virtual void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal)
    {
        
        if (IsDead)
        {
            return;
        }
        Debug.Log($"피격 전: {Health}");
        Health -= damage;
        if(Health <= 0f)
        {
            Health = 0f;
            Death();
        }
        Debug.Log($"피격 후: {Health}");
    }

    public virtual void Death()
    {
        IsDead = true;
        OnDead.Invoke();
    }
}

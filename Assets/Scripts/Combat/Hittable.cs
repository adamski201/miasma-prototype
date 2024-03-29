using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Health))]
public class Hittable : MonoBehaviour
{
    [SerializeField] private DamageEntityTypes receivableDamageType;
    public UnityEvent onHit;
    private Health health;
    private Knockbackable knockback;
    private Stunnable stun;

    private void Awake()
    {
        health = GetComponent<Health>();
        knockback = GetComponent<Knockbackable>();
        stun = GetComponent<Stunnable>();
    }

    public void TakeHit(Hit hit)
    {
        if (hit.entityToDamage.Equals(receivableDamageType))
        {
            TakeDamage(hit.damage);
            onHit?.Invoke();

            if (knockback != null)
            {
                knockback.InflictKnockback(hit.knockbackSource, hit.knockbackForce);
            }

            if (stun != null)
            {
                stun.InflictStun(hit.stunTimer);
            }
        }
    }

    public void TakeDamage(int amount)
    {
        health.ChangeHealth(-1 * amount);
    }
}

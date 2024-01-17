using System;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected float MaxHealth;
    [SerializeField] protected float Damage;
    
    public event Action<float, float> HealthChanged;
    
    protected Attacker Attacker;
    protected Health Health;
    
    private void Awake()
    {
        Attacker = new Attacker(Damage);
        Health = new Health(MaxHealth);
    }

    public void TakeDamage(float damage)
    {
        if (0 >= Health.HP)
        {
            Destroy(gameObject);
        }
        
        Health.ToDamage(damage);
        HealthChanged?.Invoke(Health.HP, MaxHealth);
    }

    public void Heal(float heal)
    {
        Health.ToHeal(heal, MaxHealth);
        HealthChanged?.Invoke(Health.HP, MaxHealth);
    }
}

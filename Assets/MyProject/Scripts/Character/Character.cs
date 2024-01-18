using System;
using UnityEngine;

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
        
        Health.TakeDamage(damage);
        HealthChanged?.Invoke(Health.HP, MaxHealth);
    }

    public void HealPizza(Pizza heal)
    {
        if (MaxHealth > Health.HP)
        {
            Health.Heal(heal.Heal(), MaxHealth);
            HealthChanged?.Invoke(Health.HP, MaxHealth);
            Destroy(heal.gameObject);
        }
    }

    public void Heal(float heal)
    {
        Health.Heal(heal, MaxHealth);
        HealthChanged?.Invoke(Health.HP, MaxHealth);
    }
}

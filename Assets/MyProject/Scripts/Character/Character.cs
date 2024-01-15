using System;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected float maxHealth;
    [SerializeField] protected float damage;
    public event Action<float, float> HealthChanged;
    
    protected Attacker attacker;
    protected Health health;
    
    private void Awake()
    {
        attacker = new Attacker(damage);
        health = new Health(maxHealth);
    }

    public void TakeDamage(float damage)
    {
        if (0 >= health.HP)
        {
            Destroy(gameObject);
        }
        
        health.ToDamage(damage);
        HealthChanged?.Invoke(health.HP, maxHealth);
    }

    public void ToHeal(float heal)
    {
        health.ToHeal(heal, maxHealth);
        HealthChanged?.Invoke(health.HP, maxHealth);
    }
}

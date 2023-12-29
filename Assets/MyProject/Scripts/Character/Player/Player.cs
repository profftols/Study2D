using System;
using UnityEngine;

public class Player : Character
{
    public event Action<float, float> HealthChanged;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(attacker.Damage);
        }
    }

    public void ToHeal(float heal)
    {
        health.ToHeal(heal, maxHealth);
        HealthChanged?.Invoke(health.HP, maxHealth);
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        HealthChanged?.Invoke(health.HP, maxHealth);
    }
}

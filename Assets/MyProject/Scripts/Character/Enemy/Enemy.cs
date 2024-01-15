using System;
using UnityEngine;

public class Enemy : Character
{
    //public event Action<float, float> HealthChanged;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            player.TakeDamage(attacker.Damage);
        }
    }
}

using System;
using UnityEngine;

public class Enemy : Character
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            player.TakeDamage(Attacker.Damage);
        }
    }
}

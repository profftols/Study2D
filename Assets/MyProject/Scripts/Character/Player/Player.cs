using System;
using UnityEngine;

public class Player : Character
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(attacker.Damage);
        }
    }
}

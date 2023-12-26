using UnityEngine;

public class Player : Character
{
    private UIBar _ui;

    private void Start()
    {
        _ui = FindAnyObjectByType<UIBar>();
    }
    
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
        ChangeHealthBar();
    }

    public void ChangeHealthBar()
    {
        _ui.HealthBar(health.HP, maxHealth);
    }
}

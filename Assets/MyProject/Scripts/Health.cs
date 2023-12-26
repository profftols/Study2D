using UnityEngine;

public class Health
{
    public float HP { get; private set; }
    
    public Health(float hp)
    {
        HP = hp;
    }
    
    public void ToHeal(float heal, float maxHP)
    {
        if (HP + heal > maxHP)
        {
            HP = maxHP;
        }
        else
        {
            HP += heal;
        }
    }

    public void ToDamage(float damage)
    {
        HP -= damage;
    }
}

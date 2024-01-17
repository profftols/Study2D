public class Health
{
    public float HP { get; private set; }
    
    public Health(float hp)
    {
        HP = hp;
    }
    
    public void Heal(float heal, float maxHP)
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

    public void TakeDamage(float damage)
    {
        HP -= damage;
    }
}

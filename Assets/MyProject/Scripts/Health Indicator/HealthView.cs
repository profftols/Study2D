using UnityEngine;

public class HealthView : MonoBehaviour
{
    [SerializeField] protected Character Character;

    public virtual void ChangeNumber(float hpCorrect, float maxHp) { }

    protected void OnEnable()
    {
        Character.HealthChanged += ChangeNumber;
    }

    protected void OnDisable()
    {
        Character.HealthChanged -= ChangeNumber;
    }
}
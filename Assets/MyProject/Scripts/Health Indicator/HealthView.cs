using UnityEngine;
using UnityEngine.Serialization;

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
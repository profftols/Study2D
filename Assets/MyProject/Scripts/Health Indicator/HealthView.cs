using UnityEngine;
using UnityEngine.Serialization;

public class HealthView : MonoBehaviour
{
    [SerializeField] protected Character _character;

    public virtual void ChangeNumber(float hpCorrect, float maxHp) { }

    protected void OnEnable()
    {
        _character.HealthChanged += ChangeNumber;
    }

    protected void OnDisable()
    {
        _character.HealthChanged -= ChangeNumber;
    }
}
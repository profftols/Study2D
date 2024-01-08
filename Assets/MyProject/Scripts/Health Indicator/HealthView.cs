using UnityEngine;

public class HealthView : MonoBehaviour
{
    [SerializeField] protected Player _player;

    public virtual void ChangeNumber(float hpCorrect, float maxHp) { }

    protected void OnEnable()
    {
        _player.HealthChanged += ChangeNumber;
    }

    protected void OnDisable()
    {
        _player.HealthChanged -= ChangeNumber;
    }
}
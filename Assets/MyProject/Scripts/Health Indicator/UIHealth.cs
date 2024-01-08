using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Scrollbar))]
public class UIHealth : HealthView
{
    private Scrollbar _bar;
    
    private void Awake()
    {
        _bar = GetComponent<Scrollbar>();
    }
    
    public override void ChangeNumber(float hpCorrect, float maxHp)
    {
        _bar.size = hpCorrect / maxHp;
    }
}

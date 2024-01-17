using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UIHealth : HealthView
{
    private Image _bar;
    
    private void Awake()
    {
        _bar = GetComponent<Image>();
    }
    
    public override void ChangeNumber(float hpCorrect, float maxHp)
    {
        _bar.fillAmount = hpCorrect / maxHp;
    }
}

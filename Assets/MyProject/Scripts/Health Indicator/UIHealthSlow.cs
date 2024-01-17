using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UIHealthSlow : HealthView
{
    private Coroutine _timerChanger;
    private Image _bar;
    private float _step = 0.01f;
    private float _stepTime = 0.025f;

    private void Awake()
    {
        _bar = GetComponent<Image>();
    }
    
    public override void ChangeNumber(float hpCorrect, float maxHp)
    {
        if (_timerChanger != null)
        {
            StopCoroutine(_timerChanger);
        }
        
        _timerChanger = StartCoroutine(ChangeSlow(hpCorrect, maxHp));
    }
    
    private IEnumerator ChangeSlow(float hpCorrect, float maxHp)
    {
        var wait = new WaitForSeconds(_stepTime);
        float result = 0f;

        while (_bar.fillAmount != result)
        {
            result = _bar.fillAmount;
            _bar.fillAmount = Mathf.MoveTowards(_bar.fillAmount, hpCorrect / maxHp, _step);
            yield return wait;
        }
        
        _timerChanger = null;
    }
}

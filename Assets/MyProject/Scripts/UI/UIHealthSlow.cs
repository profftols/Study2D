using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Scrollbar))]
public class UIHealthSlow : HealthView
{
    private Coroutine _timerChanger;
    private Scrollbar _bar;
    private float _step = 0.01f;
    private float _stepTime = 0.05f;

    private void Awake()
    {
        _bar = GetComponent<Scrollbar>();
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

        while (_bar.size != result)
        {
            result = _bar.size;
            _bar.size = Mathf.MoveTowards(_bar.size, hpCorrect / maxHp, _step);
            yield return wait;
        }
        
        _timerChanger = null;
    }
}

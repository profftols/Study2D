using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIBar : MonoBehaviour
{
    [SerializeField] private Text _healthText;
    [SerializeField] private Scrollbar _healthBar;
    [SerializeField] private Scrollbar _healthBarSlow;

    private Coroutine _coroutine;
    private float _hpCorrect;
    private float _maxHp;
    private float _step = 0.01f;
    private float _stepTime = 0.05f;

    public void HealthBar(float hpCorrect, float maxHp)
    {
        _hpCorrect = hpCorrect;
        _maxHp = maxHp;

        ChangeNumber();
        ChangeStrip();

        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(ChangeSlow());
        }
    }

    private void ChangeNumber()
    {
        _healthText.DOText(_healthText.text = _hpCorrect + " / " + _maxHp, _step);
    }

    private IEnumerator ChangeSlow()
    {
        var wait = new WaitForSeconds(_stepTime);

        while (_healthBarSlow.size != _healthBar.size)
        {
            _healthBarSlow.size = Mathf.MoveTowards(_healthBarSlow.size, _hpCorrect / _maxHp, _step);
            yield return wait;
        }

        _coroutine = null;
    }

    private void ChangeStrip()
    {
        _healthBar.size = _hpCorrect / _maxHp;
    }
}
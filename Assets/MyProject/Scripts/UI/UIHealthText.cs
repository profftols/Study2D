using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class UIHealthText : UIBar
{
    private Text _healthText;
    private float _step = 0.01f;
    
    private void Awake()
    {
        _healthText = GetComponent<Text>();
    }

    private void OnEnable()
    {
        OnBarChanged += ChangeNumber;
    }

    private void OnDisable()
    {
        OnBarChanged -= ChangeNumber;
    }
    
    private void ChangeNumber(float hpCorrect, float maxHp)
    {
        _healthText.DOText(_healthText.text = hpCorrect + " / " + maxHp, _step);
    }
}

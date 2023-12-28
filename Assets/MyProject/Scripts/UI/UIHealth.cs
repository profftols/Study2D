using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Scrollbar))]
public class UIHealth : UIBar
{
    private Scrollbar _bar;
    
    private void Awake()
    {
        _bar = GetComponent<Scrollbar>();
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
        _bar.size = hpCorrect / maxHp;
    }
}

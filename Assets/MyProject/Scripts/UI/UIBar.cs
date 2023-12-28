using System;
using UnityEngine;

public class UIBar : MonoBehaviour
{
    public static Action<float, float> OnBarChanged;

    public void HealthBar(float hpCorrect, float maxHp)
    {
        OnBarChanged?.Invoke(hpCorrect, maxHp);
    }
}
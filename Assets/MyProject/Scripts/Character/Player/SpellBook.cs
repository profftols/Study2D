using System;
using UnityEngine;

public class SpellBook : MonoBehaviour
{
    [SerializeField] private float _damage;

    protected Enemy Enemy;
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            Enemy = enemy;
            
            if (Input.GetKey(KeyCode.F) && Enemy)
            {
                Cast();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            Enemy = null;
        }
    }

    protected virtual void Cast(){}

}

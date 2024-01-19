using System.Collections;
using UnityEngine;

public class Reaper : SpellBook
{
    private Coroutine _spell;
    private Player _player;
    private float _spellSpeed = 0.8f;
    private float _spellDamage = 3.5f;
    private int _timer;

    private void Awake()
    {
        _player = GetComponentInParent<Player>();
    }

    protected override void Cast()
    {
        if (_spell == null)
           _spell = StartCoroutine(Spell());
    }

    private IEnumerator Spell()
    {
        var wait = new WaitForSeconds(_spellSpeed);
        int timer = 7;

        while (timer > _timer && Enemy)
        {
            Enemy.TakeDamage(_spellDamage);
            _player.Heal(_spellDamage);
            _timer++;
            yield return wait;
        }

        _timer = 0;
        _spell = null;
    }
}

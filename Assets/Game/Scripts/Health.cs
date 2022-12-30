using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float HP_max;
    public float HP_current;
    private void Awake()
    {
        HP_current = HP_max;
    }

    public void ApplyDamage(float damage)
    {
        HP_current -= damage;
        if (HP_current <= 0)
        {
            if (this.gameObject.tag == "Enemy")
            {
                enemy _enemy = GetComponent<enemy>();
                _enemy.SwitchToNewState(enemy.CharacterState.Dead);
            }
            else if (this.gameObject.tag == "Player")
            {
                player _player = GetComponent<player>();
                _player.SwitchToNewState(player.CharacterState.Dead);
            }
        }
    }
}

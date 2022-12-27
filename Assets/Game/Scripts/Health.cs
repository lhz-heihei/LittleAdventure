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
    }
}

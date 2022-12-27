using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ApplyDamage : MonoBehaviour
{
    public Collider _collider;
    public List<Collider> damageTargets;
    public string TargetTag;
    public float Damage;
    private void Awake()
    {
        damageTargets = new List<Collider>();
        _collider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag==TargetTag&&!damageTargets.Contains(other))
        {
            Health health_other = other.GetComponent<Health>();
            health_other.ApplyDamage(Damage);
            damageTargets.Add(other);
        }
    }


}

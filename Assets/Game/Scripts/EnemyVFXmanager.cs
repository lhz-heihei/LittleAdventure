using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class EnemyVFXmanager : MonoBehaviour
{
    public VisualEffect footStep;
    public VisualEffect Smash;
    public ParticleSystem BeingHit;
    void BurstFootStep()
    {
        footStep.Play();
        
    }

    void PlaySmash()
    {
        Smash.Play();
    }

    public void PlayBeingHit(Vector3 attackerPos)
    {
        Vector3 dir = BeingHit.transform.position - attackerPos;
        dir.y = 0;
     
        BeingHit.transform.rotation = Quaternion.LookRotation(dir);
        BeingHit.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class EnemyVFXmanager : MonoBehaviour
{
    public VisualEffect footStep;
    public VisualEffect Smash;
    void BurstFootStep()
    {
        footStep.Play();
        
    }

    void PlaySmash()
    {
        Smash.Play();    }
}

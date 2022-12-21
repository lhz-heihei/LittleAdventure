using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class EnemyVFXmanager : MonoBehaviour
{
    public VisualEffect footStep;
    void BurstFootStep()
    {
        footStep.Play();
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;


public class PlayerVFXmanager : MonoBehaviour
{
    public VisualEffect footstep;
    public void update_footstep(bool state)
    {
        if(state)
        {
            footstep.Play();
        }
        else
        {
            footstep.Stop();
        }
    }
}

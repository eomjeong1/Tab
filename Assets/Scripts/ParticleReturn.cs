using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleReturn : MonoBehaviour
{
    private void OnParticleSystemStopped()
    {
        var particle = GetComponent<ParticleSystem>();
        EffectManager.GetInstance().ReturnEffect(particle); // ReturnEffect 로 전달하게 될 것
    }
}    

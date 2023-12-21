using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeParticle : MonoBehaviour
{
    public ParticleSystem partSys;

    void Start()
    {
        EventHandler.SmokeExtinguishInteractiveEvent += OnSmokeExtinguishInteractiveEvent;
    }

    public void OnSmokeExtinguishInteractiveEvent(ItemName name)
    {
        if(partSys != null)
        {
            partSys.Stop();
        }
        

    }
}

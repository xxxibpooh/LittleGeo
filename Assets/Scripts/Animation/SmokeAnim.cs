using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SmokeAnim : MonoBehaviour
{
    private VisualEffect smokeEffect;
    private float targetSpawnAmount;
    private Vector3 VelocityDirection;
    [SerializeField] private float transitionSpeed = 5.0f;
    private void Start()
    {
        smokeEffect = GetComponent<VisualEffect>();
        targetSpawnAmount = smokeEffect.GetFloat("SpawnAmount");

        EventHandler.SmokeHeavyInteractiveEvent += OnSmokeHeavyInteractiveEvent;
        EventHandler.SmokeExtinguishInteractiveEvent += OnSmokeExtinguishInteractiveEvent;
    }

    private void Update()
    {
        float currentSpawnAmount = smokeEffect.GetFloat("SpawnAmount");
        float newSpawnAmount = Mathf.Lerp(currentSpawnAmount, targetSpawnAmount, Time.deltaTime * transitionSpeed);
        smokeEffect.SetFloat("SpawnAmount", newSpawnAmount);
    }

    private void OnSmokeExtinguishInteractiveEvent(ItemName obj)
    {
        targetSpawnAmount = 0;
    }

    private void OnSmokeHeavyInteractiveEvent(ItemName obj)
    {
        targetSpawnAmount = 45;
        VelocityDirection = new Vector3(2f, 7.5f, 0f);
        if(smokeEffect != null) 
            smokeEffect.SetVector3("VelocityDirection", VelocityDirection);
    }
}

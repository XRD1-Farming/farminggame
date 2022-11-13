using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePour : MonoBehaviour
{
    private Transform watercanTransform;
    private Vector3 rotationVector;
    private ParticleSystem particle;

    private void Start()
    {
        watercanTransform = transform.parent;
        particle = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        Debug.Log(transform.parent.name);
        rotationVector = watercanTransform.rotation.eulerAngles;
        Debug.Log(rotationVector.x + "" + particle.isPlaying + "" + particle.isEmitting);
        if (rotationVector.x > 40f && rotationVector.x < 180f)
        {
            particle.enableEmission = true;
        }
        else
        {
            particle.enableEmission = false;
        }
        
    }
}

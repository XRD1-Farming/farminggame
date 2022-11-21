using System;
using System.Collections;
using System.Collections.Generic;
using Audio;
using UnityEngine;

public class Firelighter : MonoBehaviour
{
    public ParticleSystem collisionParticleSystem;
    private AudioManager _audioManager;
    private GameObject _gameObject;
    private Fireplace _fireplace;

    private void Start()
    {
        _gameObject = GameObject.Find("ParticleSystemFire");
        _fireplace = _gameObject.GetComponent<Fireplace>();
        _audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Firelighter"))
            StartCoroutine(Spark());
    }

    private IEnumerator Spark()
    {
        var em = collisionParticleSystem.emission;
        var dur = collisionParticleSystem.main.duration;
        em.enabled = true;
        _audioManager.Play("Stones");
        collisionParticleSystem.Play();
        _fireplace.onFire(true);
        _audioManager.Play("Fire");
        
        
        // maybe use dur?
        yield return new WaitForSeconds(dur);
        em.enabled = false;
        collisionParticleSystem.Stop();
    }
}


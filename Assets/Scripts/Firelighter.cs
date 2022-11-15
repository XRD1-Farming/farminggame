using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firelighter : MonoBehaviour
{
    public ParticleSystem collisionParticleSystem;

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
        collisionParticleSystem.Play();

        // maybe use dur?
        yield return new WaitForSeconds(dur);
        em.enabled = false;
        collisionParticleSystem.Stop();
    }

}

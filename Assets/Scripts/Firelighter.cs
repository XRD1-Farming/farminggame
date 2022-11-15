using System;
using System.Collections;
using System.Collections.Generic;
using Audio;
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
        FindObjectOfType<AudioManager>().Play("Stones");
        collisionParticleSystem.Play();
        
        // maybe use dur?
        yield return new WaitForSeconds(dur);
        em.enabled = false;
        collisionParticleSystem.Stop();
        
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log(other.tag);
        Debug.Log(other.name);
        if (other.gameObject.CompareTag("Fireplace"))
        { GameObject.Find("ParticleSystemFire").GetComponent<Fireplace>().onFire(true);
            FindObjectOfType<AudioManager>().Play("Fire");}
    }
}

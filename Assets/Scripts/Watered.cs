using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class Watered : MonoBehaviour
{
    private GameObject watered;
    

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log(other.name +" " + other.tag);
        if(other.CompareTag("Crop"))
        {
            Destroy(other);
        }

        // if (!other.CompareTag("Fireplace")) return;
        // Destroy(other);
        // GameObject.Find("ParticleSystemFire").GetComponent<Fireplace>().onFire(false);
    }
}

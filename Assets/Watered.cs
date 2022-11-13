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
        if(other.CompareTag("Crop"))
        {
            Destroy(other);
            
           //other.GetNamedChild("Watered").gameObject.SetActive(false);
           //Debug.Log("Crop: " + other.GetNamedChild("Watered").name);
        }
}
}

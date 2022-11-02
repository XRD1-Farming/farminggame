using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public GameObject blood;
    public GameObject food;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Chicken"))
        {
            
            Instantiate(blood,other.transform.position, other.transform.rotation);
            Instantiate(food, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
        }
    }
}
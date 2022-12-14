using System;
using System.Collections;
using System.Collections.Generic;
using Audio;
using Unity.VisualScripting;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public GameObject blood;
    public GameObject food;

    //tree
    public GameObject splinters;
    public GameObject wood;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Chicken"))
        {
            FindObjectOfType<AudioManager>().Play("DeadChicken");
            Instantiate(blood,other.transform.position, other.transform.rotation);
            Instantiate(food, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Tree"))
        {
            FindObjectOfType<AudioManager>().Play("Chop");
            Instantiate(splinters, other.transform.position, other.transform.rotation);
            Instantiate(wood, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
        }
    }
}
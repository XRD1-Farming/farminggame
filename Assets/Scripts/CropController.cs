using System;
using System.Collections;
using System.Collections.Generic;
using Audio;
using Unity.VisualScripting;
using UnityEngine;

public class CropController : MonoBehaviour
{
    public GameObject terrain, mud, watered, seeds, sprout, crop, harvest;
    public float sproutTime, cropDoneTime;
    

    // Start is called before the first frame update
    void Start()
    {
        terrain.SetActive(true);
        mud.SetActive(false);
        watered.SetActive(false);
        seeds.SetActive(false);
        sprout.SetActive(false);
        crop.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (seeds.activeSelf && watered.activeSelf)
            StartCoroutine(WaitForSprout());
    }

    private IEnumerator WaitForSprout()
    {
        yield return new WaitForSeconds(sproutTime);
        Sprout();
    }
    
    private IEnumerator WaitForCropDone()
    {
        yield return new WaitForSeconds(cropDoneTime);
        CropDone();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Shovel"))
            Till();
        if (other.gameObject.CompareTag("Seeds"))
            PlantSeeds();
        if (other.gameObject.CompareTag("Water"))
            Water();
        if (other.gameObject.CompareTag("Axe"))
            Harvested();
    }
    

    private void Till()
    {
        terrain.SetActive(false);
        mud.SetActive(true);
        FindObjectOfType<AudioManager>().Play("Shovel");
    }
    
    private void Water()
    {
        mud.SetActive(false);
        watered.SetActive(true);
        FindObjectOfType<AudioManager>().Play("Water");

    }

    private void PlantSeeds()
    {
        seeds.SetActive(true);
        FindObjectOfType<AudioManager>().Play("Seed");
    }

    private void Sprout()
    {
        seeds.SetActive(false);
        sprout.SetActive(true);
        StartCoroutine(WaitForCropDone());
    }

    private void CropDone()
    {
        sprout.SetActive(false);
        crop.SetActive(true);
       // FindObjectOfType<AudioManager>().Play("Done");

    }

    private void Harvested()
    {
        terrain.SetActive(true);
        mud.SetActive(false);
        watered.SetActive(false);
        seeds.SetActive(false);
        sprout.SetActive(false);
        crop.SetActive(false);
        Instantiate(harvest,crop.transform.position,crop.transform.rotation);
    }
}

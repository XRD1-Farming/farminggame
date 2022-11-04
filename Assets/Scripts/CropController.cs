using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropController : MonoBehaviour
{
    public GameObject terrain, mud, watered, seeds, sprout, crop;
    public float sproutTime;

    private bool repeat;
    // Start is called before the first frame update
    void Start()
    {
        repeat = true;
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
        /*if (!repeat) return;
        StartCoroutine(CropRepeat());
        repeat = false;*/
    }

    private IEnumerator WaitForSprout()
    {
        yield return new WaitForSeconds(sproutTime);
        Sprout();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Shovel"))
            Till();
        if (other.gameObject.CompareTag("Water"))
            Water();
        if (other.gameObject.CompareTag("Seeds"))
            PlantSeeds();
    }

    private IEnumerator CropRepeat()
    {
        Till();
        // process pre-yield
        yield return new WaitForSeconds( 5.0f );
        // process post-yield
        Water();
        yield return new WaitForSeconds( 5.0f );
        // process post-yield
        PlantSeeds();
        yield return new WaitForSeconds( 5.0f );
        // process post-yield
        Sprout();
        yield return new WaitForSeconds( 5.0f );
        // process post-yield
        CropDone();
        yield return new WaitForSeconds( 5.0f );
        terrain.SetActive(true);
        mud.SetActive(false);
        watered.SetActive(false);
        seeds.SetActive(false);
        sprout.SetActive(false);
        crop.SetActive(false);
        repeat = true;
        
    }

    private void Till()
    {
        terrain.SetActive(false);
        mud.SetActive(true);
    }
    
    private void Water()
    {
        mud.SetActive(false);
        watered.SetActive(true);
    }

    private void PlantSeeds()
    {
        seeds.SetActive(true);
    }

    private void Sprout()
    {
        seeds.SetActive(false);
        sprout.SetActive(true);
    }

    private void CropDone()
    {
        sprout.SetActive(false);
        crop.SetActive(true);
    }
}

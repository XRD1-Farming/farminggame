using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireplace : MonoBehaviour
{
    private ParticleSystem ps;
    private ParticleSystem.EmissionModule em;
    public Boolean fire;
    private GameObject _gameObject;
    private FriedChicken _friedChicken;

    private void Start()
    {
        _gameObject = GameObject.Find("SocketInteractorChicken");
        _friedChicken = _gameObject.GetComponent<FriedChicken>();
    }

    private void Awake()
    {
        ps = GetComponent<ParticleSystem>();
        em = ps.emission;
        em.enabled = false;
        fire = false;
    }

    private void Update()
    {
        if (fire)
        {
            em.enabled = true;
            _friedChicken.setOnFire();
        }
        else
        {
            em.enabled = false;
        }
    }

    

    public void onFire(Boolean boolean)
    {
        fire = boolean;
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireplace : MonoBehaviour
{
    private ParticleSystem ps;
    public Boolean fire;
    private void Awake()
    {
        ps = GetComponent<ParticleSystem>();
        ps.enableEmission = false;
        fire = false;
    }

    private void Update()
    {
        if (fire)
        {
            ps.enableEmission = true;
            GameObject.Find("SocketInteractorChicken").GetComponent<FriedChicken>().setOnFire();
        }
        else
        {
            ps.enableEmission = false;
        }
    }

    public void onFire(Boolean boolean)
    {
        fire = boolean;
    }

}

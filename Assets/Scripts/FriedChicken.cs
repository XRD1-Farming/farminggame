using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FriedChicken : MonoBehaviour
{
    XRSocketInteractor socket;
    private MeshRenderer[] children;
    public Material friedChickenMaterial;
    private Boolean onFire;


    void Start()
    {
        socket = GetComponent<XRSocketInteractor>();
    }

    private void Update()
    {
        IXRSelectInteractable obj = socket.GetOldestInteractableSelected();
        if (obj == null) return;
        if (!obj.transform.CompareTag("RawChicken") || !onFire) return;
        children = obj.transform.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer rend in children)
        {
            if (rend.name is "Cylinder.002" or "Cylinder.001") continue;
            var mats = new Material[rend.materials.Length];
            for (var i = 0; i < rend.materials.Length; i++)
            {
                mats[i] = friedChickenMaterial;
            }
            rend.materials = mats;

        }
    }

    public void setOnFire()
    {
        onFire = true;
    }


}

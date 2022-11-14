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
        Debug.Log(obj.transform.name);
        if (obj.transform.CompareTag("RawChicken") && onFire)
        {
            children = obj.transform.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer rend in children)
            {
                if(rend.name is not ("Cylinder.002" or "Cylinder.001"))
                {
                    var mats = new Material[rend.materials.Length];
                    for (var i = 0; i < rend.materials.Length; i++)
                    {
                        mats[i] = friedChickenMaterial;
                    }
                    rend.materials = mats;    
                }
                
            }
        }
    }

    public void setOnFire()
    {
        onFire = true;
    }


}

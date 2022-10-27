using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateTeleportationRay : MonoBehaviour
{
    public GameObject righTeleportation;

    public InputActionProperty rightActivate;  
    
    public InputActionProperty rightCancel; 

    // Update is called once per frame
    void Update()
    {
        righTeleportation.SetActive(rightCancel.action.ReadValue<float>() == 0 && rightActivate.action.ReadValue<float>() > 0.1f);
    }
}

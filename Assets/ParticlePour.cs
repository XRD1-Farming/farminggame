
using UnityEngine;

public class ParticlePour : MonoBehaviour
{
    private Transform watercanTransform;
    private Vector3 rotationVector;
    private ParticleSystem particle;
    private ParticleSystem.EmissionModule em;

    private void Start()
    {
        watercanTransform = transform.parent;
        particle = GetComponent<ParticleSystem>();
        em = particle.emission;
    }

    private void Update()
    {
        Debug.Log(transform.parent.name);
        rotationVector = watercanTransform.rotation.eulerAngles;
        Debug.Log(rotationVector.x + "" + particle.isPlaying + "" + particle.isEmitting);
        em.enabled = rotationVector.x is > 40f and < 180f;
        
    }
}

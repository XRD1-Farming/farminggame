using System.Collections;
using Audio;
using UnityEngine;


namespace EasyPrimitiveAnimals
{
    public class ChickenController : MonoBehaviour
    {
        
        private bool canPeck = true;
        private AudioManager _audioManager;


        private void Start()
        {
            _audioManager = FindObjectOfType<AudioManager>();
        }

        private void Update()
        {
            if (Random.Range(0, 100) > 50 && canPeck)
                {
                    StartCoroutine(TimeToPeck());
                }
                if (Random.Range(0, 100) > 80 && canPeck)
                {
                    _audioManager.Play("Bokbok");
                }
        }

        private IEnumerator TimeToPeck()
        {
            // Disable option to peck.
            canPeck = false;

            // Change X rotation to 45 degrees
            this.transform.eulerAngles = new Vector3(45f, transform.eulerAngles.y, transform.eulerAngles.z);

            // Wait...
            yield return new WaitForSeconds(0.2f);

            // Change X rotation to 0 degrees
            this.transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, transform.eulerAngles.z);

            yield return new WaitForSeconds(Random.Range(3f, 7f));

            // Enable option to peck.
            canPeck = true;
        }
    }
}

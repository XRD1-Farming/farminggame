using System.Collections;
using System.Collections.Generic;
using Audio;
using UnityEngine;

public class TreeGenerator : MonoBehaviour
{
    public GameObject treeObject;
    public GameObject treesInWorld;
    public int treeAmount;
    List<GameObject> treesList = new List<GameObject>();
    GameObject[] treesArray; 

    void Start()
    {
        for(int i = 0; i <= treeAmount; i++)
        {
            treesList.Add(Instantiate<GameObject>(treeObject));
            treesArray = treesList.ToArray();
            treesArray[i].transform.position = new Vector3(Random.Range(72, 127), 0, Random.Range(60, 130));
            treesArray[i].transform.parent = treesInWorld.transform;
            FindObjectOfType<AudioManager>().Play("Timber");
        }
    }


}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateManager : MonoBehaviour
{
    public List<GameObject> cratePositions;
    GridLayout gridLayout;
    public GameObject cratePrefab;

    // Start is called before the first frame update
    void Start()
    {
        gridLayout=GameObject.FindObjectOfType<GridLayout>();

        InstantiateCrates();
        
    }

    private void InstantiateCrates()
    {
       foreach (GameObject crate in cratePositions)
       {
           GameObject crateInstance=Instantiate(cratePrefab,crate.transform.position,Quaternion.identity,transform);
           

       }
    }

   
}

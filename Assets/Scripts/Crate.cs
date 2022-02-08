using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pushed(Vector3 position)
    {
        if(position.x>0)
        {
            //pushed to the right
            Debug.Log("pushed right");
        }
        else if(position.x<0)
        {
            //pushed to the left
             Debug.Log("pushed left");
        }
        else if(position.y>0)
        {
            //pushed up
             Debug.Log("pushed up");
        }
        else if(position.y<0)
        {
            //pushed down
             Debug.Log("pushed down");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //gravity to left
        if ()
        {
            Physics2D.gravity = new Vector2(Physics2D.gravity.y, 0);
        }
        //gravity to right
        if () 
        { 
            Physics2D.gravity = new Vector2(Physics2D.gravity.x, 0);
        }
    }
}

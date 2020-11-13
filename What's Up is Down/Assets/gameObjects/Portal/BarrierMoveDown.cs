using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrierMoveLeft : MonoBehaviour
{
    public float speed = 100;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(coinCounter.instance.coinScore == 3){
                Vector3 forward = new Vector3(1,0,0); //assumes increasing the x position moves forward
                float i = Input.GetAxis("Horizontal") * speed * Time.deltaTime; //assumes there's some global float called speed
                transform.Translate(forward * i, Space.World);
            }
    }
}

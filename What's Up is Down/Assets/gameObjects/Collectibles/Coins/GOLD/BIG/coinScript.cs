using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinScript : MonoBehaviour
{

    public int coinValue = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            coinCounter.instance.ChangeCoinScore(coinValue);
            Debug.Log("coinSCriptTest: Changed coin score");
            Destroy(this.gameObject);
            Debug.Log("coinScriptTest: Destroyed coin");
        }
    }
}

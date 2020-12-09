using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class musicScript : MonoBehaviour
{

    
    public static bool AudioBegin = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (!AudioBegin)
        {
            GetComponent<AudioSource>().Play();
            DontDestroyOnLoad(gameObject);
            AudioBegin = true;
        }

       
    }

    // Update is called once per frame
    void Update()
    {
        
                
        

    }
}

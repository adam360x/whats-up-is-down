using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class musicScript : MonoBehaviour
{
    static bool AudioBegin = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {

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
        Scene scene = SceneManager.GetActiveScene();
        
        if(scene.buildIndex == 0)
        {
            Debug.Log(scene.name);
            GetComponent<AudioSource>().Stop();
            AudioBegin = false;

        }
                
        

    }
}

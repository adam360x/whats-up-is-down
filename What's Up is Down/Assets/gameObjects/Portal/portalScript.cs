using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class portalScript : MonoBehaviour
{

    public TextMeshProUGUI portalText;
    public int numJewels;
    bool showText = false;
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(showText){
            count++;
            if(count == 300){
                portalText.text = "";
                count = 0;
                showText = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            if(jewelCounter.instance.jewelScore >= numJewels){
                SceneManager.LoadScene("Main_Menu");
            }
            else{
                showText = true;
                portalText.text = "You Need To Collect " + numJewels + " Jewels Before Entering The Portal!";
                
            }
        }
        
    }

    
}

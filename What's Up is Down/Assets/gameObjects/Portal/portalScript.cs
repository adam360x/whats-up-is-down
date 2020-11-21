using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class portalScript : MonoBehaviour
{

    public static portalScript instance;
    public TextMeshProUGUI portalText;
    public int numJewels;
    public string NextLvl;
    bool showText = false;
    float count = 0;
    public float messageTime;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
            Debug.Log("portalScriptTest: Instance assigned: " + instance);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(showText){
            count += Time.deltaTime;
            if(count >= messageTime){
                portalText.text = "";
                count = 0;
                showText = false;
                Debug.Log("portalScriptTest: showText is now: " + showText);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            if(jewelCounter.instance.jewelScore >= numJewels){
                Debug.Log("portalScriptTest: Next Scene");
                SceneManager.LoadScene(NextLvl);
            }
            else{
                showText = true;
                portalText.text = "You Need To Collect " + numJewels + " Jewels Before Entering The Portal!";
                Debug.Log("portalScriptTest: showText is now: " + showText);
                
            }
        }
        
    }

    
}

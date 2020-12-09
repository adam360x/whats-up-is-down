using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class post8 : MonoBehaviour
{
    public static post8 instance;
    public TextMeshProUGUI post8Text;
    bool showText = false;
    float count = 0;
    public float messageTime;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            Debug.Log("post8Test: Instance assigned: " + instance);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (showText)
        {
            count += Time.deltaTime;
            if (count >= messageTime)
            {
                post8Text.text = "";
                count = 0;
                showText = false;
                Debug.Log("post8Test: showText is now: " + showText);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            showText = true;
            post8Text.text = "Enter Portal To Proceed!";
            Debug.Log("post8Test: showText is now: " + showText);

        }

    }
}

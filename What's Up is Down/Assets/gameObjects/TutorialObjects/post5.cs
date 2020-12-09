using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class post5 : MonoBehaviour
{
    public static post5 instance;
    public TextMeshProUGUI post5Text;
    bool showText = false;
    float count = 0;
    public float messageTime;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            Debug.Log("post5Test: Instance assigned: " + instance);
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
                post5Text.text = "";
                count = 0;
                showText = false;
                Debug.Log("post5Test: showText is now: " + showText);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            count = 0;
            showText = true;
            post5Text.text = "Rotate World Here! Keep in mind there are limited number of rotates per level.";
            Debug.Log("post5Test: showText is now: " + showText);

        }

    }
}

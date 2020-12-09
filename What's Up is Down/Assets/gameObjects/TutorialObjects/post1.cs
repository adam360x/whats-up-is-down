using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class post1 : MonoBehaviour
{
    public static post1 instance;
    public TextMeshProUGUI post1Text;
    bool showText = false;
    float count = 0;
    public float messageTime;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            Debug.Log("post1Test: Instance assigned: " + instance);
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
                post1Text.text = "";
                count = 0;
                showText = false;
                Debug.Log("post1Test: showText is now: " + showText);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            showText = true;
            post1Text.text = "Welcome to What's Up Is Down!";
            Debug.Log("post1Test: showText is now: " + showText);

        }

    }
}

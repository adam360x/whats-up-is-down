using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class post4 : MonoBehaviour
{
    public static post4 instance;
    public TextMeshProUGUI post4Text;
    bool showText = false;
    float count = 0;
    public float messageTime;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            Debug.Log("post4Test: Instance assigned: " + instance);
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
                post4Text.text = "";
                count = 0;
                showText = false;
                Debug.Log("post4Test: showText is now: " + showText);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            showText = true;
            post4Text.text = "Collect Challenge Coins!";
            Debug.Log("post4Test: showText is now: " + showText);

        }

    }
}

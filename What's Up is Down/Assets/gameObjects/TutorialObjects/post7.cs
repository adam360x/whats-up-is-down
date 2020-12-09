﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class post7 : MonoBehaviour
{
    public static post7 instance;
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
            Debug.Log("post7Test: Instance assigned: " + instance);
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
                Debug.Log("post7Test: showText is now: " + showText);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            count = 0;
            showText = true;
            post1Text.text = "Touch Platform To Rotate!";
            Debug.Log("post7Test: showText is now: " + showText);

        }

    }
}

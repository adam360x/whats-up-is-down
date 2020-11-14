﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class jewelCounter : MonoBehaviour
{

    public static jewelCounter instance;
    public TextMeshProUGUI jewelText;
    public int jewelScore;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null){
            instance = this;
        }
    }

    public void ChangeJewelScore(int jewelValue)
    {
        jewelScore += jewelValue;
        jewelText.text = jewelScore.ToString() + "/" + portalScript.instance.numJewels;
    }
}
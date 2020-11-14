using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class coinCounter : MonoBehaviour
{

    public static coinCounter instance;
    public TextMeshProUGUI coinText;
    public int coinScore;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null){
            instance = this;
        }
    }

    public void ChangeCoinScore(int coinValue){
        coinScore += coinValue;
        coinText.text = "X"+coinScore.ToString();
    }
}

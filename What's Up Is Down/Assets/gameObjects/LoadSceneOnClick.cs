using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadSceneOnClick : MonoBehaviour
{

    public string lvlName;
    public void LoadScene()
    {
        SceneManager.LoadScene(lvlName);
        Debug.Log("LoadSceneOnClickTest: scene " + lvlName);
    }
}

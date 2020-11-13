using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadSceneOnClick : MonoBehaviour
{

    public int buildIndex;
    public void LoadScene()
    {
        SceneManager.LoadScene(buildIndex);
    }
}

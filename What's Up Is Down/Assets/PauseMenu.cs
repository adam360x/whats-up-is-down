using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public static bool IsPaused = false;

    // Update is called once per frame
    public void pauseGame()
    {
        if (IsPaused)
        {
            Time.timeScale = 1;
            IsPaused = false;

        } else
        {
            Time.timeScale = 0;
            IsPaused = true;
        }
    }

    public void resetLevel()
    {
        if (IsPaused)
        {
            Time.timeScale = 1;
            IsPaused = false;

        } else
        {
            Time.timeScale = 0;
            IsPaused = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
 public void ReplayLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void QuitGame()
    {
        SceneManager.LoadScene("main");
    }
}

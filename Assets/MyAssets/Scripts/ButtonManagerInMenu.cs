using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagerInMenu : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("BehindScene");
    }
   
    public void QuitGame()
    {
        #if UNITY_EDITOR
      
        UnityEditor.EditorApplication.isPlaying = false;
        #else
       
        Application.Quit();
        #endif
    }
}

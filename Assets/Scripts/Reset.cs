using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{

    public GameObject Part1;
    public GameObject Part2;

    public static string lastScene ="";
    // Start is called before the first frame update
    public void resetLastScene()
    {  
        if(lastScene.Length == 0){
            resetToMenu();
        }else{
            UnityEngine.SceneManagement.SceneManager.LoadScene(lastScene);
        }
    }

    public void resetToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void next()
    {
        Part2.SetActive(true);
        Part1.SetActive(false);
    }
}

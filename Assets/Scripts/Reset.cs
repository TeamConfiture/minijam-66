using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public static string lastScene;
    // Start is called before the first frame update
    public void resetLastScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(lastScene);
    }
}

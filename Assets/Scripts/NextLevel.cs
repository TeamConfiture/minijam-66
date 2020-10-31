using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public GameObject canvas;
    private bool isShowing;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("test");
            isShowing = !isShowing;
            canvas.SetActive(isShowing);
        }
    }
}

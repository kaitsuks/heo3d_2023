using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustExit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        
    }

    public void ExitApp()
    {
        Debug.Log("QUITTING APPLICATION");
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

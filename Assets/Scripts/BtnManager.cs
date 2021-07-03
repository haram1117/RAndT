using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnManager : MonoBehaviour
{
    public GameObject Startpanel;
    public GameObject Playpanel;

    public void StartBtn()
    {
        Startpanel.SetActive(false);
        Playpanel.SetActive(true);
    }

    public void ExitBtn()
    { 
        Application.Quit();
  
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

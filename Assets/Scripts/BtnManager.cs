using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnManager : MonoBehaviour
{
    public GameObject Startpanel;
    public GameObject Playpanel;
    public AudioClip Opening;
    public AudioClip Scene1;
    GameObject GM;
    public void StartBtn()
    {
        Startpanel.SetActive(false);
        Playpanel.SetActive(true);
        GM.GetComponent<AudioSource>().clip = Scene1;
        GM.GetComponent<AudioSource>().Play();
    }

    public void ExitBtn()
    { 
        Application.Quit();
    }
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager");
        GM.GetComponent<AudioSource>().clip = Opening;
        GM.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

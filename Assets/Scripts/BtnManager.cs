using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnManager : MonoBehaviour
{
    public GameObject Startpanel;
    public GameObject Playpanel;
    public GameObject Menupanel;
    public GameObject Infopanel;
    public GameObject Scorepanel;
    public AudioClip Opening;
    public AudioClip Scene1;
    public bool StartBtnClick=false;
    GameObject GM;
    public void StartBtn()
    {
        Startpanel.SetActive(false);
        Playpanel.SetActive(true);
        if(SceneManager.GetActiveScene().name == "SampleScene")
        {
            GM.GetComponent<AudioSource>().clip = Scene1;
            GM.GetComponent<AudioSource>().Play();
        }
        StartBtnClick = true;
    }

    public void ExitBtn()
    { 
        Application.Quit();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (Startpanel.activeSelf && SceneManager.GetActiveScene().name == "SampleScene")
        {
            GM = GameObject.Find("GameManager");
            GM.GetComponent<AudioSource>().clip = Opening;
            GM.GetComponent<AudioSource>().Play();
        }
        else
        {
            StartBtnClick = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!Menupanel.activeSelf && !Scorepanel.activeSelf)
        {
            Debug.Log("들어왔어");
            escMenu();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && Menupanel.activeSelf)
        {
            resume();
        }
    }

    void escMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&& !Menupanel.activeSelf)
        {
            Playpanel.SetActive(false);
            Menupanel.SetActive(true);
            Infopanel.SetActive(false);
            Startpanel.SetActive(false);
        }
    }

    public void resume()
    {
        if (StartBtnClick)
        {
            Menupanel.SetActive(false);
            Playpanel.SetActive(true);
        }
        else
        {
            Debug.Log("여기냐");
            Menupanel.SetActive(false);
            Startpanel.SetActive(true);
        }

    }

    public void InfoMenu()
    {
        Infopanel.SetActive(true);
        Menupanel.SetActive(false);
    }

    public void startMenu()
    {
        Startpanel.SetActive(true);
        Menupanel.SetActive(false);
        StartBtnClick = false;
    }

    public void SetOriginal()
    {
        SceneManager.LoadScene(0);
    }

}

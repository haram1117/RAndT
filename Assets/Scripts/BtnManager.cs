using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BtnManager : MonoBehaviour
{
    public GameObject Startpanel;
    public GameObject Playpanel;
    public GameObject Menupanel;
    public GameObject Infopanel;
    public GameObject Scorepanel;
    public GameObject fadeoutpanel;
    public GameObject fadeoutcanvas;

    private GameObject MS;
    public AudioClip Opening;
    public AudioClip Scene1;
    public AudioClip Scene2;
    public AudioClip Scene3;
    public Image tryagain_btn_onclick;
    public bool StartBtnClick=false;
    public GameObject CountPage;
    public GameObject countimg;
    public Sprite one;
    public Sprite two;
    public Sprite three;
    public Sprite go;
    private float sec = 0;
    public bool isStarted = false;
    public AudioClip Count_AudioClip;

    private bool first = false;
    private bool second = false;
    private bool third = false;
    private bool fourth = false;

    private bool checkbool = false;
    private Color color;
    GameObject GM;

    public void StartBtn()
    {
        Startpanel.SetActive(false);
        CountPage.SetActive(true);
    }
    public void PlayStart()
    {
        Playpanel.SetActive(true);
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            MS.GetComponent<AudioSource>().clip = Scene1;
            MS.GetComponent<AudioSource>().Play();
        }
        else if(SceneManager.GetActiveScene().name == "summer")
        {
            MS.GetComponent<AudioSource>().clip = Scene2;
            MS.GetComponent<AudioSource>().Play();
        }
        else if (SceneManager.GetActiveScene().name == "winter")
        {
            MS.GetComponent<AudioSource>().clip = Scene3;
            MS.GetComponent<AudioSource>().Play();
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
            MS = GameObject.Find("MainScene");
            MS.GetComponent<AudioSource>().clip = Opening;
            MS.GetComponent<AudioSource>().Play();
        }
        else
        {
            StartBtnClick = true;
        }
        if(SceneManager.GetActiveScene().name == "winter" || SceneManager.GetActiveScene().name == "summer")
        {
            MS = GameObject.Find("MainScene");
            GM = GameObject.Find("GameManager");
            fadeoutpanel.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!Menupanel.activeSelf && !Scorepanel.activeSelf)
        {
            escMenu();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && Menupanel.activeSelf)
        {
            resume();
        }
        if (CountPage.activeSelf)
        {
            countimg.GetComponent<Image>().SetNativeSize();
            sec += Time.deltaTime;
            if((int)sec == 0)
            {
                if (!first)
                {
                    Debug.Log("1");
                    GM.GetComponent<AudioSource>().clip = Count_AudioClip;
                    GM.GetComponent<AudioSource>().Play();
                    first = true;
                }
            }
            if((int)sec == 1)
            {
                if (!second)
                {
                    countimg.GetComponent<Image>().sprite = two;
                    GM.GetComponent<AudioSource>().clip = Count_AudioClip;
                    GM.GetComponent<AudioSource>().Play();
                    second = true;
                }
            }
            else if((int)sec == 2)
            {
                if (!third)
                {
                    countimg.GetComponent<Image>().sprite = one;
                    GM.GetComponent<AudioSource>().clip = Count_AudioClip;
                    GM.GetComponent<AudioSource>().Play();
                    third = true;
                }
            }
            else if((int)sec == 3)
            {
                if (!fourth)
                {
                    countimg.GetComponent<Image>().sprite = go;
                    GM.GetComponent<AudioSource>().clip = Count_AudioClip;
                    GM.GetComponent<AudioSource>().Play();
                    isStarted = true;
                    PlayStart();
                    fourth = true;
                }
            }
            else if((int)sec == 4)
            {
                CountPage.SetActive(false);
            }
        }
        if (fadeoutpanel.activeSelf && checkbool)
        {
            color = fadeoutcanvas.GetComponent<Image>().color;
            color.a += Time.deltaTime * 0.5f;
            fadeoutcanvas.GetComponent<Image>().color = color;
            Debug.Log(color.a);
            if (color.a >= 1)
            {
                Debug.Log(checkbool);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        if (fadeoutpanel.activeSelf && !checkbool)
        {
            color = fadeoutcanvas.GetComponent<Image>().color;
            color.a -= Time.deltaTime * 0.5f;
            fadeoutcanvas.GetComponent<Image>().color = color;
            Debug.Log(color.a);
            if (color.a <= 0)
            {
                CountPage.SetActive(true);
                fadeoutpanel.SetActive(false);
            }
        }

    }

    void escMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&& !Menupanel.activeSelf && !CountPage.activeSelf)
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

    public void reloadscene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void levelup()
    {
        fadeoutpanel.SetActive(true);
        checkbool = true;
    }

}

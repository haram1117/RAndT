using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private GameObject player_runner;
    private bool play_start = false;
    private bool play_end = false;
    private float jumpForce = 500.0f;
    private bool waterdrop_trigger = false;
    private float timeCount = 0;
    public AudioClip dashAudioClip;
    public AudioClip JumpAudioClip;
    public bool isDead = false;
    private GameObject Startpanel;
    public GameObject ScoreContainer;
    public GameObject Scorepanel;
    public GameObject Playpanel;
    public GameObject Menupanel;
    public GameObject Clearpanel;
    public AudioClip ClearAudio;
    BtnManager startmanager;
    public GameObject effect;

    public Text Score;

    GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        player_runner = GameObject.Find("turtle");
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        Startpanel = GameObject.Find("StartPage");
        startmanager = GameObject.Find("BtnManager").GetComponent<BtnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (play_end)
        {
            player_runner.GetComponentInChildren<Animator>().SetBool("game_end", true);
        }
        else
        {
            player_runner.GetComponentInChildren<Animator>().SetInteger("player_velocity", (int)player_runner.GetComponent<Rigidbody2D>().velocity.y);
            if (play_start && !play_end && Playpanel.activeSelf)
            {
                Player_Move();
                Player_Jump();
                Player_Death();
                play_end = GM.play_end;
            }
            else if(SceneManager.GetActiveScene().name == "SampleScene")
            {
                if (GameObject.Find("BtnManager").GetComponent<BtnManager>().StartBtnClick && !Menupanel.activeSelf)
                {
                    if (startmanager.isStarted)
                    {
                        play_start = true;
                    }
                        
                }
            }

            else if (SceneManager.GetActiveScene().name == "winter" || SceneManager.GetActiveScene().name == "summer")
            {
                if (!Menupanel.activeSelf)
                {
                    if (startmanager.isStarted)
                    {
                        play_start = true;
                    }
                }

            }
        }
        //Player_Respawn();
   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "waterDrop")
        {
            waterdrop_trigger = true;
            player_runner.GetComponent<AudioSource>().clip = dashAudioClip;
            player_runner.GetComponent<AudioSource>().Play();
            Destroy(collision.gameObject);
            effect.GetComponent<ParticleSystem>().Play();
        }
        else if (collision.gameObject.tag == "FinishFlag")
        {
            Playpanel.SetActive(false);
            Clearpanel.SetActive(true);
            GM.play_end = true;
            play_end = true;
            GM.GetComponent<AudioSource>().clip = ClearAudio;
            GM.GetComponent<AudioSource>().Play();
        }
        else if (collision.gameObject.tag == "Flag")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    void Player_Move()
    {
        player_runner.GetComponentInChildren<Animator>().SetBool("running", true);
        if (waterdrop_trigger)
        {
            timeCount += Time.deltaTime;
            if (timeCount <= 1)
            {
                player_runner.transform.position += Vector3.right * 3f * Time.deltaTime;
                player_runner.GetComponentInChildren<Animator>().SetFloat("animation_speed", 4f);
                player_runner.GetComponentInChildren<Animator>().SetBool("runfast", true);
            }
            else
            {
                player_runner.GetComponentInChildren<Animator>().SetBool("runfast", false);
                waterdrop_trigger = false;
                timeCount = 0;
            }
        }
        else
        {
            player_runner.transform.position += Vector3.right * 0.2f * Time.deltaTime;
            player_runner.GetComponentInChildren<Animator>().SetFloat("animation_speed", 2f);
        }
        //player_runner.transform.position += Vector3.right * 0.7f * speedbytime;
        //player_runner.transform.position += Vector3.right * 0.75f * Time.deltaTime;
        //player_runner.GetComponentInChildren<Animator>().SetFloat("animation_speed", 3f);
       
    }
    void Player_Jump()
    {
        if(player_runner.GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                player_runner.GetComponent<Rigidbody2D>().AddForce(transform.up * jumpForce);
                player_runner.GetComponent<AudioSource>().clip = JumpAudioClip;
                player_runner.GetComponent<AudioSource>().Play();
            }
        }
    }
    public void Player_Death()
    {
        //if (player_runner.transform.position.y < -10)
        //{
        //    Playpanel.SetActive(false);
        //    ScoreContainer.SetActive(true);
        //    Scorepanel.SetActive(true);
        //    isDead = true;
        //    play_end = true;
        //    Score.text = GameObject.Find("GameManager").GetComponent<GameManager>().play_time.text;
        //    Destroy(player_runner);
        //}
        //else if(isDead)
        //{
        //    Debug.Log("°ÅºÏÀÌ Á×À½");
        //    //Playpanel.SetActive(false);
        //    //Scorepanel.SetActive(true);
        //    //isDead = true;
        //    //play_end = true;
        //}
    }
}

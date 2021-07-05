using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rabbit : MonoBehaviour
{
    private GameObject player_rabbit;
    public bool play_start = false;
    private bool play_end = false;
    private bool carrot_trigger = false;
    private float jumpForce = 500.0f;
    private float timeCount = 0;
    public AudioClip dashAudioClip;
    public AudioClip JumpAudioClip;
    private GameObject Startpanel;
    public bool isDead = false;
    GameManager GM;
    public GameObject ScoreContainer;
    public GameObject Scorepanel;
    public GameObject Playpanel;
    public GameObject Menupanel;
    BtnManager startmanager;
    public GameObject effect;
    // Start is called before the first frame update
    void Start()
    {
        player_rabbit = GameObject.Find("rabbit");
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        Startpanel = GameObject.Find("StartPage");
        startmanager = GameObject.Find("BtnManager").GetComponent<BtnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (play_end)
        {
            player_rabbit.GetComponentInChildren<Animator>().SetBool("game_end", true);
        }
        else
        {
            player_rabbit.GetComponentInChildren<Animator>().SetInteger("player_velocity", (int)player_rabbit.GetComponent<Rigidbody2D>().velocity.y);
            if (play_start && !play_end && Playpanel.activeSelf)
            {
                Player_Move();
                Player_Jump();
                Player_Death();
                play_end = GM.play_end;
            }
            else if (SceneManager.GetActiveScene().name == "SampleScene")
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

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "carrot")
        {
            carrot_trigger = true;
            player_rabbit.GetComponent<AudioSource>().clip = dashAudioClip;
            player_rabbit.GetComponent<AudioSource>().Play();
            Destroy(collision.gameObject);
            effect.GetComponent<ParticleSystem>().Play();
        }
        else if(collision.gameObject.tag == "FinishFlag")
        {
            Debug.Log("Finish");
            GameObject.Find("turtle").GetComponent<Player>().Player_Death();
            GameObject.Find("turtle").GetComponent<Player>().isDead = true;
            GM.play_end = true;
        }
        else if(collision.gameObject.tag == "Flag")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }

    void Player_Move()
    {
        player_rabbit.GetComponentInChildren<Animator>().SetBool("running", true);
        //player_rabbit.transform.position += Vector3.right * 0.05f * Time.deltaTime;
        if (carrot_trigger)
        {
            timeCount += Time.deltaTime;
            if(timeCount <= 1)
            {
                player_rabbit.transform.position += Vector3.right * 3f * Time.deltaTime;
                player_rabbit.GetComponentInChildren<Animator>().SetFloat("animation_speed", 4f);
                player_rabbit.GetComponentInChildren<Animator>().SetBool("runfast", true);
            }
            else
            {
                player_rabbit.GetComponentInChildren<Animator>().SetBool("runfast", false);
                carrot_trigger = false;
                timeCount = 0;
            }
        }
        else
        {
            player_rabbit.transform.position += Vector3.right * 0.2f * Time.deltaTime;
            player_rabbit.GetComponentInChildren<Animator>().SetFloat("animation_speed", 2f);
        }
    }
    void Player_Jump()
    {
        if (player_rabbit.GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                player_rabbit.GetComponent<Rigidbody2D>().AddForce(transform.up * jumpForce);
                player_rabbit.GetComponent<AudioSource>().clip = JumpAudioClip;
                player_rabbit.GetComponent<AudioSource>().Play();
            }
        }
    }
    public void Player_Death()
    {
        if (player_rabbit.transform.position.y < -10)
        {

            Playpanel.SetActive(false);
            ScoreContainer.SetActive(true);
            Scorepanel.SetActive(true);
            isDead = true;
            play_end = true;
            Destroy(player_rabbit);
        }
    }
}

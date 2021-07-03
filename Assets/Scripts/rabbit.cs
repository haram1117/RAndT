using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rabbit : MonoBehaviour
{
    private GameObject player_rabbit;
    public bool play_start = false;
    private bool carrot_trigger = false;
    private float jumpForce = 500.0f;
    private float timeCount = 0;
    public AudioClip dashAudioClip;
    private bool isGroundWater = false;
    // Start is called before the first frame update
    void Start()
    {
        player_rabbit = GameObject.Find("rabbit");
    }

    // Update is called once per frame
    void Update()
    {
        player_rabbit.GetComponentInChildren<Animator>().SetInteger("player_velocity", (int)player_rabbit.GetComponent<Rigidbody2D>().velocity.y);
        if (play_start)
        {
            Player_Move();
            Player_Jump();
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
                play_start = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "carrot")
        {
            carrot_trigger = true;
            Destroy(collision.gameObject);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "waterGround")
        {
            isGroundWater = false;
        }  
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "waterGround")
            isGroundWater = true;
    }

    void Player_Move()
    {
        player_rabbit.GetComponentInChildren<Animator>().SetBool("running", true);
        player_rabbit.transform.position += Vector3.right * 0.05f * Time.deltaTime;
        if (carrot_trigger)
        {
            timeCount += Time.deltaTime;
            if(timeCount <= 1)
            {
                player_rabbit.GetComponent<AudioSource>().clip = dashAudioClip;
                player_rabbit.GetComponent<AudioSource>().Play();
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
            }
        }
    }
}

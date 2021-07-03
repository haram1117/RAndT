using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject player_runner;
    private bool play_start = false;
    private float jumpForce = 500.0f;
    private float speedbytime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        player_runner = GameObject.Find("turtle");
    }

    // Update is called once per frame
    void Update()
    {
        //speedbytime += Time.deltaTime;
        player_runner.GetComponentInChildren<Animator>().SetInteger("player_velocity", (int)player_runner.GetComponent<Rigidbody2D>().velocity.y);
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
        //Player_Respawn();
    }
    void Player_Move()
    {
        player_runner.GetComponentInChildren<Animator>().SetBool("running", true);
        //player_runner.transform.position += Vector3.right * 0.7f * speedbytime;
        player_runner.transform.position += Vector3.right * 0.75f * Time.deltaTime;
        player_runner.GetComponentInChildren<Animator>().SetFloat("animation_speed", 3f);
       
    }
    void Player_Jump()
    {
        if(player_runner.GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                player_runner.GetComponent<Rigidbody2D>().AddForce(transform.up * jumpForce);
            }
        }
    }
}

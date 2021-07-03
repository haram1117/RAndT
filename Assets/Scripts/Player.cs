using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject player_runner;
    private bool play_start = false;
    private float jumpForce = 500.0f;
    bool isGroundWater = false;
    // Start is called before the first frame update
    void Start()
    {
        player_runner = GameObject.Find("turtle");
    }

    // Update is called once per frame
    void Update()
    {
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
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "waterGround")
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
        player_runner.GetComponentInChildren<Animator>().SetBool("running", true);
        if (isGroundWater)
        {
            player_runner.transform.position += Vector3.right * 0.75f * Time.deltaTime;
            player_runner.GetComponentInChildren<Animator>().SetFloat("animation_speed", 3f);
        }
        else
        {
            player_runner.transform.position += Vector3.right * 0.05f * Time.deltaTime;
            player_runner.GetComponentInChildren<Animator>().SetFloat("animation_speed", 1f);
        }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject player_runner;
    private Transform grid_transform;
    public float moveSpeed = 6.0f;
    private bool play_start = false;
    private float jumpForce = 500.0f;
    // Start is called before the first frame update
    void Start()
    {
        player_runner = GameObject.Find("turtle");
        grid_transform = GameObject.Find("Grid").GetComponent<Transform>();
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
    void Player_Move()
    {
        player_runner.GetComponentInChildren<Animator>().SetBool("running", true);
        //Vector3 moveVelocity = Vector3.zero;
        //if (Input.GetAxisRaw("Horizontal") < 0)
        //{
        //    moveVelocity = Vector3.left;
        //    player_runner.GetComponent<SpriteRenderer>().flipX = true;
        //}
        //else if (Input.GetAxisRaw("Horizontal") > 0)
        //{
        //    moveVelocity = Vector3.right;
        //    player_runner.GetComponent<SpriteRenderer>().flipX = false;
        //}
        //else
        //{
        //    player_runner.GetComponentInChildren<Animator>().SetBool("running", false);
        //}
        //player_runner.transform.position += moveVelocity * moveSpeed * Time.deltaTime;
        grid_transform.position -= Vector3.right * moveSpeed * Time.deltaTime * 0.5f;
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
    //void Player_Respawn()
    //{
    //    if (player_runner.GetComponent<Transform>().position.y < -6)
    //    {
    //        player_runner.transform.SetPositionAndRotation(new Vector3(player_runner.transform.position.x - 1, 0, player_runner.transform.position.z), player_runner.transform.rotation);
    //        grid_transform.SetPositionAndRotation(new Vector3(grid_transform.position.x +2, grid_transform.position.y, grid_transform.position.z), grid_transform.rotation);
    //    }
    //}
}

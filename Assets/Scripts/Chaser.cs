using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    private GameObject player_chaser;
    
    // Start is called before the first frame update
    void Start()
    {
        player_chaser = GameObject.Find("Chaser");
    }

    // Update is called once per frame
    void Update()
    {
        player_chaser.GetComponentInChildren<Animator>().SetInteger("chaser_velocity", (int)player_chaser.GetComponent<Rigidbody2D>().velocity.y);
        Player_Move();
    }

    void Player_Move()
    {
        player_chaser.GetComponentInChildren<Animator>().SetBool("running", true);
        player_chaser.transform.position += Vector3.right * 0.05f * Time.deltaTime;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroll : MonoBehaviour
{
    private bool scroll_start = false;
    private Transform grid_transform;
    public float moveSpeed = 6.0f;
    rabbit gamemanager;
    GameManager gm;
    private bool game_end = false;
    // Start is called before the first frame update
    void Start()
    {
        grid_transform = GameObject.Find("Grid").GetComponent<Transform>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scroll_start && !game_end)
        {
            GroundMove();
            game_end = gm.play_end;
        }
        else if(!game_end)
        {
            gamemanager = GameObject.Find("rabbit").GetComponent<rabbit>();
            scroll_start = gamemanager.play_start;
        }
    }
    void GroundMove()
    {
        grid_transform.position -= Vector3.right * moveSpeed * Time.deltaTime*1.7f;
    }
}

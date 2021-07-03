using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroll : MonoBehaviour
{
    private bool scroll_start = false;
    private Transform grid_transform;
    public float moveSpeed = 6.0f;
    rabbit gamemanager;
    // Start is called before the first frame update
    void Start()
    {
        grid_transform = GameObject.Find("Grid").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scroll_start)
        {
            GroundMove();
        }
        else
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

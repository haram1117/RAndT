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
    private float speed = 1.5f;
    public GameObject Playpanel;
    public GameObject ScorePanel;
    private Transform camera_transform;
    private Transform bg_transform;
    private Transform rabbit_t;
    private Transform turtle_t;
    // Start is called before the first frame update
    void Start()
    {
        grid_transform = GameObject.Find("Grid").GetComponent<Transform>();
        camera_transform = GameObject.Find("MainScene").GetComponent<Transform>();
        bg_transform = GameObject.Find("Background").GetComponent<Transform>();
        rabbit_t = GameObject.Find("rabbit").GetComponent<Transform>();
        turtle_t = GameObject.Find("turtle").GetComponent<Transform>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scroll_start && !game_end && Playpanel.activeSelf)
        {
            speed += 0.0007f;
            GroundMove();
            CameraMove();
        }
        else if (!game_end && !ScorePanel.activeSelf)
        {
            gamemanager = GameObject.Find("rabbit").GetComponent<rabbit>();
            scroll_start = gamemanager.play_start;
        }
        game_end = gm.play_end;
    }
    void GroundMove()
    {
        grid_transform.position -= Vector3.right * moveSpeed * Time.deltaTime * speed;
    }
    void CameraMove()
    {
        if (rabbit_t.transform.position.x > 0)
        {
            camera_transform.position = Vector3.Lerp(camera_transform.position,new Vector3((rabbit_t.position.x + turtle_t.position.x) / 2, camera_transform.position.y, camera_transform.position.z), Time.deltaTime);
            bg_transform.position = Vector3.Lerp(bg_transform.position, new Vector3((rabbit_t.position.x + turtle_t.position.x) / 2, camera_transform.position.y, bg_transform.position.z), Time.deltaTime);
        }
    }
}
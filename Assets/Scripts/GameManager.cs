using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text play_time;
    private bool play_start = false;
    public bool play_end = false;
    private float total_play_time;
    private string winner;
    rabbit rabbit_;
    Player turtle_;
    private bool turtledead = false;
    private bool rabbitdead = false;

    // Start is called before the first frame update
    void Start()
    {
        total_play_time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (play_start)
        {
            total_play_time += Time.deltaTime;
            play_time.text = Mathf.Round(total_play_time).ToString();
            turtledead = turtle_.isDead;
            rabbitdead = rabbit_.isDead;
            if(rabbitdead)
            {
                play_start = false;
                IsPlayerDead("rabbit");
            }
            if (turtledead)
            {
                play_start = false;
                IsPlayerDead("turtle");
            }
        }
        else if(!turtledead && !rabbitdead)
        {
            turtle_ = GameObject.Find("turtle").GetComponent<Player>();
            rabbit_ = GameObject.Find("rabbit").GetComponent<rabbit>();
            play_start = rabbit_.play_start;
        }
    }
    void IsPlayerDead(string obj)
    {
        if (obj == "rabbit")
        {
            Debug.Log("Turtle WIN");
            winner = "turtle";
            play_end = true;
        }
        else
        {
            Debug.Log("Rabbit WIN");
            winner = "rabbit";
            play_end = true;
        }
    }
}

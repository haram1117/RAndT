using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text play_time;
    private bool play_start = false;
    private float total_play_time;
    rabbit gamestart;
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
        }
        else
        {
            gamestart = GameObject.Find("rabbit").GetComponent<rabbit>();
            play_start = gamestart.play_start;
        }
    }
}

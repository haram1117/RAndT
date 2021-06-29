using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text play_time;
    private float total_play_time;
    // Start is called before the first frame update
    void Start()
    {
        total_play_time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        total_play_time += Time.deltaTime;
        play_time.text = Mathf.Round(total_play_time).ToString();
    }
}

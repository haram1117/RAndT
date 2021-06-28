using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player_runner;
    // Start is called before the first frame update
    void Start()
    {
        this.player_runner = GameObject.Find("Runner");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = this.player_runner.transform.position;
        transform.position = new Vector3(playerPos.x, transform.position.y, transform.position.z);
    }
}

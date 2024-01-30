using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        centerPlayer();   
    }

    private void centerPlayer ()
    {
        transform.position = player.transform.position + new Vector3(0, 0, -10);
    }
}

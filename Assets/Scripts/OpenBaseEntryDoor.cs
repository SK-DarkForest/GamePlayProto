using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBaseEntryDoor : MonoBehaviour
{
    //private GameObject player;
    private EdgeCollider2D edgeCollider;
    private PolygonCollider2D polygonCollider;
    public bool isOpen;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        edgeCollider = GetComponent<EdgeCollider2D>();
        polygonCollider = GetComponent<PolygonCollider2D>();
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OpenDoor ()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isOpen)
        {
            edgeCollider.enabled = true;
            polygonCollider.enabled = false;
            isOpen = true;
        } 
        else if (Input.GetKeyDown(KeyCode.E) && isOpen)
        {
            edgeCollider.enabled = false;
            polygonCollider.enabled = true;
            isOpen = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class BaseEntry : MonoBehaviour
{
    //private GameObject player;
    private EdgeCollider2D edgeCollider;
    private PolygonCollider2D polygonCollider;
    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public GameObject canvas;
    public bool isOpen;
    public bool isInRange;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        edgeCollider = GetComponent<EdgeCollider2D>();
        polygonCollider = GetComponent<PolygonCollider2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        isOpen = false;
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Door();
    }

    void Door()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isOpen && isInRange)
        {
            OpenDoor();
        }
        else if (Input.GetKeyDown(KeyCode.E) && isOpen && isInRange)
        {
            CloseDoor();
        }
    }

    private void OpenDoor()
    {
        spriteRenderer.sortingOrder = 4;
        animator.SetBool("doorAnim", true);
        edgeCollider.enabled = true;
        polygonCollider.enabled = false;
        isOpen = true;
        isInRange = false;
    }

    private void CloseDoor()
    {
        spriteRenderer.sortingOrder = 1;
        animator.SetBool("doorAnim", false);
        edgeCollider.enabled = false;
        polygonCollider.enabled = true;
        isOpen = false;
        isInRange = false;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
            canvas.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
            canvas.SetActive(false);
        }
    }

}

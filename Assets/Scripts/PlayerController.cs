using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public float verticalInput;
    public float horizontalInput;
    public float speed = 5.0f;
    private bool isCollided;
    Animator animator;
    private SpriteRenderer spriteRenderer;
    private Vector3 lastFramePos;
    private Rigidbody2D rb;
    private float lastVerticalInput;
    private float lastHorizontalInput;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }



    void FixedUpdate()
    {
        if (!isCollided)
        {
            walk();
            flip_Character();
        } 
        else
        {
            isCollided = false;
            Debug.Log("Success");
        }
        
    }

    void LateUpdate()
    {
        lastFramePos = transform.position;
        lastVerticalInput = verticalInput;
        lastHorizontalInput = horizontalInput;
    }

    void walk()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        // Animation
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            animator.SetBool("is_Running", true);
        }
        else
        {
            animator.SetBool("is_Running", false);

        }
    }

    void flip_Character()
    {
        if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
        }

    }
}

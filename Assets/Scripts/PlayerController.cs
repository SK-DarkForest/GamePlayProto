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
    private Vector3 currentPosition;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }



    void Update()
    {
        walk();
        flip_Character();
    }

    void walk()
    {
            verticalInput = Input.GetAxis("Vertical");
            horizontalInput = Input.GetAxis("Horizontal");

            //transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput);
            //transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
            rb.velocity = (Vector2.up * verticalInput);
            rb.velocity = (Vector2.right * horizontalInput);
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

    public void Load_Base()
    {
        SceneManager.LoadScene("BaseScene");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BaseEntry"))
        {
            Debug.Log("Collided");
            Load_Base();
        }
        else if (other.CompareTag("BaseBorder"))
        {
            Debug.Log("Border!");
            isCollided = true;
        }
    }
}

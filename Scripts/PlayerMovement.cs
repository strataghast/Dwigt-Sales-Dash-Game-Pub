using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public Transform interactor;

    [Header("Dash Settings")]
    [SerializeField] private float dashSpeed = 10f;
    [SerializeField] private float dashDuration = 0.3f;
    [SerializeField] private float dashCooldown = 1f;
    bool isDashing;
    bool canDash;

    Vector2 movement;

    private void Start()
    {
        canDash = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Input (Control)
        if (isDashing)
        {
            return;
        }

        movement.x = Input.GetAxisRaw("Horizontal"); // -1 to left, 1 to right, 0 for no input
        movement.y = Input.GetAxisRaw("Vertical"); // -1 to down, 1 to up, 0 for no input

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            animator.SetFloat("LastHorizontal", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("LastVertical", Input.GetAxisRaw("Vertical"));
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash) 
        {
            StartCoroutine(Dash());
        }
    }

    void FixedUpdate()
    {
        // Movement

        if (isDashing)
        {
            return;
        }

        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);

    }

    public IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rb.velocity = new Vector2(movement.x * dashSpeed, movement.y * dashSpeed);
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
    public void OnTriggerEnter2D(Collider2D collision) // This will be called when the player collides with a paper
    {

        if (collision.gameObject.CompareTag("Enemy")) // If the player collides with the enemy
        {
            SceneManager.LoadScene("Sorry Toby"); // Load the game over scene with current score
        }
    }

}

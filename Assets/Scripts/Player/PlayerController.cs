using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{ 

    [SerializeField] private float speed = 1f;
    [SerializeField] private float moveHorizontal = 3f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float flyForce = 5f;
    [SerializeField] private int maxAirJumps = 3;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private bool isFlying;
    [SerializeField] private bool canJump = true;
    [SerializeField] private GameObject chapter2Point;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isFlying = false;
    }

    private void Update()
    {

        if (Input.GetMouseButton(0))
        {
            if (isGrounded )
            {
                Jump();
            }            
        }

    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(moveHorizontal, rb.velocity.y);
        rb.velocity = movement * speed;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
       
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && gameObject.activeSelf)
        {
            isGrounded = false;
        }
    }
        

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            StartCoroutine(WaitForSecond(2f));
            GameManager.Instance.IncreaseAttemptCount();
            this.transform.position = GameManager.Instance.StartPoint().position;
            UIManager.instance.attemptCountText.text = "Attempt " + PlayerPrefs.GetInt("attemptCount").ToString();
        }

        if (collision.gameObject.CompareTag("NewLevel"))
        {
            StartCoroutine(WaitForSecond(2f));
            GameManager.Instance.ChangePlayerSprite();

            isFlying = true;
            transform.position = chapter2Point.transform.position;

            if(isFlying && Input.GetMouseButtonDown(0))
            {
                Fly();
            }

        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        transform.DORotate(new Vector3(0f, 0f, transform.rotation.eulerAngles.z - 90f), .1f)
            .OnComplete(() => canJump = true);

        canJump = false;

    }

    private void Fly()
    {
        isFlying = true;
        rb.velocity = new Vector2(rb.velocity.x, flyForce);
    }

    private IEnumerator WaitForSecond(float duration)
    {
        yield return new WaitForSeconds(duration);
    }
}

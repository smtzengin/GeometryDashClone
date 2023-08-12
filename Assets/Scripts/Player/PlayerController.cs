using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Player Jump Variables")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float moveHorizontal = 3f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private bool canJump = true;

    [Header("Player Fly Variables")]
    [SerializeField] private float flyForce = 15f;
    [SerializeField] private bool isFlying, isPlayerInShip = false;


    [Header("Chapter Points")]
    [SerializeField] private GameObject chapter2Point;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        AudioManager.Instance.mainLevelAudio.Play();

    }

    private void Update()
    {

        if (Input.GetMouseButton(0))
        {
            if (isGrounded)
            {
                Jump();
            }            
        }


        if (isPlayerInShip && !isGrounded)
        {
            if (Input.GetMouseButton(0))
            {
                rb.gravityScale = 2f;
                Fly();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                rb.gravityScale = 4f;
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
            moveHorizontal = 8f;
            AudioManager.Instance.deathAudio.Play();
            AudioManager.Instance.mainLevelAudio.Stop();          
            
            StartCoroutine(WaitForSecond(2f));
            GameManager.Instance.IncreaseAttemptCount();
            StartCoroutine(WaitForSecond(2f));
            this.transform.position = GameManager.Instance.StartPoint().position;
            AudioManager.Instance.mainLevelAudio.Play();
            UIManager.instance.attemptCountText.text = "Attempt " + PlayerPrefs.GetInt("attemptCount").ToString();
            if (isPlayerInShip)
            {
                GameManager.Instance.ChangePlayerSprite();
            }
            isPlayerInShip = false;
            rb.gravityScale = 5f;
            
        }


        if (collision.gameObject.CompareTag("NewLevel"))
        {
            moveHorizontal = 0f;
            StartCoroutine(WaitForSecond(2f));
            GameManager.Instance.ChangePlayerSprite();
            StartCoroutine(WaitForSecond(2f));

            transform.position = chapter2Point.transform.position;
            isPlayerInShip = true;
            canJump = false;
            transform.rotation = Quaternion.EulerRotation(Vector3.zero);
        }

        if (collision.gameObject.CompareTag("FinishLine"))
        {
            UIManager.instance.levelComplete.SetActive(true);
            StartCoroutine(WaitForSecond(3f));
            SceneManager.LoadScene(1);
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
        moveHorizontal = 8f;

        rb.AddForce(Vector2.up * flyForce);
    }

    private IEnumerator WaitForSecond(float duration)
    {
        yield return new WaitForSeconds(duration);
    }
}

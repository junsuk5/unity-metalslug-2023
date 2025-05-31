using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce = 400f;

    private bool isJump = false;
    private Rigidbody2D playerRigidbody;
    private Animator animator;
    private AudioSource gunfireAudioSource;

    public GameObject bulletPrefab;
    public float bulletSpeed = 10.0f;


    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gunfireAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }
        else
        {
            Idle();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

        if (!isJump && Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isJump)
            {
                return;
            }
            playerRigidbody.linearVelocity = Vector2.zero;
            playerRigidbody.AddForce(Vector2.up * jumpForce);
            isJump = true;
        }
    }

    private void Attack()
    {
        animator.SetTrigger("attack");
        gunfireAudioSource.Play();

        bool isLeft = transform.localScale.x < 0;

        // 주인공의 오른쪽 위치에서 총알을 생성
        Vector3 spawnPosition = transform.position
             + new Vector3(isLeft ? -1.0f : 1.0f, 0.3f, 0.0f);
        // 총알 생성 및 발사
        GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);

        SpriteRenderer bulletSpriteRenderer = bullet.GetComponent<SpriteRenderer>();

        // 좌우 방향 설정
        bulletSpriteRenderer.flipX = isLeft;
    }

    private void Idle()
    {
        animator.SetBool("isWarking", false);
    }

    private void MoveRight()
    {
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x);
        transform.localScale = scale;

        transform.Translate(6.0f * Time.deltaTime * Vector3.right);

        animator.SetBool("isWarking", true);
    }

    private void MoveLeft()
    {
        Vector3 scale = transform.localScale;
        scale.x = -Mathf.Abs(scale.x);
        transform.localScale = scale;

        transform.Translate(6.0f * Time.deltaTime * Vector3.left);

        animator.SetBool("isWarking", true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            animator.SetBool("isGrounded", true);
            isJump = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            animator.SetBool("isGrounded", false);
        }
    }
}

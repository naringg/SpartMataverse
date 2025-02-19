using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video; // VideoPlayer ����� ���� ���ӽ����̽� �߰�

public class Player : MonoBehaviour
{
    Animator animator;
    Rigidbody2D _rigidbody;
    VideoPlayer videoPlayer; // VideoPlayer ���� �߰�

    public float flapForce = 6f;
    public float forwardSpeed = 3f;
    public bool isDead = false;
    float deathCooldown = 0f;

    bool isFlap = false;
    public bool godMode = false;

    GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.Instance;
        animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();

        // ������ VideoPlayer ������Ʈ ã��
        videoPlayer = FindObjectOfType<VideoPlayer>();

        if (animator == null)
            Debug.LogError("not Founded Animator");

        if (_rigidbody == null)
            Debug.LogError("not Founded Rigidbody");

        if (videoPlayer == null)
            Debug.LogError("VideoPlayer not found in the scene!");
    }

    void Update()
    {
        if (isDead)
        {
            if (deathCooldown <= 0f)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    gameManager.RestartGame();
                }
            }
            else
            {
                deathCooldown -= Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isFlap = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDead) return;

        Vector3 velocity = _rigidbody.velocity;
        velocity.x = forwardSpeed;

        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }
        _rigidbody.velocity = velocity;

        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void IncreaseSpeed(float amount)
    {
        forwardSpeed += amount;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode) return;
        if (isDead) return;

        isDead = true;
        deathCooldown = 1f;

        animator.SetInteger("isDie", 1);
        gameManager.GameOver();

        // �÷��̾ ������ VideoPlayer ����
        if (videoPlayer != null)
        {
            videoPlayer.Pause();
            Debug.Log("Video Paused");
        }
    }
}

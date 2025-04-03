using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Settings")]
    public float jumpForce;

    [Header("References")]
    public Rigidbody2D playerRigidBody;
    public Animator PlayerAnimator;

    public BoxCollider2D PlayerCollider;


    // 땅에 닿았는지 판별하는 변수
    private bool isGrounded = true;

    private int lives = 3;
    private bool isInvincible = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 키 입력 감지 

        // 스페이스바를 눌렀을 경우 
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRigidBody.AddForceY(jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            PlayerAnimator.SetInteger("state", 1);

        }
    }

    void KillPlayer()
    {
        PlayerCollider.enabled = false;
        PlayerAnimator.enabled = false;
        playerRigidBody.AddForceY(jumpForce, ForceMode2D.Impulse);
    }


    void Hit()
    {
        lives -= 1;
        // 체력이 0이하가 되면 플레이어 사망 
        if (lives <= 0)
        {
            KillPlayer();
        }
    }

    void Heal()
    {
        // 이미 3개 이상일경우에는 늘어나면 안됨 
        lives = Mathf.Min(3, lives + 1);       // 3으로 값을 제한, 3이상의 값이 들어와도 3을 반환
    }

    void StartInvincible()
    {
        isInvincible = true;
        Invoke("StopInvincible", 5f);
    }

    void StopInvincible()
    {
        isInvincible = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Platform")
        {
            if (!isGrounded)
            {
                PlayerAnimator.SetInteger("state", 2);
            }
            isGrounded = true;

        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // enemy와 부딪혔을때 
        if (collision.gameObject.tag == "enemy")
        {
            if (!isInvincible)
            {
                Destroy(collision.gameObject);
                Hit();
            }

        }
        else if (collision.gameObject.tag == "food")
        {
            Destroy(collision.gameObject);
            Heal();
        }
        else if (collision.gameObject.tag == "golden")
        {
            Destroy(collision.gameObject);
            StartInvincible();
        }

    }
}

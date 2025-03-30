using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Settings")]
    public float jumpForce;

    [Header("References")]
    public Rigidbody2D playerRigidBody;
    public Animator playerAnimator;

    // 땅에 닿았는지 판별하는 변수
    private bool isGrounded = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 키 입력 감지 

        // 스페이스바를 눌렀을 경우 
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            playerRigidBody.AddForceY(jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            playerAnimator.SetInteger("state", 1);
        
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Platform") {
            if(!isGrounded){
              playerAnimator.SetInteger("state", 2);
            }
            isGrounded = true;
   
        }
    }
}

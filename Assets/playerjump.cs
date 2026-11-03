using UnityEngine;

public class playerjump : MonoBehaviour
{
    [Header("점프 설정")]
    public float jumpForce = 5f;

    [Header("하이퍼 점프 설정")]
    public float hyperJumpForce = 1f;
    public float maxChargeTime = 2f;

    private Rigidbody rb;

    private bool isGrounded = true;
    private bool isCharging = false;

    private float chargeTime = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Space 키를 누르면 충전 시작
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isCharging = true;
            chargeTime = 0f;
        }

        // Space 키를 누르고 있는 동안 충전
        if (Input.GetKey(KeyCode.Space) && isCharging)
        {
            chargeTime += Time.deltaTime;
            chargeTime = Mathf.Clamp(chargeTime, 0f, maxChargeTime);
            
        }

        // Space 키를 떼면 점프 실행
        if (Input.GetKeyUp(KeyCode.Space) && isCharging)
        {
            Jump();
            isCharging = false;
        }
    }

    void Jump()
    {
        float chargePercent = chargeTime / maxChargeTime;

        float finalJumpForce = Mathf.Lerp(
            jumpForce,
            hyperJumpForce,
            chargePercent
        );

        // 수직 속도 초기화
        Vector3 velocity = rb.linearVelocity;
        velocity.y = 0f;
        rb.linearVelocity = velocity;

        // 점프 실행
        rb.AddForce(
            Vector3.up * finalJumpForce,
            ForceMode.Impulse
        );

        isGrounded = false;
    }

    // 바닥 충돌 확인
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
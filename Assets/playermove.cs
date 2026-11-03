
using UnityEngine;

public class playermove : MonoBehaviour
{
    [Header("이동 설정")]
    public float moveSpeed = 5f;

    void Update()
    {
        // WASD 키 입력
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // 이동 방향 계산
        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        // Cube 이동
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }
}


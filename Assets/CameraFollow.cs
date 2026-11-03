using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("추적할 캐릭터")]
    public Transform target;

    [Header("카메라 위치")]
    public Vector3 offset = new Vector3(0f, 5f, -8f);

    [Header("카메라 부드러움")]
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (target == null)
            return;

        // 목표 카메라 위치
        Vector3 desiredPosition = target.position + offset;

        // 부드러운 카메라 이동
        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );

        // 캐릭터 바라보기
        transform.LookAt(target);
    }
}
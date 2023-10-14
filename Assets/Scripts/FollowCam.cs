using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target; // 주인공 캐릭터의 Transform 컴포넌트
    public float smoothTime = 0.3f; // 카메라 이동 속도

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, transform.position.z);
            // 주인공 캐릭터의 X 좌표를 따라가며 Y와 Z 좌표는 현재 카메라 위치와 동일하게 유지

            // 부드러운 이동을 위해 SmoothDamp 함수를 사용
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}

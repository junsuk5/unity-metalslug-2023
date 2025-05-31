using UnityEngine;

public class Bullet : MonoBehaviour
{
  public float speed = 20f; // 총알 이동 속도
  public float destroyTime = 1.0f; // 총알이 자동으로 삭제되는 시간

  private void Start()
  {
    SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

    // 총알을 정해진 방향으로 발사
    Rigidbody2D rb = GetComponent<Rigidbody2D>();
    if (!spriteRenderer.flipX)
    {
      rb.linearVelocity = new Vector2(speed, 0);
    }
    else
    {
      rb.linearVelocity = new Vector2(-speed, 0);
    }

    // 일정 시간 후에 총알 삭제
    Destroy(gameObject, destroyTime);
  }
}

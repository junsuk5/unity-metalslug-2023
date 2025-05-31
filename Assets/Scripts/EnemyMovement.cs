using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
  public float moveSpeed = 1.0f; // 이동 속도
  private Transform player; // 주인공 오브젝트

  private void Start()
  {
    player = GameObject.Find("Player").transform; // 주인공 오브젝트를 찾습니다.
  }

  private void Update()
  {
    MoveTowardsPlayer();
  }

  private void MoveTowardsPlayer()
  {
    // 주인공 쪽으로 이동
    Vector2 direction = (player.position - transform.position).normalized;
    GetComponent<Rigidbody2D>().linearVelocity = direction * moveSpeed;
  }
}

using UnityEngine;

public class AvoidCollision : MonoBehaviour
{

  void Start()
  {
    // 주인공과 적 간의 충돌을 무시
    Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), true);
    Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemy"), LayerMask.NameToLayer("Enemy"), true);

  }
}

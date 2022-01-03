using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
  // どのボールを吸い寄せるかをタグで指定
  // 1. 反応するタグのパラメータ
  public string targetTag;

  void OnTriggerStay(Collider other)
  {
    // 2. Rigidbodyコンポーネントの取得
    // コライダに触れているオブジェクトのRigidbodyコンポーネントを取得
    Rigidbody r = other.gameObject.GetComponent<Rigidbody>();

    // 3. ボール方向の計算
    // ボールがどの方向にあるかを計算
    Vector3 direction = other.gameObject.transform.position - transform.position;
    direction.Normalize();

    // 4. ボールへの力の加算
    // タグに応じてボールに力を加える
    if (other.gameObject.tag == targetTag)
    {
      // 中心地点でボールを止めるため減速させる
      r.velocity *= 0.9f;
      r.AddForce(direction * -20.0f, ForceMode.Acceleration);
    }
    else
    {
      r.AddForce(direction * 80.0f, ForceMode.Acceleration);
    }
  }
}

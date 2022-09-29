using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAroundPlayer : MonoBehaviour
{
    public Transform Target;

    [Header("Settings")]
    public float dmg;

    public float RotationSpeed;

    public float CircleRadius;

    public float ElevationOffset;

    private Vector3 positionOffset;
    private float angle;

    private void LateUpdate()
    {
        positionOffset.Set(
            Mathf.Cos(angle) * CircleRadius,
            ElevationOffset,
            Mathf.Sin(angle) * CircleRadius
        );
        transform.position = Target.position + positionOffset;
        angle += Time.deltaTime * RotationSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<EnemyController>())
        {
            collision.gameObject.GetComponent<EnemyController>().ChangeHp(dmg);
        }
    }
}

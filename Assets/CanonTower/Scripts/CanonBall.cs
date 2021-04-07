using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CannonBall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<RobotTouchController>())
        {
            Destroy(collision.gameObject);
        }
    }
}
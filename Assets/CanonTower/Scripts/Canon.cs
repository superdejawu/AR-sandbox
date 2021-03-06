using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Canon : MonoBehaviour
{
    [SerializeField]
    private float shootingForce = 500f;
    [SerializeField]
    private float turnSpeed = 40f;
    [SerializeField]
    private GameObject cannonBallPrefab;
    [SerializeField]
    private Transform spawnPoint;
    void Start()
    {
        InvokeRepeating("ShootAtPlayer", 1.5f, 0.75f);
    }
    void Update()
    {
        if (!RobotPlayer())
        {
            return;
        }
        else
        {
            Vector3 targetDirection = RobotPlayer().transform.position - transform.position;
            Vector3 direction = Vector3.RotateTowards(transform.forward, targetDirection, Time.deltaTime * turnSpeed, 0.0f);
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
    private void ShootAtPlayer()
    {
        if (RobotPlayer())
        {
            GameObject cannonBall = Instantiate(cannonBallPrefab, spawnPoint.position, spawnPoint.rotation);
            cannonBall.GetComponent<Rigidbody>().AddForce(cannonBall.transform.forward * shootingForce);
            Destroy(cannonBall, 2f);
        }
    }
    private GameObject RobotPlayer()
    {
        RobotTouchController robotPlayer = FindObjectOfType<RobotTouchController>();
        if (robotPlayer)
        {
            return robotPlayer.gameObject;
        }
        return default;
    }
}
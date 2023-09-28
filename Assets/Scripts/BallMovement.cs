using System;
using Unity.VisualScripting;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector3 _upVector = new Vector3(0, 1, 1);
    private Vector3 _sideVector = new Vector3(-1, 0, 0);

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("UpForce"))
            AddForceToBall(_upVector);

        if (other.CompareTag("SideForce"))
            AddForceToBall(_sideVector);
        
        if (other.CompareTag("Respawn"))
            RestartGame();
    }

    private void AddForceToBall(Vector3 forceVector)
    {
        print("Hit with Force Vector: " + forceVector);
        _rb.AddForce(forceVector * 10, ForceMode.Impulse);
    }

    private void RestartGame()
    {
        print("Restart game");
    }
}

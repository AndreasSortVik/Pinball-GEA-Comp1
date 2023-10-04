using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    public int points;
    
    private Rigidbody _rb;
    private Vector3 _upVector = new Vector3(1, 1, 1);
    private Vector3 _sideVector = new Vector3(-1, 0, 1);
    private Vector3 _startPos = new Vector3(0.75f, 6, -0.75f);

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        transform.position = _startPos;
        points = 0;
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
        points++;
        print("Hit with Force Vector: " + forceVector);
        _rb.AddForce(forceVector * 5, ForceMode.Impulse);
    }

    private void RestartGame()
    {
        print("Restart game");
        SceneManager.LoadScene(0);
    }
}

using UnityEngine;

public class GravityTimer : MonoBehaviour
{
    private Rigidbody _rb;
    private float _timer;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    
    private void Start()
    {
        _rb.useGravity = false;
        _timer = 0;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        
        if (_timer >= 2f)
            _rb.useGravity = true;
    }
}

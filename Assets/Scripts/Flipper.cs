using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField] private AnimationCurve animationCurve;
    [SerializeField] private KeyCode keyCode;
    
    private Rigidbody _rb;
    private float _timer;
    private Quaternion _startRot;

    private void Awake()
    {
        _startRot = transform.rotation;
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Key press will not be acknowledged while flipper is rotating
        if (_rb.rotation == _startRot)
            CheckKeyPress();

        _timer += Time.deltaTime;
    }

    private void CheckKeyPress()
    {
        if (Input.GetKeyDown(keyCode))
        {
            _timer = 0;
        }
    }
    
    private void FixedUpdate()
    {
        _rb.MoveRotation(_startRot * Quaternion.Euler(0, 0, -animationCurve.Evaluate(_timer) * 90f));
    }
}

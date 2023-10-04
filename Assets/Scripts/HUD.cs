using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private BallMovement ballMovement;
    [SerializeField] private TMP_Text score;
    [SerializeField] private TMP_Text time;

    private string _scoreText;
    private string _timeText;

    private float _time;
    
    private void Awake()
    {
        _scoreText = "Score: ";
        _timeText = "Time: ";
    }

    private void Update()
    {
        _time += Time.deltaTime;
        
        score.text = _scoreText + ballMovement.points;
        time.text = _timeText + _time.ToString("f2");
    }
}

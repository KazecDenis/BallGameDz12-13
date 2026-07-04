using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BallController _ballController;
    [SerializeField] private int _winCountDiamond;
    [SerializeField] private float _wastedTime;
    [SerializeField] private Transform _startBallPosition;
    [SerializeField] private GameObject[] _diamonds;
    private const string _restartMassage = "нажмите клавишу F для перезагрузки уровня.";
    private Rigidbody _ballRigidbody;

    private bool _isGameOver;
    private float _timer;

    private void Awake()
    {
        _ballRigidbody = _ballController.GetComponent<Rigidbody>();
        _ballController.ResetPosition(_startBallPosition);
    }

    private void Update()
    {

        if (_isGameOver == false)
        {
            _timer += Time.deltaTime;
            Debug.Log(_timer.ToString("F2"));

            if (_timer >= _wastedTime)
            {
                ProcessOverGame();
                
                Debug.Log($"вы не успели собрать {_winCountDiamond} алмазов за {_timer.ToString("F2")} сек.");
                Debug.Log(_restartMassage);
            }
            else if (_ballController.DiamondCount() >= _winCountDiamond)
            {
                ProcessOverGame();
                WinProcessGame();
            }
        }

        if (Input.GetKey(KeyCode.F))
        {
            RestartGame();
        }
    }
                
   
    private float ResetTimer() => _timer = 0f;

    private void ProcessOverGame()
    {
        _ballRigidbody.isKinematic = true;
        Debug.Log($"прошло - {_timer.ToString("F2")} сек. у вас {_ballController.DiamondCount()} алмазов");
        _isGameOver = true;
    }

    private void WinProcessGame()
    {
        Debug.Log($"Ура вы победили");
        Debug.Log(_restartMassage);
    }

    private void RestartGame()
    {
        foreach (var diamond in _diamonds)
        {
            diamond.SetActive(true);
        }

        _ballController.ResetPosition(_startBallPosition);
        _ballRigidbody.isKinematic = false;
        _ballRigidbody.velocity = Vector3.zero;
        _ballController.ResetDiamond();
        ResetTimer();
        _isGameOver = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] BallController ballController;
    [SerializeField] private int _winCountDiamond;
    [SerializeField] private float _wastedTime;
    [SerializeField] private Transform _startBallPosition;
    [SerializeField] private GameObject[] _diamonds;
    private const string _restartMassage = "нажмите клавишу F для перезагрузки уровня.";


    private bool isGameOver;
    private float _timer;
    
    private float Timer() => _timer;

    private void Start()
    {
        _diamonds = GameObject.FindGameObjectsWithTag("Diamonds");
    }

    private void Awake()
    {
        ballController.GetComponent<BallController>().ResetPosition(_startBallPosition);
    }

    private void Update()
    {

        if (isGameOver == false)
        {
            _timer += Time.deltaTime;
            Debug.Log(Timer().ToString("F2"));

            if (_timer >= _wastedTime)
            {
                ProcessOverGame();
                if (ballController.DiamondCount() < _winCountDiamond && _timer >= _wastedTime)
                {
                    Debug.Log($"вы не успели собрать {_winCountDiamond} алмазов за {Timer().ToString("F2")} сек.");
                    Debug.Log(_restartMassage);
                }
                else
                {
                    WinProcessGame();
                    Debug.Log(_restartMassage);
                }
            }
            else if (ballController.DiamondCount() >= _winCountDiamond)
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
        ballController.GetComponent<Rigidbody>().isKinematic = true;
        Debug.Log($"прошло - {Timer().ToString("F2")} сек. у вас {ballController.DiamondCount()} алмазов");
        isGameOver = true;
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

        ballController.ResetPosition(_startBallPosition);
        ballController.GetComponent<Rigidbody>().isKinematic = false;
        ballController.ResetDiamond();
        ResetTimer();
        isGameOver = false;
    }
}

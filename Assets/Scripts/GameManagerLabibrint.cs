using UnityEngine;

public class GameManagerLabibrint : MonoBehaviour
{
    [SerializeField] private GameObject _ball;
    [SerializeField] private Transform _startTarget;
    [SerializeField] private Transform _startTargetPlatform;
    [SerializeField] private GameObject _platform;


    private float _timer;

    private bool _isGame = true;

    private void Awake()
    {
        ResetPositionBall();
        ResetRotationPlatform();
        ResetPositionPlatform();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            RestartGame();
        }
        
        if (_isGame == true)
        {
            _timer += Time.deltaTime;
            Debug.Log($"{_timer.ToString("F2")} сек");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            ProcessWin();
        }
    }

    private void ProcessWin()
    {
        Debug.Log("Вы победили!");
        Debug.Log($"Вы добрались до финала за {_timer.ToString("F2")} сек");
        _ball.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        _isGame = false;
    }

    private void ResetPositionBall() => _ball.transform.position = _startTarget.transform.position;
    private void ResetPositionPlatform() => _platform.transform.position = _startTargetPlatform.transform.position;
    private void ResetRotationPlatform() => _platform.transform.rotation = Quaternion.identity;

    private void ResetTimer() => _timer = 0;

    private void RestartGame()
    {
        _ball.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        ResetRotationPlatform();
        ResetPositionBall();
        ResetPositionPlatform();
        ResetTimer();
        _isGame = true;
    }
}

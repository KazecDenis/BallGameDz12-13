using UnityEngine;

public class FollowForBall : MonoBehaviour
{
   [SerializeField] private Vector3 _offSet;
   [SerializeField] private Transform _target;

    private void LateUpdate()
    {

        transform.position = _target.transform.position + _offSet;

    }
}

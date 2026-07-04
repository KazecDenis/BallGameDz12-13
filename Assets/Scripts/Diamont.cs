using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamont : MonoBehaviour
{
    [SerializeField] private BallController ballController;
    [SerializeField] private ParticleSystem _deadEffect;

    private int _reward = 1;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == ballController.gameObject)
        {
            DeadEffectON();
            ballController.TakeDiamond(_reward);
            gameObject.SetActive(false);
        }
    }
    public void DeadEffectON()
    {
        _deadEffect.transform.position = transform.position;
        _deadEffect.Play();
    }
}

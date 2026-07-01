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
        if (other.CompareTag("Ball"))
        {
            DeadEffectON();
            TakeDiamondTo();
            gameObject.SetActive(false);
        }
    }
    private void TakeDiamondTo()
    {
        ballController.GetComponent<BallController>().TakeDiamond(_reward);      
    }
    public void DeadEffectON()
    {
        _deadEffect.transform.position = transform.position;
        _deadEffect.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwiperRotate : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed =50f;

    private int _firstSide = 1;
    private int _secondSide = -1;
    private int _currentSide;

    private int _minChance = 0;
    private int _maxChance = 1;

    private void Awake()
    {
        _currentSide = DetermineRotateSide();
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, _currentSide * _rotationSpeed * Time.deltaTime);
    }

    private int DetermineRotateSide()
    {
        int chance = Random.Range(_minChance, _maxChance + 1);

        return chance == 0 ? _firstSide : _secondSide;
    }
}

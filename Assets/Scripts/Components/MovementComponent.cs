using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private Transform[] _position;
    private int _lengthPosition;
    private int _currentIndex = 0;
    private Transform _currentTarget;

    private void Awake()
    {
        _lengthPosition = _position.Length;
        if (_lengthPosition > 0)
        {
            _currentTarget = _position[0];
        }
    }

    private void Update()
    {
        if (_lengthPosition > 0 && _currentTarget != null)
        {
            MoveTowardsTarget();

            if (Vector3.Distance(_gameObject.transform.position, _currentTarget.position) < 0.1f)
            {
                _currentIndex = (_currentIndex + 1) % _lengthPosition;
                _currentTarget = _position[_currentIndex];
            }
        }
    }

    private void MoveTowardsTarget()
    {
        _gameObject.transform.position = Vector3.MoveTowards(_gameObject.transform.position, _currentTarget.position, _speed * Time.deltaTime);
    }

    // Метод для создания пустышки в сцене
    [ContextMenu("Create Empty Point")]
    private void CreateEmptyPoint()
    {
        GameObject newPoint = new GameObject("New Point");
        newPoint.transform.position = transform.position;
        newPoint.transform.SetParent(transform.parent);
    }
}
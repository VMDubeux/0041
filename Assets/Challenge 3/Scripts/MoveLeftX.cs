using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftX : MonoBehaviour
{
    [SerializeField] private float _speed = 10.0f;
    private PlayerControllerX _playerControllerScript;
    private float _leftBound = -11.5f;

    void Start()
    {
        _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
    }

    void Update()
    {
        if (_playerControllerScript.GameIsNotOver) transform.Translate(Vector3.left * _speed * Time.deltaTime, Space.World); // If game is not over, move to the left

        if (transform.position.x < _leftBound && !gameObject.CompareTag("Background")) Destroy(gameObject);// If object goes off screen that is NOT the background, destroy it
    }
}

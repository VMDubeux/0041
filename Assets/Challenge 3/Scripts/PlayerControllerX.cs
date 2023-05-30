using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControllerX : MonoBehaviour
{
    [Header("Complementar GameObjects 1:")]
    public ParticleSystem ExplosionParticle;
    public ParticleSystem FireworksParticle;

    [Header("Complementar GameObjects 2:")]
    public AudioClip MoneySound;
    public AudioClip ExplodeSound;

    [Header("Private Variables:")]
    [SerializeField] private float _floatForce = 5.0f;
    [SerializeField] private float _gravityModifier = 1.5f;
    [SerializeField] private float _bottomImpulse = 1.0f;

    //Not Serialized Private Variables:
    private Rigidbody _playerRb;
    private AudioSource _playerAudio;
    Vector3 _startPos;
    Vector3 _bottomPos;

    //Internal Variable:
    internal bool GameIsNotOver = true;

    void Start()
    {
        _startPos = new Vector3(-7, 8, 0);
        transform.position = _startPos;

        _bottomPos = new Vector3(-7, 1.0f, 0);

        Physics.gravity *= _gravityModifier;
        _playerRb = GetComponent<Rigidbody>();
        _playerRb.AddForce(Vector3.up * _floatForce, ForceMode.Impulse); // Apply a small upward force at the start of the game
        _playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GameIsNotOver) // While space is pressed and player is low enough, float up
        {
            _playerRb.AddForce(Vector3.up * _floatForce, ForceMode.Impulse);
        }

        if (transform.position.y > 14.5f) transform.position = new Vector3(transform.position.x, 14.5f, 0);
        else if (transform.position.y < 1.0f) _playerRb.AddForce(Vector3.up * _floatForce, ForceMode.Force);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bomb")) // if player collides with bomb, explode and set GameIsNotOver to true
        {
            ExplosionParticle.Play();
            _playerAudio.PlayOneShot(ExplodeSound, 1.0f);
            GameIsNotOver = false;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Money")) // if player collides with money, fireworks
        {
            FireworksParticle.Play();
            _playerAudio.PlayOneShot(MoneySound, 1.0f);
            Destroy(other.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehavior : MonoBehaviour
{

    //[SerializeField]
    //private float _speed = 3f;
    [SerializeField]
    private float _rotationSpeed = 100f;
    [SerializeField]
    private GameObject _exposionPrefab;

    private Player _player;

    private SpawnManager _spawnManager;

    private AudioManager _audioManager;


    // Start is called before the first frame update
    void Start()
    {
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        _player = GameObject.Find("Player").GetComponent<Player>();
        _audioManager = GameObject.Find("Audio_Manager").GetComponent<AudioManager>();

        if (_audioManager == null)
        {
            Debug.LogError("audio manager is null");
        }
        if (_player == null)
        {
            Debug.LogError("player is null");
        }

        if (_spawnManager == null)
        {
            Debug.LogError("spawnManager is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * _rotationSpeed * Time.deltaTime);
        //transform.Translate(Vector3.down * Time.deltaTime * _speed);
        if (transform.position.y <= -5.7)
        {
            transform.position = new Vector3(Random.Range(-9.3f, 10), 8.4f, 0);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            Instantiate(_exposionPrefab, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            if (_player != null)
            {
                _player.IncreaseScore(5);
            }
            _spawnManager.StartSpawning();
            _audioManager.PlayExplosionSound();
            Destroy(this.gameObject);
        }
        else if (other.tag == "Player")
        {
            if (_player != null)
            {
                _player.Damage(); 
            }
            _spawnManager.StartSpawning();
            _audioManager.PlayExplosionSound();
            Destroy(this.gameObject);
        }
    }
}

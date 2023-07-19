using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8f;

    private Player _player;

    private Animator _enemyAnimator;

    private AudioManager _audioManager;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _enemyAnimator = GetComponent<Animator>();
        _audioManager = GameObject.Find("Audio_Manager").GetComponent<AudioManager>();

        if ( _player == null )
        {
            Debug.LogError("player is null");
        }

        if ( _enemyAnimator == null)
        {
            Debug.LogError("animator is null");
        }

        if(_audioManager == null)
        {
            Debug.LogError("audio manager is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Enemy: " + transform.position);
        transform.Translate(Vector3.down * Time.deltaTime * _speed);

        if(transform.position.y <= -5.7)
        {
            transform.position = new Vector3(Random.Range(-9.3f, 10), 8.4f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            if (_player != null)
            {
                _player.IncreaseScore(10);
                
            }
            _enemyAnimator.SetTrigger("OnEnemyDeath");
            _speed = 0;
            _audioManager.PlayExplosionSound();
            Destroy(GetComponent<Collider2D>());
            Destroy(this.gameObject,2.6f);
        } 
        else if (other.tag == "Player")
        {
            if (_player != null)
            {
                _player.Damage();
                
            }
            _enemyAnimator.SetTrigger("OnEnemyDeath");
            _speed = 0;
            _audioManager.PlayExplosionSound();
            Destroy(GetComponent<Collider2D>());
            Destroy(this.gameObject, 2.6f);
        }
    }
}

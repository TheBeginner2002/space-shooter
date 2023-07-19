using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;
    [SerializeField]
    private int _typeOfPowerUp;

    private AudioManager _audioManager;

    // Start is called before the first frame update
    void Start()
    {
        _audioManager = GameObject.Find("Audio_Manager").GetComponent<AudioManager>();

        if(_audioManager == null) 
        {
            Debug.LogError("audio manager is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * _speed);

        if (transform.position.y < -6f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("collided with: " + collision.name);
        if (collision.tag == "Player")
        {
            //access the player
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                switch (_typeOfPowerUp)
                {
                    case 0:
                        //enable triple shot
                        player.TripleShotActive();
                        break;
                    case 1:
                        player.SpeedBoostActive();
                        break;
                    case 2:
                        player.ShieldActive();
                        break;
                }
            }
            _audioManager.PlayPowerUpSound();
            //destroy ourselves
            Destroy(this.gameObject);
        }
    }
}

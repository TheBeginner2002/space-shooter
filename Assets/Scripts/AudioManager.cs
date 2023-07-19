using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource _laserSound;
    [SerializeField]
    private AudioSource _explosion;
    [SerializeField]
    private AudioSource _powerUp;

    public void PlayLaserSound()
    {
        _laserSound.Play();
    }

    public void PlayExplosionSound()
    {
        _explosion.Play();
    }

    public void PlayPowerUpSound()
    {
        _powerUp.Play();
    }
}

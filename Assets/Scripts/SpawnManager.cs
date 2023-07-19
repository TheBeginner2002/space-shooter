using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private float _spawnDelay = 5.0f;
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _asteroidPrefab;
    [SerializeField]
    private GameObject[] _powerUpPrefab;
    [SerializeField]
    private GameObject _enemyContainer;

    private bool _stopSpawning = false;

    private float _spawnPowerUpTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartSpawning()
    {
        StartCoroutine(SpawnRoutine());
        StartCoroutine(SpawnPowerUp());
        //StartCoroutine(SpawnAsteroid());
    }

    private IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(3.0f);
        while (!_stopSpawning)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-9.3f, 10), 9f, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, spawnPos, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(_spawnDelay);
        }
    }

    private IEnumerator SpawnPowerUp()
    {
        yield return new WaitForSeconds(3.0f);
        while (!_stopSpawning)
        {
            _spawnPowerUpTime = Random.Range(3, 8);
            int randomPowerUp = Random.Range(0, 3);
            Vector3 spawnPos = new Vector3(Random.Range(-6f, 7f), 8.4f, 0);
            Instantiate(_powerUpPrefab[randomPowerUp], spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(_spawnPowerUpTime);
        }
    }

    private IEnumerator SpawnAsteroid()
    {
        while (!_stopSpawning)
        {
            _spawnPowerUpTime = Random.Range(5, 9);
            Vector3 spawnPos = new Vector3(Random.Range(-6f, 7f), 8.4f, 0);
            Instantiate(_asteroidPrefab, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(_spawnPowerUpTime);
        }
    }


    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _gameOverText;
    [SerializeField]
    private Image _imageLives;    
    [SerializeField]
    private Sprite[] _liveSprites;
    [SerializeField]
    private Text _replayText;

    private GameManager _gameManager;

    private Player _player;

    private int _score;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _gameOverText.gameObject.SetActive(false);
        _replayText.gameObject.SetActive(false);
        _scoreText.text = "Score: " + 0.ToString();
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();

        if (_gameManager == null)
        {
            Debug.Log("_gameManager is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        DisplayScore();
        DisplayLives();

    }

    void DisplayScore()
    {
        if (_player != null)
        {
            int score = _player.GetScore();
            _scoreText.text = "Score: " + score.ToString();
        }
    }

    void DisplayLives()
    {
        if(_player != null)
        {
            int lives = _player.GetLives();
            switch (lives)
            {
                case 1:
                    _imageLives.sprite = _liveSprites[1];
                    break;
                case 2:
                    _imageLives.sprite = _liveSprites[2];
                    break;
                case 3:
                    _imageLives.sprite = _liveSprites[3];
                    break;
            }
        }
        else
        {
            GameOverSequence();
        }
    }

    void GameOverSequence()
    {
        _gameManager.GameOver();
        _gameOverText.gameObject.SetActive(true);
        _replayText.gameObject.SetActive(true);
        _imageLives.sprite = _liveSprites[0];
        StartCoroutine(FlickerGameOverText());
    }

    private IEnumerator FlickerGameOverText()
    {
        
        while (true)
        {
            _gameOverText.text = "Game Over";
            yield return new WaitForSeconds(1f);
            _gameOverText.text = "";
            yield return new WaitForSeconds(1f);
        }
    }
}   

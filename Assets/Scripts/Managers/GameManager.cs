using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    static GameManager _instance = null;
    public static GameManager instance
    {
        get { return _instance; }
        set { _instance = value; }
    }

    int _score = 0;

    public int score
    {
        get { return _score; }
        set
        {
            _score = value;
            Debug.Log("Current Score Is " + _score);
        }
    }

    public int maxLives = 3;
    int _lives = 3;
    public int lives
    {
        get { return _lives; }
        set
        {
            if (_lives > value && _lives >= 0)
            {
                Debug.Log("dead");
                
                SpawnPlayer(currentLevel.spawnLocation, currentLevel.cameraSpawn);
            }
            _lives = value;
            if (_lives > maxLives)
            {
                _lives = maxLives;
            }
            else if (_lives < 0)
            {
                SceneManager.LoadScene("GameOver");
            }
            Debug.Log("Current Lives Are " + _lives);
        }
    }

    public int maxHealth = 3;
    int _health = 3;
    public int health
    {
        get { return _health; }
        set
        {
            
            _health = value;
            if (_health > maxHealth)
            {
                _health = maxHealth;
            }
            else if (_health < 0)
            {
                
                _health = maxHealth;
            }
            Debug.Log("Current Health is " + _health);
        }
    }

    public GameObject playerPrefab;
    public LevelManager currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Current Lives Are " + _lives);
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name == "Level1" || SceneManager.GetActiveScene().name == "GameOver")
            {
                SceneManager.LoadScene("TitleScreen");
            }
            else if (SceneManager.GetActiveScene().name == "TitleScreen")
            {
                SceneManager.LoadScene("Level1");
            }
        }

        if (_lives < 0)
        {
             SceneManager.LoadScene("GameOver");
        }

        if (SceneManager.GetActiveScene().name == "GameOver")
        {
            _lives = maxLives;
            _score = 0;
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            QuitGame();
        }


    }
    public void SpawnPlayer(Transform spawnLocation, Transform cameraSpawn)
    {
        //Camera mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
       Camera mainCamera = FindObjectOfType<Camera>();
         EnemyTurret[] turretEnemy = FindObjectsOfType<EnemyTurret>();
        EnemyGunner[] gunnerEnemy = FindObjectsOfType<EnemyGunner>();


        if (mainCamera)
         {
             mainCamera.player = Instantiate(playerPrefab, spawnLocation.position, spawnLocation.rotation);
            
             for (int i = 0; i < turretEnemy.Length; i++)
             {
                 turretEnemy[i].player = mainCamera.player.transform;
             }

            for (int i = 0; i < gunnerEnemy.Length; i++)
            {
                gunnerEnemy[i].player = mainCamera.player.transform;
            }

            mainCamera.transform.position = cameraSpawn.position;
        }
         else
         {
             SpawnPlayer(spawnLocation, cameraSpawn);
         }
        
     }
        
   
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif

    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("TitleScreen");
    }

}

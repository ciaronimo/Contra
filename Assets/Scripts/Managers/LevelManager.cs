using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int startingLives;
    public Transform spawnLocation;
    public Transform cameraSpawn;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.lives = startingLives;
        GameManager.instance.SpawnPlayer(spawnLocation, cameraSpawn);
        GameManager.instance.currentLevel = this;
    }

}

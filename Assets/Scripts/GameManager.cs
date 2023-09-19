using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    //hide in inspector so it won't show on unity inspector
    [HideInInspector] public int Score = 0;

    //obstacle Variables
    public List<GameObject> obstaclePrefabs;
    public float obstacleSpeed = 10f;
    public float obstacleInterval = 1f;
    public Vector2 obstacleOffSety = new Vector2(0, 0);
    public float obstacleOffSetX = 0;

    //difficulty settings
    [HideInInspector] public int scoreToRaiseDifficultyController = 0;

    //player variables
    public List<GameObject> playerPrefabs;

    private bool isGameOver = false;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        } else
        {
            Instance = this;
        }
    }
    public bool isGameActive()
    {
        return !isGameOver;
    }
    public bool isGameover()
    {
        return isGameOver;
    }
    public void EndGame()
    {
        isGameOver = true;
        Debug.Log("game over! Your score was: " + Score);

        //this is how we call a Coroutine
        StartCoroutine(ReloadScene(2));
    }


    private IEnumerator ReloadScene(float delay)
    {
        //this will make unity to wait for the amount of time that was passed after the coroutine is called
        yield return new WaitForSeconds(delay);

        //this will get the name of the active scene (maybe we can have a public variable and fill with the name of the scene we want to load or reload)
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }
}

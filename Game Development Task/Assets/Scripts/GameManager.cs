using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton
    static private GameManager instance;
    static public GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("There is not GameManager in the scene.");
            }
            return instance;
        }
    }

    public PlayerInteraction playerInteraction;
    public PlayerHealth playerHealth;
    public PlayerMove playerMove;

    private float currentTime;
    public float CurrentTime
    {
        get
        {
            return currentTime;
        }
    }

    private bool isGameOver;
    public bool IsGameOver
    {
        get
        {
            return isGameOver;
        }
        set
        {
            isGameOver = false;
        }
    }

    private bool hasWon = false;
    public bool HasWon
    {
        get
        {
            return hasWon;
        }
    }

    void Awake()
    {
        if (instance != null)
        {
            // there is already a UIManager in the scene, destory this one
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    public void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        playerInteraction = FindObjectOfType<PlayerInteraction>();
        playerMove = FindObjectOfType<PlayerMove>();

        currentTime = 0; // reset the current time
        isGameOver = false;

        Time.timeScale = 1;
        
        
        Debug.Log("Game start!");
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTime();
        GameOver();
        Analytics();
    }

    private void UpdateTime()
    {
        currentTime += Time.deltaTime;
    }

    private void GameOver()
    {
        if (playerHealth.IsDead == true) // Lose
        {
            isGameOver = true;
            Time.timeScale = 0; // Pause the game
        }

        if (playerInteraction.CurrentPoint == 4) // Win
        {
            isGameOver = true;
            hasWon = true;
            Time.timeScale = 0; // Pause the game
        }
    }

    void Analytics()
    {
        Debug.Log(currentTime);
        Debug.Log(playerMove.Direction);
        Debug.Log(playerInteraction.CheckpointsTime[playerInteraction.CurrentPoint]);

    }
}

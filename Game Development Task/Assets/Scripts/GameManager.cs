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
        Time.timeScale = 1;
        currentTime = 0; // reset the current time
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTime();
        GameOver();
    }

    private void UpdateTime()
    {
        currentTime += Time.deltaTime;
    }

    private void GameOver()
    {
        if (playerHealth.IsDead == true)
        {
            isGameOver = true;
            Time.timeScale = 0; // Pause the game
        }

        if (playerInteraction.CurrentPoint == 5)
        {
            isGameOver = true;
            hasWon = true;
            Time.timeScale = 0; // Pause the game
        }
    }

}

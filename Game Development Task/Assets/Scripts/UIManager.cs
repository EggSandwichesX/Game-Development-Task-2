using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Singleton
    static private UIManager instance;
    static public UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("There is not UIManager in the scene.");
            }
            return instance;
        }
    }

    public Text timeInfo;
    public Text resultInfo;

    public GameObject resultPanel;



    public Slider slider;
    public Color low;
    public Color high;


    public GameManager gameManager;
    public PlayerInteraction playerInteraction;
    public PlayerHealth playerHealth;

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
    void Start()
    {
        resultPanel.SetActive(false);
        Time.timeScale = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        SetHealthBar();
        timeInfo.text = Mathf.Floor(gameManager.CurrentTime).ToString() + "S";

        if (gameManager.IsGameOver == true)
        {
            resultPanel.SetActive(true); // Game Over Panel pops up
            if (gameManager.HasWon)
            {
                resultInfo.text =
                "You Win!" + "\n" + "\n" +
                "Checkpoint1:   " + playerInteraction.CheckpointsTime[0] + "\n" +
                "Checkpoint2:   " + playerInteraction.CheckpointsTime[1] + "\n" +
                "Checkpoint3:   " + playerInteraction.CheckpointsTime[2] + "\n" +
                "Checkpoint4:   " + playerInteraction.CheckpointsTime[3] + "\n" +
                "Checkpoint5:   " + playerInteraction.CheckpointsTime[4];
            }
            else
            {
                resultInfo.text =
                "You died!" + "\n" + "\n" +
                "Checkpoint1:   " + playerInteraction.CheckpointsTime[0] + "\n" +
                "Checkpoint2:   " + playerInteraction.CheckpointsTime[1] + "\n" +
                "Checkpoint3:   " + playerInteraction.CheckpointsTime[2] + "\n" +
                "Checkpoint4:   " + playerInteraction.CheckpointsTime[3] + "\n" +
                "Checkpoint5:   " + playerInteraction.CheckpointsTime[4];
            }
            

        }
    }

    public void SetHealthBar()
    {
        //slider.gameObject.SetActive(playerHealth.CurrentHealth < 100);
        slider.value = playerHealth.CurrentHealth;
        slider.maxValue = 100;

    }

    public void Restart() // Reload the scene and hide the game over panel
    {
        gameManager.IsGameOver = false; // toggle off IsGameOver flag in GM
        SceneManager.LoadScene(0);
        resultPanel.SetActive(false);

        GameManager.Instance.Start();
        UIManager.Instance.Start();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerInteraction : MonoBehaviour
{
    private float timer;
    public float Timer
    {
        get
        {
            return timer;
        }
    }

    private int currentPoint = 0;
    public int CurrentPoint
    {
        get
        {
            return currentPoint;
        }
    }

    private string[] checkpointsTime;
    public string[] CheckpointsTime
    {
        get
        {
            return checkpointsTime;
        }

    }

    public GameObject[] checkpoints;

    public Material m_checkpoint;

    // Start is called before the first frame update
    void Start()
    {
        checkpointsTime = new string[checkpoints.Length];
        
        for (int i = 0; i < checkpointsTime.Length; i++)
        {
            checkpointsTime[i] = "Incomplete";
        }
        checkpoints[0].gameObject.tag = "Activated";
        checkpoints[0].GetComponent<MeshRenderer>().material = m_checkpoint;
        checkpoints[0].GetComponent<SphereCollider>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Activated")
        {
            activateCheckpoint();
            checkpointsTime[currentPoint] = Mathf.Floor(timer).ToString() + "S";
            other.gameObject.SetActive(false);
            
            
            
        }

    }

    public void activateCheckpoint()
    {
        

        if (currentPoint != checkpoints.Length - 1)
        {
            int nextPoint = currentPoint + 1;
            
            checkpoints[nextPoint].gameObject.tag = "Activated";
            checkpoints[nextPoint].GetComponent<MeshRenderer>().material = m_checkpoint;
            checkpoints[nextPoint].GetComponent<SphereCollider>().enabled = true;

            currentPoint++;

        }
        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class car : MonoBehaviour
{
    public float timer;
    public GameObject resultPanle;
    public Text timeinfo;
    public string checkpoint1;
    public string checkpoint2;
    public string checkpoint3;
    public string checkpoint4;
    public string checkpoint5;

    public GameObject c1;
    public GameObject c2;
    public GameObject c3;
    public GameObject c4;
    public GameObject c5;

    public Material m2;
    public Text resinfo;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timeinfo.text = Mathf.Floor(timer).ToString() + "S";



    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name=="checkpoint1")
        {
            checkpoint1 = Mathf.Floor(timer).ToString()+"S";
            Destroy(other.gameObject);
            c2.GetComponent<MeshRenderer>().material = m2;
            c2.GetComponent<SphereCollider>().enabled = true;
        }

        if (other.gameObject.name == "checkpoint2")
        {
            checkpoint2 = Mathf.Floor(timer).ToString() + "S";
            Destroy(other.gameObject);
            c3.GetComponent<MeshRenderer>().material = m2;
            c3.GetComponent<SphereCollider>().enabled = true;

        }

        if (other.gameObject.name == "checkpoint3")
        {
            checkpoint3 = Mathf.Floor(timer).ToString() + "S";
            Destroy(other.gameObject);
            c4.GetComponent<MeshRenderer>().material = m2;
            c4.GetComponent<SphereCollider>().enabled = true;
        }

        if (other.gameObject.name == "checkpoint4")
        {
            checkpoint4 = Mathf.Floor(timer).ToString() + "S";
            Destroy(other.gameObject);
            c5.GetComponent<MeshRenderer>().material = m2;
            c5.GetComponent<SphereCollider>().enabled = true;

        }

        if (other.gameObject.name == "checkpoint5")
        {
            checkpoint5 = Mathf.Floor(timer).ToString() + "S";
            Destroy(other.gameObject);

            resultPanle.SetActive(true);
            resinfo.text = "checkpoint1:   " + checkpoint1 + "\n" + "checkpoint2:   " + checkpoint2 + "\n" + "checkpoint3:   " + checkpoint3 + "\n" + "checkpoint4:   " + checkpoint4 + "\n" + "checkpoint5:   " + checkpoint5;

        }

    }
}

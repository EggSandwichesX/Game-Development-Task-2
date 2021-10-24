using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newcar : MonoBehaviour
{
    public Rigidbody rg;
    public float speeddata;
    public bool isonground = false;
    // Start is called before the first frame update
    void Start()
    {
        rg = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

     

        if (isonground)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            speeddata = Vector3.Distance(Vector3.zero, rg.velocity);
            rg.AddRelativeForce(new Vector3(0, 0, v * 300));
            if (rg.drag >= 0)
                rg.drag = speeddata/2;
            if (speeddata >=2)
                this.transform.Rotate(new Vector3(0, h / 2, 0));
            //else
            // speeddata=0
            print(rg.velocity);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Terrain")
            isonground = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Terrain")
            isonground = false;

    }
}

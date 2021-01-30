using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground_movement : MonoBehaviour
{
    private Vector2 screenbounds;
    bool walkleft;
    public float solsinir;
    public float sagsinir;
    bool walkright;
    public bool updown;

    // Start is called before the first frame update
    void Start()
    {
        walkleft = true;
        walkright = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (updown == false)
        {
            if (transform.position.x > sagsinir)
            {
                walkleft = true;
                walkright = false;
            }
            else if (transform.position.x < solsinir)
            {
                walkright = true;
                walkleft = false;
            }
            if (walkleft == true)
            {
                transform.position = new Vector3(transform.position.x - 0.01f, transform.position.y, transform.position.z);
            }
            else if (walkright == true)
            {
                transform.position = new Vector3(transform.position.x + 0.01f, transform.position.y, transform.position.z);
            }
        }
        else
        {
            if (transform.position.y < sagsinir)
            {
                walkleft = true;
                walkright = false;
            }
            else if (transform.position.y > solsinir)
            {
                Debug.LogError("q");
                walkright = true;
                walkleft = false;
            }
            if (walkleft == true)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.01f, transform.position.z);
            }
            else if (walkright == true)
            {
                transform.position = new Vector3(transform.position.x , transform.position.y - 0.01f, transform.position.z);
            }
        }
        
    }


}

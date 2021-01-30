using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_stick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("rate"))
        {
            PlayerPrefs.SetInt("rate", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.GetComponent<AudioSource>().Play();
    }


}

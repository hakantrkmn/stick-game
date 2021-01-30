using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        collision.transform.position = Vector3.zero;
        Vector3 eulerRotation = collision.transform.rotation.eulerAngles;
        collision.transform.rotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 90);
    }
}

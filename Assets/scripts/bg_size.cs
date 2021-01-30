using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg_size : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        changeToCamScale();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void changeToCamScale()
    {
        Vector3 k = transform.localScale;
        //k.x = 2 * Camera.main.orthographicSize * Camera.main.aspect / GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        k.y = 2 * Camera.main.orthographicSize / GetComponent<SpriteRenderer>().sprite.bounds.size.y;
        k.x = k.y;
        Debug.LogError(k);

        transform.localScale = k;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

            collision.gameObject.transform.position = Vector3.zero;
        collision.gameObject.GetComponent<stick>().olumSayisi += 1;
        
    }
}

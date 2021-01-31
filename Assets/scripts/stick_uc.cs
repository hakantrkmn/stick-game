using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stick_uc : MonoBehaviour
{
    public GameObject cubuk;
    public Rigidbody2D rb;
    public Animator boyAnim;
    public float jumpForce;
    public Vector3 hitPoint;


    void Start()
    {
        jumpForce = 1200f;
    }

    void Update()
    {
        hitPoint = gameObject.GetComponentInChildren<Transform>().position;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (SceneManager.GetActiveScene().buildIndex == 17)
        {
            if (collision.transform.tag == "reverseCard")
            {
                if (gameObject.GetComponentInParent<stick>().reverse == 0)
                {
                    gameObject.GetComponentInParent<stick>().reverse = 1;
                }
                else
                {
                    gameObject.GetComponentInParent<stick>().reverse = 0;
                }
                Destroy(collision.gameObject);

            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 18)
        {
            if (collision.transform.tag == "reverseCard")
            {
                if (gameObject.GetComponentInParent<Rigidbody2D>().gravityScale == 1)
                {
                    gameObject.GetComponentInParent<Rigidbody2D>().gravityScale = -1;
                }
                else
                {
                    gameObject.GetComponentInParent<Rigidbody2D>().gravityScale = 1;
                }
                Destroy(collision.gameObject);

            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //oyuncu yan kenarlara çarparsa zıplama animasyonunu oynatma
        if (collision.contacts[0].normal.x !=0)
        {

        }
        else
        {
            if (gameObject.name == "down")
            {
                rb.GetComponent<Animator>().SetTrigger("down1");
                boyAnim.SetTrigger("jump");
            }
            else if (gameObject.name == "up")
            {
                rb.GetComponent<Animator>().SetTrigger("up1");
                boyAnim.SetTrigger("jump");
            }
        }
        //oyuncunun zıplaması için çarptığı nokta ile oyuncunun konumu çıkar yönü al kuvvet uygula

        Vector2 test = new Vector2((float)hitPoint.x - (float)rb.transform.position.x, (float)hitPoint.y - (float)rb.transform.position.y);

        if (rb.transform.eulerAngles.z < 180 && rb.transform.eulerAngles.z >170 || rb.transform.eulerAngles.z < 10 && rb.transform.eulerAngles.z > 0)
        {

        }
        else
        {
            //yanlış yere çarparsa baştan başlat
            if (collision.transform.tag=="enemy")
            {
                rb.velocity = Vector2.zero;
                cubuk.transform.position = Vector3.zero;
                Vector3 eulerRotation = cubuk.transform.rotation.eulerAngles;
                cubuk.transform.rotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 90);
                return;
            }
            if (collision.transform.tag == "reverseCard" && collision.transform.tag == "bulut")
            {
                return;
            }
            rb.velocity = rb.velocity * 0.1f;
            if (SceneManager.GetActiveScene().buildIndex == 18)
            {
                rb.AddForce(new Vector2(-(float)test.x, (float)test.y) * -1 * jumpForce);
            }
            else
            {
                rb.AddForce(new Vector2((float)test.x, (float)test.y) * -1 * jumpForce);
            }
        }
    }



}

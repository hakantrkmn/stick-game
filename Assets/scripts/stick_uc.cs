using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stick_uc : MonoBehaviour
{
    public float speed;
    public GameObject cubuk;
    float z;
    public GameObject win_yazisi;
    public Rigidbody2D rb;

    Vector3 lastvelo;
    // Start is called before the first frame update
    void Start()
    {
        speed = 100;
    }

    // Update is called once per frame
    void Update()
    {
        //if (cubuk.transform.eulerAngles.z > 180 && cubuk.transform.eulerAngles.z < 350)
        //{
        //    Vector3 eulerRotation = cubuk.transform.rotation.eulerAngles;
        //    cubuk.transform.rotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 0);
        //}
        //else if (cubuk.transform.eulerAngles.z < 360 && cubuk.transform.eulerAngles.z > 350)
        //{
        //    Vector3 eulerRotation = cubuk.transform.rotation.eulerAngles;
        //    cubuk.transform.rotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 180);
        //}
        //else if ((cubuk.transform.eulerAngles.z < 0))
        //{
        //    Vector3 eulerRotation = cubuk.transform.rotation.eulerAngles;
        //    cubuk.transform.rotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 180);
        //}
        //lastvelo = rb.velocity;
    }

    //IEnumerator anim_control()
    //{

    //    yield return new WaitForSeconds(0.5f);
    //    gameObject.GetComponentInParent<Animator>().SetBool("hit", false);

    //}
    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    StartCoroutine(anim_control());
    //}


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
        if (collision.contacts[0].normal.x !=0)
        {

        }
        else
        {
            if (gameObject.name == "down")
            {
                rb.GetComponent<Animator>().SetTrigger("down1");


            }
            else if (gameObject.name == "up")
            {
                rb.GetComponent<Animator>().SetTrigger("up1");

            }
        }
        
        Vector2 test = new Vector2((float)collision.contacts[0].point.x - (float)rb.transform.position.x, (float)collision.contacts[0].point.y - (float)rb.transform.position.y);
        Debug.Log("test"+ (float)test.x *-1) ;

        if (collision.gameObject.tag=="love")
        {
            win_yazisi.SetActive(true);
            Time.timeScale = 0;
        }
        if (rb.transform.eulerAngles.z < 180 && rb.transform.eulerAngles.z >170 || rb.transform.eulerAngles.z < 10 && rb.transform.eulerAngles.z > 0)
        {

        }
        else
        {
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
                var speed2 = lastvelo.magnitude;
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2((float)test.x, (float)test.y) *-1 * Mathf.Max(speed2, 1000f));
            //if (collision.transform.tag=="bulut")
            //{

            //}
            //else
            //{
            //    gameObject.GetComponent<AudioSource>().Play();
            //    float aci;
            //    z = cubuk.transform.eulerAngles.z;
            ////if (z > 180)
            ////{
            ////    z = 180 - cubuk.transform.eulerAngles.z;
            ////}
            //aci = rb.transform.eulerAngles.z - 180;

            //    var direction = new Vector2(Mathf.Cos(z * Mathf.Deg2Rad), Mathf.Sin(z * Mathf.Deg2Rad));
            //    if (Mathf.RoundToInt(collision.contacts[0].normal.y) == 1)
            //    {
            //        direction.y = Mathf.Abs(direction.y);
            //        rb.velocity = Vector2.zero;
            //        rb.AddForce(direction * Mathf.Max(speed2, 750f));
            //    }
            //    else if (Mathf.RoundToInt(collision.contacts[0].normal.x) == 1)
            //    {
            //        if (z < 95 && z > 85)
            //        {
            //            var direction2 = Vector3.Reflect(lastvelo.normalized, collision.contacts[0].normal);
            //            rb.velocity = Vector2.zero;
            //            rb.AddForce(direction2 * Mathf.Max(speed2, 250f)); /* normal bounce sekmesi */
            //        }
            //        else
            //        {
            //            // yukarı, aşağı sekmesi gibi
            //            if (z < 90)
            //            {

            //                direction.x = Mathf.Abs(direction.x);
            //                rb.velocity = Vector2.zero;
            //                rb.AddForce(direction * Mathf.Max(speed2, 750f));
            //            }
            //            else
            //            {
            //                //Debug.LogError(direction.x);
            //                direction.x = Mathf.Abs(direction.x);
            //                //Debug.LogError(direction.x);

            //                direction.y = Mathf.Abs(direction.y) * -1;
            //                rb.velocity = Vector2.zero;
            //                rb.AddForce(direction * Mathf.Max(speed2, 750f));

            //            }
            //        }


            //    }
            //    else if (Mathf.RoundToInt(collision.contacts[0].normal.y) == -1)
            //    {

            //    direction.y = Mathf.Abs(direction.y) * -1;
            //    direction.x = Mathf.Abs(direction.x) * -1;
            //    rb.velocity = Vector2.zero;
            //    Debug.Log("direction=" + direction);

            //    rb.AddForce(direction * Mathf.Max(speed2, 750f));
            //    }
            //    else if (Mathf.RoundToInt(collision.contacts[0].normal.x) == -1)
            //    {
            //        if (z < 95 && z > 85)
            //        {
            //            var direction2 = Vector3.Reflect(lastvelo.normalized, collision.contacts[0].normal);
            //            rb.velocity = Vector2.zero;
            //            rb.AddForce(direction2 * Mathf.Max(speed2, 250f));
            //        }
            //        else
            //        {
            //            if (z > 90)
            //            {
            //                direction.x = Mathf.Abs(direction.x) * -1;
            //                rb.velocity = Vector2.zero;
            //                rb.AddForce(direction * Mathf.Max(speed2, 750f));
            //            }
            //            else
            //            {
            //                direction.x = Mathf.Abs(direction.x) * -1;
            //                direction.y = Mathf.Abs(direction.y) * -1;
            //                rb.velocity = Vector2.zero;
            //                rb.AddForce(direction * Mathf.Max(speed2, 750f));

            //            }
            //        }


            //    }
            ////}




        }

        //gameObject.GetComponentInParent<Animator>().SetBool("hit", false);
    }



}

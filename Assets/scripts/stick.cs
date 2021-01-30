using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stick : MonoBehaviour
{
    public bool BannerYokEt = false;
    public int olumSayisi = 0;
    private Rigidbody2D rb;
    public int speed;
    public float speed2;
    public GameObject win_yazisi;
    public int reverse;
    public GameObject vucut;

    string App_ID = "ca-app-pub-4036017402303426~5272198352";
    string interstitial_Ad_ID = "ca-app-pub-4036017402303426/8956809416";
    string banner_Ad_ID = "ca-app-pub-4036017402303426/1389050822";

    private InterstitialAd interstitial;
    private BannerView bannerView;



    // Start is called before the first frame update
    void Start()
    {
        BannerYokEt = false;
        MobileAds.Initialize(App_ID);
        RequestInterstitial();
        RequestBanner();
        if (SceneManager.GetActiveScene().buildIndex == 17)
        {
            reverse = 1;
        }
        else
        {
            reverse = 0;
        }

        if (SceneManager.GetActiveScene().buildIndex == 18)
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = -1;

        }
        rb = GetComponent<Rigidbody2D>();
        speed = 150;
        StartCoroutine(bannerShow());
    }


    public void RequestBanner()
    {
        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(banner_Ad_ID, AdSize.Banner, AdPosition.Top);

    }

    public void ShowBannerAD()
    {
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
    }

    IEnumerator bannerShow()
    {
        yield return new WaitForSeconds(2);
        ShowBannerAD();
    }


    public void RequestInterstitial()
    {
        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(interstitial_Ad_ID);

        this.interstitial.LoadAd(this.CreateAdRequest());


    }

    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder().Build();
    }

    public void showIad()
    {

        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
    }
    public void menu()
    {
        destroyBanner();
        SceneManager.LoadScene("menu");
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(BannerYokEt);
        if (BannerYokEt==true)
        {
            destroyBanner();
            BannerYokEt = false;
        }
        Debug.Log(olumSayisi);
        if (olumSayisi == 6)
        {
            olumSayisi = 0;
            showIad();
            RequestInterstitial();

        }
        //var x = Mathf.Clamp(transform.position.x, -Camera.main.orthographicSize / 2 + 0.4f, Camera.main.orthographicSize / 2 - 0.4f);
        if (transform.position.x<-3.5f)
        {
            transform.position = new Vector3(-3.5f, transform.position.y, transform.position.z);
        }

        if (SceneManager.GetActiveScene().buildIndex>4)
        {
            if (transform.position.y<-10)
            {
                olumSayisi += 1;
                gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                transform.position = Vector3.zero;
                Vector3 eulerRotation = transform.rotation.eulerAngles;
                transform.rotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 90);
            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 18)
        {
            if (transform.position.y > 33)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                transform.position = Vector3.zero;
                Vector3 eulerRotation = transform.rotation.eulerAngles;
                transform.rotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 90);
            }
        }
        //transform.position = new Vector3(x, transform.position.y, transform.position.z);
        rb.angularVelocity = 0;


        //if (rb.velocity.magnitude < 8)
        //{
        //    if (Input.GetKey(KeyCode.A))
        //    {
        //        transform.Rotate(-Vector3.back * speed * Time.deltaTime);
        //    }
        //    if (Input.GetKey(KeyCode.D))
        //    {

        //        transform.Rotate(Vector3.back * speed * Time.deltaTime);
        //    }
        //}

        if (rb.velocity.magnitude < 10)
        {

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(-Vector3.back * speed * Time.deltaTime);
                vucut.transform.Rotate(-Vector3.back * speed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(Vector3.back * speed * Time.deltaTime);
                vucut.transform.Rotate(Vector3.back * speed * Time.deltaTime);
            }
            //if (Input.GetMouseButton(0))
            //{
            //    if (reverse ==0)
            //    {
            //        if (Input.mousePosition.x < Screen.width / 2)
            //        {
            //            transform.Rotate(-Vector3.back * speed * Time.deltaTime);
            //            vucut.transform.Rotate(-Vector3.back * speed * Time.deltaTime);

            //        }
            //        else if (Input.mousePosition.x > Screen.width / 2)
            //        {
            //            transform.Rotate(Vector3.back * speed * Time.deltaTime);
            //            vucut.transform.Rotate(Vector3.back * speed * Time.deltaTime);

            //        }
            //    }
            //    else if (reverse==1)
            //    {
            //        if (Input.mousePosition.x < Screen.width / 2)
            //        {
            //            transform.Rotate(Vector3.back * speed * Time.deltaTime);
            //            vucut.transform.Rotate(Vector3.back * speed * Time.deltaTime);
            //        }
            //        else if (Input.mousePosition.x > Screen.width / 2)
            //        {
            //            transform.Rotate(-Vector3.back * speed * Time.deltaTime);
            //            vucut.transform.Rotate(-Vector3.back * speed * Time.deltaTime);
            //        }
            //    }

            //}

        }

        

    }

    public void destroyBanner()
    {
        bannerView.Destroy();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag=="portal")
        {
            destroyBanner();
        }
        if (SceneManager.GetActiveScene().buildIndex==17)
        {
            if (collision.transform.tag == "reverseCard")
            {

                if (reverse == 0)
                {
                    reverse = 1;
                }
                else
                {
                    reverse = 0;
                }
                Destroy(collision.gameObject);

            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 18)
        {
            if (collision.transform.tag == "reverseCard")
            {
                if (gameObject.GetComponent<Rigidbody2D>().gravityScale == 1)
                {
                    gameObject.GetComponent<Rigidbody2D>().gravityScale = -1;
                }
                else
                {
                    gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                }
                Destroy(collision.gameObject);

            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.GetComponent<AudioSource>().Play();

        if (collision.gameObject.tag == "love")
        {
            win_yazisi.SetActive(true);
            Time.timeScale = 0;
        }
    }
}

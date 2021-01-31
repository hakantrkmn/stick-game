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
    public int reverse;
    public GameObject vucut;
    public float yAxisVeloLimit;

    string App_ID = "ca-app-pub-4036017402303426~5272198352";
    string interstitial_Ad_ID = "ca-app-pub-4036017402303426/8956809416";
    string banner_Ad_ID = "ca-app-pub-4036017402303426/1389050822";

    private InterstitialAd interstitial;
    private BannerView bannerView;

    void Start()
    {
        yAxisVeloLimit = -7;
        //reklamı oluştur gösterilmesi için beklet

        //BannerYokEt = false;
        //MobileAds.Initialize(App_ID);
        //RequestInterstitial();
        //RequestBanner();

        //level 17 ise kontrolu  ters çevirecek değişkeni 1 yap
        if (SceneManager.GetActiveScene().buildIndex == 17)
        {
            reverse = 1;
        }
        else
        {
            reverse = 0;
        }

        //level 18 ise gravity terse çevir
        if (SceneManager.GetActiveScene().buildIndex == 18)
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = -1;

        }
        
        rb = GetComponent<Rigidbody2D>();
        //çubuğun dönme hızı
        speed = 150;
        StartCoroutine(bannerShow());
    }


    public void RequestBanner()
    {
        this.bannerView = new BannerView(banner_Ad_ID, AdSize.Banner, AdPosition.Top);
    }

    public void ShowBannerAD()
    {
        AdRequest request = new AdRequest.Builder().Build();
        this.bannerView.LoadAd(request);
    }

    IEnumerator bannerShow()
    {
        yield return new WaitForSeconds(2);
        ShowBannerAD();
    }

    public void RequestInterstitial()
    {
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

    //sağ üstteki çarpı tuşunun menuye gönderme işlemi
    public void menu()
    {
        destroyBanner();
        SceneManager.LoadScene("menu");
    }

    void Update()
    {
        if (gameObject.GetComponent<Rigidbody2D>().velocity.y<yAxisVeloLimit )
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x,yAxisVeloLimit);
        }

        if (BannerYokEt==true)
        {
            destroyBanner();
            BannerYokEt = false;
        }
        //6 kere ölünmüşse reklamı göster
        if (olumSayisi == 6)
        {
            olumSayisi = 0;
            showIad();
            RequestInterstitial();
        }
        //oyuncu bölge sınırlama
        if (transform.position.x<-3.5f)
        {
            transform.position = new Vector3(-3.5f, transform.position.y, transform.position.z);
        }

        //oyuncu y bölge sınırlama
        if (transform.position.y<-10)
        {
            olumSayisi += 1;
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            transform.position = Vector3.zero;
            Vector3 eulerRotation = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 90);
        }
        
        //18. level ters olduğu için y  bölge sınırlama
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
        //çubuğun dönme ivmesini sıfırlama
        rb.angularVelocity = 0;

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
            if (Input.GetMouseButton(0))
            {
                if (reverse == 0)
                {
                    if (Input.mousePosition.x < Screen.width / 2)
                    {
                        transform.Rotate(-Vector3.back * speed * Time.deltaTime);
                        vucut.transform.Rotate(-Vector3.back * speed * Time.deltaTime);
                    }
                    else if (Input.mousePosition.x > Screen.width / 2)
                    {
                        transform.Rotate(Vector3.back * speed * Time.deltaTime);
                        vucut.transform.Rotate(Vector3.back * speed * Time.deltaTime);
                    }
                }
                else if (reverse == 1)
                {
                    if (Input.mousePosition.x < Screen.width / 2)
                    {
                        transform.Rotate(Vector3.back * speed * Time.deltaTime);
                        vucut.transform.Rotate(Vector3.back * speed * Time.deltaTime);
                    }
                    else if (Input.mousePosition.x > Screen.width / 2)
                    {
                        transform.Rotate(-Vector3.back * speed * Time.deltaTime);
                        vucut.transform.Rotate(-Vector3.back * speed * Time.deltaTime);
                    }
                }
            }
        }
    

    public void destroyBanner()
    {
        bannerView.Destroy();
    }

    //cubuğa bişe değerse
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
    }
}

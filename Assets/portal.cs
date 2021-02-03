using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class portal : MonoBehaviour
{
    public GameObject music;
    // Start is called before the first frame update
    void Start()
    {

        if (!GameObject.Find("gameMusic(Clone)"))
        {
            Instantiate(music);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        PlayerPrefs.SetFloat("level" + SceneManager.GetActiveScene().buildIndex, 1);
        PlayerPrefs.SetFloat("level" + (SceneManager.GetActiveScene().buildIndex + 1), 1);
        GameObject.Find("cbk").gameObject.SetActive(false);
        GameObject.Find("vucut").gameObject.SetActive(false);
        //GameObject.Find("cbk").GetComponent<stick>().BannerYokEt = true;
        GameObject.Find("Image").GetComponent<Animator>().SetBool("next_level", true);
        StartCoroutine(loadScene());
    }
    IEnumerator loadScene()
    {
        yield return new WaitForSeconds(1);
        var y = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(y + 1);
    }
}

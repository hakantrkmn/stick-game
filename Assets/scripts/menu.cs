using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
    public GameObject howto;
    public GameObject cubuk;
    public GameObject howto_yazi;
    public GameObject fade;
    public GameObject panel;
    public GameObject devamEtButton;
    public Image muteButton;
    public Sprite sound;
    public Sprite mutesound;
    // Start is called before the first frame update
    void Start()
    {

        if (PlayerPrefs.GetFloat("sound")==0)
        {
            muteButton.sprite = mutesound;
        }
        else
        {
            muteButton.sprite = sound;
        }
        if (PlayerPrefs.HasKey("level1"))
        {
            devamEtButton.SetActive(true);
        }
    }

    public void loadLevel1()
    {
        if (PlayerPrefs.HasKey("level1"))
        {
            if (PlayerPrefs.GetFloat("level1")==1)
            {
                StartCoroutine(loadlevel("level_1"));
            }
        }
    }
    public void loadLevel2()
    {
        if (PlayerPrefs.HasKey("level2"))
        {
            if (PlayerPrefs.GetFloat("level2") == 1)
            {
                StartCoroutine(loadlevel("level_2"));
            }
        }
    }
    public void loadLevel3()
    {
        if (PlayerPrefs.HasKey("level3"))
        {
            if (PlayerPrefs.GetFloat("level3") == 1)
            {
                StartCoroutine(loadlevel("level_3"));
            }
        }
    }
    public void loadLevel4()
    {
        if (PlayerPrefs.HasKey("level4"))
        {
            if (PlayerPrefs.GetFloat("level4") == 1)
            {
                StartCoroutine(loadlevel("level_4"));
            }
        }
    }
    public void loadLevel5()
    {
        if (PlayerPrefs.HasKey("level5"))
        {
            if (PlayerPrefs.GetFloat("level5") == 1)
            {
                StartCoroutine(loadlevel("level_5"));
            }
        }
    }
    public void loadLevel6()
    {
        if (PlayerPrefs.HasKey("level6"))
        {
            if (PlayerPrefs.GetFloat("level6") == 1)
            {
                StartCoroutine(loadlevel("level_6"));
            }
        }
    }
    public void loadLevel7()
    {
        if (PlayerPrefs.HasKey("level7"))
        {
            if (PlayerPrefs.GetFloat("level7") == 1)
            {
                StartCoroutine(loadlevel("level_7"));
            }
        }
    }

    public void loadLevel8()
    {
        if (PlayerPrefs.HasKey("level8"))
        {
            if (PlayerPrefs.GetFloat("level8") == 1)
            {
                StartCoroutine(loadlevel("level_8"));
            }
        }
    }

    public void loadLevel9()
    {
        if (PlayerPrefs.HasKey("level9"))
        {
            if (PlayerPrefs.GetFloat("level9") == 1)
            {
                StartCoroutine(loadlevel("level_9"));
            }
        }
    }

    public void loadLevel10()
    {
        if (PlayerPrefs.HasKey("level10"))
        {
            if (PlayerPrefs.GetFloat("level10") == 1)
            {
                StartCoroutine(loadlevel("level_10"));
            }
        }
    }
    public void loadLevel11()
    {
        if (PlayerPrefs.HasKey("level11"))
        {
            if (PlayerPrefs.GetFloat("level11") == 1)
            {
                StartCoroutine(loadlevel("level_11"));
            }
        }
    }
    public void loadLevel12()
    {
        if (PlayerPrefs.HasKey("level12"))
        {
            if (PlayerPrefs.GetFloat("level12") == 1)
            {
                StartCoroutine(loadlevel("level_12"));
            }
        }
    }
    public void loadLevel13()
    {
        if (PlayerPrefs.HasKey("level13"))
        {
            if (PlayerPrefs.GetFloat("level13") == 1)
            {
                StartCoroutine(loadlevel("level_13"));
            }
        }
    }
    public void loadLevel14()
    {
        if (PlayerPrefs.HasKey("level14"))
        {
            if (PlayerPrefs.GetFloat("level14") == 1)
            {
                StartCoroutine(loadlevel("level_14"));
            }
        }
    }

    public void loadLevel15()
    {
        if (PlayerPrefs.HasKey("level15"))
        {
            if (PlayerPrefs.GetFloat("level15") == 1)
            {
                StartCoroutine(loadlevel("level_15"));
            }
        }
    }
    public void loadLevel16()
    {
        if (PlayerPrefs.HasKey("level16"))
        {
            if (PlayerPrefs.GetFloat("level16") == 1)
            {
                StartCoroutine(loadlevel("level_16"));
            }
        }
    }
    public void loadLevel17()
    {
        if (PlayerPrefs.HasKey("level17"))
        {
            if (PlayerPrefs.GetFloat("level17") == 1)
            {
                StartCoroutine(loadlevel("level_17"));
            }
        }
    }
    public void loadLevel18()
    {
        if (PlayerPrefs.HasKey("level18"))
        {
            if (PlayerPrefs.GetFloat("level18") == 1)
            {
                StartCoroutine(loadlevel("level_18"));
            }
        }
    }
    public void loadLevel19()
    {
        if (PlayerPrefs.HasKey("level19"))
        {
            if (PlayerPrefs.GetFloat("level19") == 1)
            {
                StartCoroutine(loadlevel("level_19"));
            }
        }
    }
    public void loadLevel20()
    {
        if (PlayerPrefs.HasKey("level20"))
        {
            if (PlayerPrefs.GetFloat("level20") == 1)
            {
                StartCoroutine(loadlevel("level_20"));
            }
        }
    }




    // Update is called once per frame
    void Update()
    {

    }
    public void play()
    {
        StartCoroutine(loadlevel("level_1"));
    }

    public void nasiloynanir()
    {
        howto_yazi.GetComponent<Animator>().SetBool("button_pressed",true);
    }
    public void nasiloynanirExit()
    {
        howto_yazi.GetComponent<Animator>().SetBool("button_pressed", false);
    }

    public void showLevels()
    {
        panel.SetActive(true);
    }

    public void back()
    {
        panel.SetActive(false);

    }
    public void muteSound()
    {
        if(muteButton.sprite.name=="sound")
        {
            muteButton.sprite = mutesound;
            PlayerPrefs.SetFloat("sound", 0);
        }
        else
        {
            muteButton.sprite= sound;
            PlayerPrefs.SetFloat("sound", 0.3f);
        }
    }

    IEnumerator cik()
    {
        yield return new WaitForSecondsRealtime(2.5f);
        cubuk.SetActive(true);
    }

    IEnumerator loadlevel(string lvlname)
    {
        fade.GetComponent<Animator>().SetBool("next_level", true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(lvlname);
    }

    public void devamEt()
    {
        for (int i = 20; i > 0; i--)
        {
            if (PlayerPrefs.HasKey("level"+i))
            {
                if (PlayerPrefs.GetFloat("level"+i) == 1)
                {
                    StartCoroutine(loadlevel("level_"+ i));
                    return;
                }
            }
        }
    }
}

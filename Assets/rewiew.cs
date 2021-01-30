using Google.Play.Review;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rewiew : MonoBehaviour
{
    ReviewManager reviewManager;

    IEnumerator rewiev()
    {
        yield return new WaitForSeconds(2);
        var requestFlowOperation = reviewManager.RequestReviewFlow();
        yield return requestFlowOperation;
        if (requestFlowOperation.Error != ReviewErrorCode.NoError)
        {
            Debug.Log(requestFlowOperation.Error.ToString());
            // Log error. For example, using requestFlowOperation.Error.ToString().
            yield break;
        }
        PlayReviewInfo _playReviewInfo = requestFlowOperation.GetResult();
        var launchFlowOperation = reviewManager.LaunchReviewFlow(_playReviewInfo);
        yield return launchFlowOperation;
        _playReviewInfo = null; // Reset the object
        if (launchFlowOperation.Error != ReviewErrorCode.NoError)
        {
            Debug.Log(requestFlowOperation.Error.ToString());
            // Log error. For example, using requestFlowOperation.Error.ToString().
            yield break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("rate"));
        if (PlayerPrefs.GetInt("rate")==1)
        {
            Destroy(GameObject.Find("rate"));
        }
        reviewManager = new ReviewManager();

        StartCoroutine(rewiev());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void oyVer()
    {
        PlayerPrefs.SetInt("rate", 1);
        Application.OpenURL("market://details?id=com.efoligames.TheStickGame");
        Destroy(GameObject.Find("rate"));
    }
    public void oyVer2()
    {
        Destroy(GameObject.Find("rate"));
    }
}

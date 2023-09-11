using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI loadingText;

    private void Start()
    {
        if (PlayerPrefs.HasKey("LevelIndex") == false)
        {
            PlayerPrefs.SetInt("LevelIndex", 1);
            StartCoroutine(Loading());
        }  
        LevelControl();
    }

    public void LevelControl()
    {
        int level = PlayerPrefs.GetInt("LevelIndex");
        SceneManager.LoadSceneAsync(level);
    }

    public IEnumerator Loading()
    {
        while (true)
        {
            loadingText.text = "Loading".ToString();
            yield return new WaitForSecondsRealtime(.2f);          
            loadingText.text = "Loading.".ToString();
            yield return new WaitForSecondsRealtime(.2f);
            loadingText.text = "Loading..".ToString();
            yield return new WaitForSecondsRealtime(.2f);
            loadingText.text = "Loading...".ToString();
        }
    }
}

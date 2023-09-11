using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public SoundManager soundManager;

    [Header("Images")]    
    [SerializeField] Image whiteEffectImage;
    [SerializeField] Image fillRateImage;

    private bool isWhiteScreenShowing = false;
    private bool isInformationPanelOpened = true;
     
    [Header("Animators")]
    [SerializeField] Animator LayoutGroupAnimator; 
    [SerializeField] Animator InformationPanelAnimator;

    [Header("GameObjects")]
    [SerializeField] GameObject settingsButtonOpen;
    [SerializeField] GameObject settingsButtonClose; 
    [SerializeField] GameObject layoutBackground;
    [SerializeField] GameObject soundOn;
    [SerializeField] GameObject soundOff;
    [SerializeField] GameObject vibrationOn;
    [SerializeField] GameObject vibrationOff;
    [SerializeField] GameObject iap;
    [SerializeField] GameObject info;
    [SerializeField] GameObject cancelButton;
    [SerializeField] GameObject informationPanel;
    [SerializeField] GameObject restartScreen;
    [SerializeField] GameObject handSlide;
    [SerializeField] GameObject tapToMove;
    [SerializeField] GameObject noAds;
    [SerializeField] GameObject market;
    [SerializeField] GameObject levelsButton;
    [SerializeField] GameObject finishScreen;
    [SerializeField] GameObject finishScreenBackground;
    [SerializeField] GameObject completed;
    [SerializeField] GameObject totalCoin;
    [SerializeField] GameObject totalCoinText;
    [SerializeField] GameObject nextLevelButton;
    [SerializeField] GameObject player;
    [SerializeField] GameObject finishLine;
    [SerializeField] GameObject tutorialScreen;
    [SerializeField] GameObject tutorialScreenBackground;
    [SerializeField] GameObject tutorialScreenInfoText;
    [SerializeField] GameObject tutorialScreenAcceptButton;

    [Header("Texts")]
    [SerializeField] Text coinText;
    [SerializeField] TextMeshProUGUI tutorialScreenInformationText;
    
    private void Start()
    {
        if (!PlayerPrefs.HasKey("Sound"))
        {
            PlayerPrefs.SetInt("Sound",1);
        }
        if (PlayerPrefs.HasKey("Vibration") == false) // Vibration adýnda bir key oluþtur ve buna 1 atamasý yap
        {
            PlayerPrefs.SetInt("Vibration",1);
        }
        if (PlayerPrefs.HasKey("noAds") == false)
        {
            PlayerPrefs.SetInt("noAds", 0);
        }

        if (PlayerPrefs.GetInt("noAds") == 1)
        {
            NoAdsRemove();
        }

        CoinTextUpdate();
    }

    private void Update()
    {
        fillRateImage.fillAmount = ((player.transform.position.z) / (finishLine.transform.position.z));
    }

    public void FirstTouch()
    {
        settingsButtonOpen.SetActive(false);
        settingsButtonClose.SetActive(false);
        layoutBackground.SetActive(false);
        soundOn.SetActive(false);
        soundOff.SetActive(false);
        vibrationOn.SetActive(false);
        vibrationOff.SetActive(false);
        iap.SetActive(false);
        info.SetActive(false);
        cancelButton.SetActive(false);
        informationPanel.SetActive(false);
        handSlide.SetActive(false);
        tapToMove.SetActive(false);
        noAds.SetActive(false);
        market.SetActive(false);
        levelsButton.SetActive(false);
    }

    public void NoAdsRemove()
    {
        noAds.SetActive(false);
    }

    public void TutorialSkipButton()
    {
        Variables.firstTouch = 1;
        tutorialScreen.SetActive(false);
        player.GetComponent<Rigidbody>().freezeRotation = false;
    }

    public void TutorialScreenOpener()
    {
        StartCoroutine(TutorialScreenShowing());        
    }

    public IEnumerator TutorialScreenShowing()
    {
        string baseMessage = "To complete sections";
        string additionalMessage = " avoid obstacles that are different colors from your ball.";
        string fullMessage = baseMessage + "\n\n" + additionalMessage;

        tutorialScreen.SetActive(true);
        tutorialScreenBackground.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        tutorialScreenInfoText.SetActive(true);

        for (int i = 1; i <= fullMessage.Length; i++)
        {
            tutorialScreenInformationText.text = fullMessage.Substring(0, i);
            yield return new WaitForSecondsRealtime(.03f);
        }
        yield return new WaitForSecondsRealtime(1f);
        tutorialScreenAcceptButton.SetActive(true);
    }


    public void RestartScreenActive()
    {
        restartScreen.SetActive(true);
    }

    public void RestartSceneButton() 
    {
        Variables.firstTouch = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);       
    }

    public void NextScene()
    {
        Variables.firstTouch = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //Eðer 10. levelda isek next tuþuna bastýðýmýzda 11. level'a geçmek yerine tekrardan 1. Level'a dönecek
        if (SceneManager.GetActiveScene().buildIndex == 19)
        {
            SceneManager.LoadScene("Level_1");
        }
    }

    public void FinishScreen()
    {
        StartCoroutine(FinishScreenCoroutine());
    }  
    

    

    public IEnumerator FinishScreenCoroutine()
    {
        finishScreen.SetActive(true);
        finishScreenBackground.SetActive(true);
        completed.SetActive(true);
        soundManager.FinishSound();
        yield return new WaitForSecondsRealtime(.4f);
        totalCoin.SetActive(true);
        totalCoinText.SetActive(true);
        yield return new WaitForSecondsRealtime(1.5f);
        nextLevelButton.SetActive(true);
        soundManager.NextLevelActiveSound();
    }


    public void InfoButton()
    {
        
        if (isInformationPanelOpened)
        {
            informationPanel.SetActive(true);
            InformationPanelAnimator.SetTrigger("Open");
            
        }
        isInformationPanelOpened = false;
    }

    public void CancelButton()
    {
        
        if (!isInformationPanelOpened)
        {
            InformationPanelAnimator.SetTrigger("Close");            
            
        }
        isInformationPanelOpened = true;
    }



    public void SettingsButtonOpen()
    {
        settingsButtonOpen.SetActive(false);
        settingsButtonClose.SetActive(true);
        LayoutGroupAnimator.SetTrigger("Open");

        if (PlayerPrefs.GetInt("Sound") == 1)
        {
            soundOn.SetActive(true);
            soundOff.SetActive(false);
            AudioListener.volume = 1;
        }
        else if (PlayerPrefs.GetInt("Sound") == 2)
        {
            soundOn.SetActive(false);
            soundOff.SetActive(true);
            AudioListener.volume = 0;
        }


        if (PlayerPrefs.GetInt("Vibration") == 1)
        {
            vibrationOn.SetActive(true);
            vibrationOff.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Vibration") == 2)
        {
            vibrationOn.SetActive(false);
            vibrationOff.SetActive(true);
        }
    }

    public void SettingsButtonClose()
    {
        settingsButtonOpen.SetActive(true);
        settingsButtonClose.SetActive(false);
        LayoutGroupAnimator.SetTrigger("Close");
    }

    public void SoundOn() //Bastýðýmýzda sesi kapacatak
    {
        soundOn.SetActive(false);
        soundOff.SetActive(true);
        AudioListener.volume = 0;
        PlayerPrefs.SetInt("Sound", 2);
        

    }

    public void SoundOff() // Bastýðýmýzda sesi açacak
    {
        soundOn.SetActive(true);
        soundOff.SetActive(false);
        AudioListener.volume = 1;
        PlayerPrefs.SetInt("Sound", 1);
    }

    public void VibrationOn()  // bastýðýmýzda titreþimi kapatacak
    {
        vibrationOn.SetActive(false);
        vibrationOff.SetActive(true);
        PlayerPrefs.SetInt("Vibration", 2);
       
    }
    
    public void VibrationOff()  // bastýðýmýzda titreþimi açacak
    {
        vibrationOn.SetActive(true);
        vibrationOff.SetActive(false);
        PlayerPrefs.SetInt("Vibration", 1);
    }


    public void PrivacyPolicy()
    {
        Application.OpenURL("https://doc-hosting.flycricket.io/ball-journey-3d-privacy-policy/3bec0584-83a8-490f-b056-952149d1653c/privacy");
    }

    public void TermsAndConditions()
    {
        Application.OpenURL("https://doc-hosting.flycricket.io/ball-journey-3d-terms-of-use/22d68a3b-f22a-4527-ba7c-915676c366a4/terms");
    }




    public IEnumerator WhiteEffect()
    {
        whiteEffectImage.gameObject.SetActive(true);
        while (!isWhiteScreenShowing)
        { 
            yield return new WaitForSeconds(.001f);
            whiteEffectImage.color += new Color(0, 0, 0, .1f);
            if (whiteEffectImage.color == new Color(whiteEffectImage.color.r , whiteEffectImage.color.g, whiteEffectImage.color.b , 1))
            {
                isWhiteScreenShowing = true;  
            }
        }

        while (isWhiteScreenShowing)
        {
            yield return new WaitForSeconds(.001f);
            whiteEffectImage.color -= new Color(0, 0, 0, .1f);

        }
    }

    public void WhiteEffectCaller()
    {
        StartCoroutine(WhiteEffect());
    }

    //Parayý ekranda güncel tutmak için yazýlan fonksiyon
    public void CoinTextUpdate()
    {
        coinText.text = PlayerPrefs.GetInt("Coin").ToString();
    }

}

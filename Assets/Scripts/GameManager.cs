using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] UIManager uiManager;

    public int levelToUnlock;
    int numberOfUnlockedLevels;
   


    private void Start()
    {       
        CoinManager(0);
        Debug.Log(PlayerPrefs.GetInt("Coin"));     
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("FinishZone"))
        {
            int currentLevel = PlayerPrefs.GetInt("LevelIndex");
            int coinReward = CalculateCoinReward(currentLevel);

            CoinManager(coinReward);
            uiManager.CoinTextUpdate();
            uiManager.FinishScreen();
            PlayerPrefs.SetInt("LevelIndex", currentLevel + 1);
            numberOfUnlockedLevels = PlayerPrefs.GetInt("levelsUnlocked");

            if (numberOfUnlockedLevels <= levelToUnlock)
            {
                PlayerPrefs.SetInt("levelsUnlocked", numberOfUnlockedLevels + 1);
            }
        }
    }

    private int CalculateCoinReward(int levelIndex)
    {
        if (levelIndex >= 1 && levelIndex <= 6) //Level 1'den Level 7'ye kadar
            return 500;
        else if (levelIndex >= 7 && levelIndex <= 14) // Level 8'den Level 13'e kadar
            return 600;
        else if (levelIndex >= 15 && levelIndex <= 20) // level 14'den Level 19'a kadar
            return 700;
        else
            return 700; // Default deðer
    }




    public void CoinManager(int money)
    {
        if (PlayerPrefs.HasKey("Coin")) //Coin olup olmadýðýný kontrol et. 
        {
            int oldScore = PlayerPrefs.GetInt("Coin");
            PlayerPrefs.SetInt("Coin", oldScore + money);
        }
        else
            PlayerPrefs.SetInt("Coin", 0);
    }
}

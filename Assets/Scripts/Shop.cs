using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    private UIManager uiManager;
    public SoundManager soundManager;

    [Header("Trails")]
    [SerializeField] GameObject trail_1;
    [SerializeField] GameObject trail_2;
    [SerializeField] GameObject trail_3;
    [SerializeField] GameObject trail_4;
    [SerializeField] GameObject trail_5;
    [SerializeField] GameObject trail_6;
    [SerializeField] GameObject trail_7;

    [Header("Items")]
    [SerializeField] GameObject item_1;
    [SerializeField] GameObject item_2;
    [SerializeField] GameObject item_3;
    [SerializeField] GameObject item_4;
    [SerializeField] GameObject item_5;
    [SerializeField] GameObject item_6;
    [SerializeField] GameObject item_7;

    [Header("Locks")]
    [SerializeField] GameObject item2Lock;
    [SerializeField] GameObject item3Lock;
    [SerializeField] GameObject item4Lock;
    [SerializeField] GameObject item5Lock;
    [SerializeField] GameObject item6Lock;
    [SerializeField] GameObject item7Lock;

    [Header("Sprites")]
    [SerializeField] Sprite yellowImage;
    [SerializeField] Sprite greenImage;

    private void Awake()
    {
        // En son seçmiþ olduðumuz itemin çalýþmasýný saðlayan kayýt sistemi

        if (PlayerPrefs.HasKey("itemSelect") == false)

            PlayerPrefs.SetInt("itemSelect", 0);

        if (PlayerPrefs.GetInt("itemSelect") == 0)   //1. iTEM
            Trail1open();
        else if (PlayerPrefs.GetInt("itemSelect") == 1)
            Trail2open();
        else if (PlayerPrefs.GetInt("itemSelect") == 2 )
            Trail3open();
        else if (PlayerPrefs.GetInt("itemSelect") == 3)
            Trail4open();
        else if (PlayerPrefs.GetInt("itemSelect") == 4)
            Trail5open();
        else if (PlayerPrefs.GetInt("itemSelect") == 5)
            Trail6open();
        else if (PlayerPrefs.GetInt("itemSelect") == 6)
            Trail7open();

        uiManager = GetComponent<UIManager>();

        // Eðer paramýz yeterse ilgili itemin butonunu aktif eden kayýt sistemi

        if (PlayerPrefs.HasKey("Lock2Control") == false) // Eðer lock2control adýnda bir key yoksa oluþtur ve 0 deðerini ata
            PlayerPrefs.SetInt("Lock2Control", 0);

        if (PlayerPrefs.HasKey("Lock3Control") == false)
            PlayerPrefs.SetInt("Lock3Control", 0);

        if (PlayerPrefs.HasKey("Lock4Control") == false)
            PlayerPrefs.SetInt("Lock4Control", 0);

        if (PlayerPrefs.HasKey("Lock5Control") == false)
            PlayerPrefs.SetInt("Lock5Control", 0);

        if (PlayerPrefs.HasKey("Lock6Control") == false)
            PlayerPrefs.SetInt("Lock6Control", 0);

        if (PlayerPrefs.HasKey("Lock7Control") == false)
            PlayerPrefs.SetInt("Lock7Control", 0);


        if (PlayerPrefs.GetInt("Lock2Control") == 1)
            item2Lock.SetActive(false);

        if (PlayerPrefs.GetInt("Lock3Control") == 1)
            item3Lock.SetActive(false);

        if (PlayerPrefs.GetInt("Lock4Control") == 1)
            item4Lock.SetActive(false);

        if (PlayerPrefs.GetInt("Lock5Control") == 1)
            item5Lock.SetActive(false);

        if (PlayerPrefs.GetInt("Lock6Control") == 1)
            item6Lock.SetActive(false);

        if (PlayerPrefs.GetInt("Lock7Control") == 1)
            item7Lock.SetActive(false);

    }

    public void Trail1open()
    {
        trail_1.SetActive(true);
        trail_2.SetActive(false);
        trail_3.SetActive(false);
        trail_4.SetActive(false);
        trail_5.SetActive(false);
        trail_6.SetActive(false);
        trail_7.SetActive(false);

        item_1.GetComponent<Image>().sprite = greenImage; 
        item_2.GetComponent<Image>().sprite = yellowImage;
        item_3.GetComponent<Image>().sprite = yellowImage;
        item_4.GetComponent<Image>().sprite = yellowImage;
        item_5.GetComponent<Image>().sprite = yellowImage;
        item_6.GetComponent<Image>().sprite = yellowImage;
        item_7.GetComponent<Image>().sprite = yellowImage;

        PlayerPrefs.SetInt("itemSelect", 0);

    }

    public void Trail2open()
    {
        trail_1.SetActive(false);
        trail_2.SetActive(true);
        trail_3.SetActive(false);
        trail_4.SetActive(false);
        trail_5.SetActive(false);
        trail_6.SetActive(false);
        trail_7.SetActive(false);


        item_1.GetComponent<Image>().sprite = yellowImage;
        item_2.GetComponent<Image>().sprite = greenImage;       
        item_3.GetComponent<Image>().sprite = yellowImage;
        item_4.GetComponent<Image>().sprite = yellowImage;
        item_5.GetComponent<Image>().sprite = yellowImage;
        item_6.GetComponent<Image>().sprite = yellowImage;
        item_7.GetComponent<Image>().sprite = yellowImage;


        PlayerPrefs.SetInt("itemSelect", 1);

    }

    public void Trail3open()
    {
        trail_1.SetActive(false);
        trail_2.SetActive(false);
        trail_3.SetActive(true);
        trail_4.SetActive(false);
        trail_5.SetActive(false);
        trail_6.SetActive(false);
        trail_7.SetActive(false);

        item_1.GetComponent<Image>().sprite = yellowImage;
        item_2.GetComponent<Image>().sprite = yellowImage;
        item_3.GetComponent<Image>().sprite = greenImage;
        item_4.GetComponent<Image>().sprite = yellowImage;
        item_5.GetComponent<Image>().sprite = yellowImage;
        item_6.GetComponent<Image>().sprite = yellowImage;
        item_7.GetComponent<Image>().sprite =yellowImage;

        PlayerPrefs.SetInt("itemSelect", 2);

    }

    public void Trail4open()
    {
        trail_1.SetActive(false);
        trail_2.SetActive(false);
        trail_3.SetActive(false);
        trail_4.SetActive(true);
        trail_5.SetActive(false);
        trail_6.SetActive(false);
        trail_7.SetActive(false);

        item_1.GetComponent<Image>().sprite = yellowImage;
        item_2.GetComponent<Image>().sprite = yellowImage;
        item_3.GetComponent<Image>().sprite = yellowImage;
        item_4.GetComponent<Image>().sprite = greenImage;
        item_5.GetComponent<Image>().sprite = yellowImage;
        item_6.GetComponent<Image>().sprite = yellowImage;
        item_7.GetComponent<Image>().sprite = yellowImage;

        PlayerPrefs.SetInt("itemSelect", 3);

    }

    public void Trail5open()
    {
        trail_1.SetActive(false);
        trail_2.SetActive(false);
        trail_3.SetActive(false);
        trail_4.SetActive(false);
        trail_5.SetActive(true);
        trail_6.SetActive(false);
        trail_7.SetActive(false);

        item_1.GetComponent<Image>().sprite = yellowImage;
        item_2.GetComponent<Image>().sprite = yellowImage;
        item_3.GetComponent<Image>().sprite = yellowImage;
        item_4.GetComponent<Image>().sprite = yellowImage;
        item_5.GetComponent<Image>().sprite = greenImage;
        item_6.GetComponent<Image>().sprite = yellowImage;
        item_7.GetComponent<Image>().sprite = yellowImage;

        PlayerPrefs.SetInt("itemSelect", 4);
    }

    public void Trail6open()
    {
        trail_1.SetActive(false);
        trail_2.SetActive(false);
        trail_3.SetActive(false);
        trail_4.SetActive(false);
        trail_5.SetActive(false);
        trail_6.SetActive(true);
        trail_7.SetActive(false);

        item_1.GetComponent<Image>().sprite = yellowImage;
        item_2.GetComponent<Image>().sprite = yellowImage;
        item_3.GetComponent<Image>().sprite = yellowImage;
        item_4.GetComponent<Image>().sprite = yellowImage;
        item_5.GetComponent<Image>().sprite = yellowImage;
        item_6.GetComponent<Image>().sprite = greenImage;
        item_7.GetComponent<Image>().sprite = yellowImage;

        PlayerPrefs.SetInt("itemSelect", 5);
    }

    public void Trail7open()
    {
        trail_1.SetActive(false);
        trail_2.SetActive(false);
        trail_3.SetActive(false);
        trail_4.SetActive(false);
        trail_5.SetActive(false);
        trail_6.SetActive(false);
        trail_7.SetActive(true);

        item_1.GetComponent<Image>().sprite = yellowImage;
        item_2.GetComponent<Image>().sprite = yellowImage;
        item_3.GetComponent<Image>().sprite = yellowImage;
        item_4.GetComponent<Image>().sprite = yellowImage;
        item_5.GetComponent<Image>().sprite = yellowImage;
        item_6.GetComponent<Image>().sprite = yellowImage;
        item_7.GetComponent<Image>().sprite = greenImage;

        PlayerPrefs.SetInt("itemSelect", 6);
    }


    public void Lock2open()
    {
        int coin = PlayerPrefs.GetInt("Coin");
        int lock2Control = PlayerPrefs.GetInt("Lock2Control");
        if (coin >= 300 && lock2Control == 0)
        {
            item2Lock.SetActive(false);
            PlayerPrefs.SetInt("Coin", coin - 300);
            PlayerPrefs.SetInt("Lock2Control", 1);
            Trail2open();
            uiManager.CoinTextUpdate(); 
            soundManager.BuySound();
        }
    }

    public void Lock3open()
    {
        int coin = PlayerPrefs.GetInt("Coin");
        int lock3Control = PlayerPrefs.GetInt("Lock3Control");
        if (coin >= 1000 && lock3Control == 0)
        {
            item3Lock.SetActive(false);
            PlayerPrefs.SetInt("Coin", coin - 1000);
            PlayerPrefs.SetInt("Lock3Control", 1);
            Trail3open();
            uiManager.CoinTextUpdate();
            soundManager.BuySound();
        }
    }

    public void Lock4open()
    {
        int coin = PlayerPrefs.GetInt("Coin");
        int lock4Control = PlayerPrefs.GetInt("Lock4Control");
        if (coin >= 2000 && lock4Control == 0)
        {
            item4Lock.SetActive(false);
            PlayerPrefs.SetInt("Coin", coin - 2000);
            PlayerPrefs.SetInt("Lock4Control", 1);
            Trail4open();
            uiManager.CoinTextUpdate();
            soundManager.BuySound();
        }
    }

    public void Lock5open()
    {
        int coin = PlayerPrefs.GetInt("Coin");
        int lock5Control = PlayerPrefs.GetInt("Lock5Control");
        if (coin >= 2500 && lock5Control == 0)
        {
            item5Lock.SetActive(false);
            PlayerPrefs.SetInt("Coin", coin - 2500);
            PlayerPrefs.SetInt("Lock5Control", 1);
            Trail5open();
            uiManager.CoinTextUpdate();
            soundManager.BuySound();
        }
    }

    public void Lock6open()
    {
        int coin = PlayerPrefs.GetInt("Coin");
        int lock6Control = PlayerPrefs.GetInt("Lock6Control");
        if (coin >= 2500 && lock6Control == 0)
        {
            item6Lock.SetActive(false);
            PlayerPrefs.SetInt("Coin", coin - 2500);
            PlayerPrefs.SetInt("Lock6Control", 1);
            Trail6open();
            uiManager.CoinTextUpdate();
            soundManager.BuySound();
        }
    }

    public void Lock7open()
    {
        int coin = PlayerPrefs.GetInt("Coin");
        int lock7Control = PlayerPrefs.GetInt("Lock7Control");
        if (coin >= 2500 && lock7Control == 0)
        {
            item7Lock.SetActive(false);
            PlayerPrefs.SetInt("Coin", coin - 2500);
            PlayerPrefs.SetInt("Lock7Control", 1);
            Trail7open();
            uiManager.CoinTextUpdate();
            soundManager.BuySound();
        }
    }

    
}

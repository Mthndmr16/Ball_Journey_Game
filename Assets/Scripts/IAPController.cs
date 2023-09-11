using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using System;
using UnityEngine.Purchasing.Extension;

public class IAPController : MonoBehaviour  , IStoreListener
{
    public UIManager uiManager;
    IStoreController controller;

    [SerializeField] string[] product;

    
    public void Awake()
    {
        IAPStart();
    }

    
    private void IAPStart()
    {
        var module = StandardPurchasingModule.Instance();
      ConfigurationBuilder builder = ConfigurationBuilder.Instance(module);

        foreach (string item in product)
        {
            builder.AddProduct(item, ProductType.Consumable); //Sadece 1 kere satýn alýnabilir.
        }

        UnityPurchasing.Initialize(this, builder);
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        this.controller = controller;
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("Initialize Failed");
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        Debug.Log("Initialize Failed");
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log("Purchasing Failed");
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e)
    {
        if (string.Equals(e.purchasedProduct.definition.id, product[0],StringComparison.Ordinal)) // Pack1
        {
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 300);  
            uiManager.CoinTextUpdate();
           return PurchaseProcessingResult.Complete; 
        }
        else if (string.Equals(e.purchasedProduct.definition.id, product[1], StringComparison.Ordinal)) // Pack2
        {
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 700);
            uiManager.CoinTextUpdate();
            return PurchaseProcessingResult.Complete;
        }
        else if (string.Equals(e.purchasedProduct.definition.id, product[2], StringComparison.Ordinal)) // Pack3
        {
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 1000);
            uiManager.CoinTextUpdate();
            return PurchaseProcessingResult.Complete;
        }
        else if (string.Equals(e.purchasedProduct.definition.id, product[3], StringComparison.Ordinal)) // Reklam Kaldýrma
        {
            if (PlayerPrefs.HasKey("noAds") == true)
            {
                PlayerPrefs.SetInt("noAds", 1); 
                uiManager.NoAdsRemove();
            }
            return PurchaseProcessingResult.Complete;
        }
        else
        {
            return PurchaseProcessingResult.Pending;
        }
    }

    public void IAPButton(string id)
    {
        Product product = controller.products.WithID(id);
        if (product != null && product.availableToPurchase)
        {
           controller.InitiatePurchase(product);
            Debug.Log("Buying");
        }
        else
        {
            Debug.Log("Not Buying");
        }
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureDescription failureDescription)
    {
        Debug.Log("Purchasing Failed");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager instance;

    void Awake()
    {
        instance = this;
    }

    // Oyun sahnelerini temsil eden enum yap�s�
    public enum Scene
    {
        Level_1, Level_2, Level_3, Level_4, Level_5, Level_6, Level_7, Level_8, Level_9, Level_10,
        Level_11, Level_12, Level_13, Level_14, Level_15, Level_16, Level_17, Level_18, Level_19, Level_20
    }

    // Enum'da tan�t�lan sahnelerin ad�yla sahneyi y�kleme fonksiyonu
    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());    
    }

    // Numaras� verilen seviyeyi y�kleme fonksiyonu
    public void LoadLevel(int level)
    {
        Scene sceneToLoad = (Scene)level; // Tam say�y� Scene enum'una d�n��t�r. 0 dan ba�lar. index gibi. Yani 0 = Level_1, 1=Level_2....


        LoadScene(sceneToLoad);


    }

}

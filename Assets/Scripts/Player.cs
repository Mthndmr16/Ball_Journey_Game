using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject[] cells;
    public CameraController controller;
    public UIManager uimanager;
    public SoundManager soundManager;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject vectorBack;
    [SerializeField] private GameObject vectorForward;
    private Rigidbody rb;
    private Touch touch;
    [Range(0,100)] [SerializeField] private int speed;
    [SerializeField] private float forwardSpeed;

    //�arp��malarda kapatmak i�in kullanaca��z
    [SerializeField] private GameObject fireBallOrange;
    [SerializeField] private GameObject fireBallGreen;
    [SerializeField] private GameObject fireBallBlue;

    private bool isBallMovingForward = false;
    private bool firstTouchControl = false;

    private int soundLimitCount;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Variables.firstTouch == 1 && !isBallMovingForward)
        {
            transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
            vectorBack.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
            vectorForward.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
        }

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) //E�er parma��m�z �uan alta yazaca��m�z gameobject'lerin �zerinde de�ilse 
                {
                    if (!firstTouchControl)
                    {
                        Variables.firstTouch = 1;
                        uimanager.FirstTouch();
                        firstTouchControl = true;
                    }                 
                }
            }
            else if (touch.phase == TouchPhase.Moved)
            {            
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) //E�er parma��m�z �uan alta yazaca��m�z gameobject'lerin �zerinde de�ilse 
                {
                    rb.velocity = new Vector3(touch.deltaPosition.x * speed * Time.deltaTime,
                         transform.position.y,
                         touch.deltaPosition.y * speed * Time.deltaTime);

                    if (!firstTouchControl)
                    {
                        Variables.firstTouch = 1;
                        uimanager.FirstTouch();
                        firstTouchControl = true;
                    }
                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                rb.velocity = Vector3.zero;
            }
        }
    }

    

    private void OnCollisionEnter(Collision hit)
    {  
        if (hit.gameObject.CompareTag("Obstacle"))
        {
            controller.Shaker();
            uimanager.WhiteEffectCaller();
            soundManager.PlayerBlowSound();
            if (PlayerPrefs.GetInt("Vibration") == 1)
            {
                Vibration.Vibrate(50);
            }
            else if (PlayerPrefs.GetInt("Vibration") == 2)
            {
                Debug.Log("Titre�im kapal�");
            }
            gameObject.transform.GetChild(0).gameObject.SetActive(false);  // Sphere objesini yapat�yor.
            foreach (GameObject piece in cells) // Topun her bir par�as�na eri�iyoruz
            {
                piece.GetComponent<SphereCollider>().enabled = true;  // Her birinin Collider'� ba�ta kapal�. ��nk� yer ile temas� ana objemiz yap�yor.
                                                                      // Patlama ger�ekle�ti�inde b�t�n par�alar�n collider'�n� birden a��yoruz.
                                                                      // Birbirlenie temas ettikleri i�in birden patl�yormu� gibi bir fizik animasyonu oluyor.
                piece.GetComponent<Rigidbody>().isKinematic = false;  // Patlayabilesi i�in kinemati�ini kapatmam�z laz�m. Yoksa par�alar statik bir durum sergiler.
            }
            StartCoroutine(TimeScaleControl());
            fireBallOrange.SetActive(false);
            fireBallGreen.SetActive(false);
            fireBallBlue.SetActive(false);
        }
        if (hit.gameObject.CompareTag("Hittable"))
        {
            soundLimitCount++;
        }
        if (hit.gameObject.CompareTag("Hittable") && soundLimitCount % 4 == 0)
        {
            soundManager.HitSound();
        }

    }

    private bool hasTriggered = false; // Fonksiyonun sadece 1 kez �al��mas� i�in bu de�i�keni false olarak ba�lat�p sonunda true de�erine d�nd�rece�iz.

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.gameObject.CompareTag("TutorialArea") && gameObject.CompareTag("Player"))
        {
            Variables.firstTouch = 0;
            transform.position = new Vector3(0, 0.6071609f, 57);
            rb.velocity = Vector3.zero;
            rb.freezeRotation = true;
            uimanager.TutorialScreenOpener();

            hasTriggered = true; // Bu fonksiyonun tekrar �al��mamas�n� sa�lamak i�in bu de�i�keni true yap�yoruz.
        }
    }

    //Restart Ekran� geli�i i�in kullan�l�yor
    public IEnumerator TimeScaleControl()
    {
        isBallMovingForward = true; // Kameran�n ve topun hareketini durdurmak i�in bu de�i�keni olu�turdum.                                
        yield return new WaitForSecondsRealtime(.4f);
        Time.timeScale = .6f; //Oyunun h�z�n� yava�latmak i�in
        yield return new WaitForSecondsRealtime(.4f);
        uimanager.RestartScreenActive(); //Restart ekran�n� getiriyoruz.
        rb.velocity = Vector3.zero; //Topun h�z�n� s�f�rl�yoruz b�ylece bir daha hareket edemesin
    }
}

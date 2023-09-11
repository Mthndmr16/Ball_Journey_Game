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

    //Çarpýþmalarda kapatmak için kullanacaðýz
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
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) //Eðer parmaðýmýz þuan alta yazacaðýmýz gameobject'lerin üzerinde deðilse 
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
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) //Eðer parmaðýmýz þuan alta yazacaðýmýz gameobject'lerin üzerinde deðilse 
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
                Debug.Log("Titreþim kapalý");
            }
            gameObject.transform.GetChild(0).gameObject.SetActive(false);  // Sphere objesini yapatýyor.
            foreach (GameObject piece in cells) // Topun her bir parçasýna eriþiyoruz
            {
                piece.GetComponent<SphereCollider>().enabled = true;  // Her birinin Collider'ý baþta kapalý. Çünkü yer ile temasý ana objemiz yapýyor.
                                                                      // Patlama gerçekleþtiðinde bütün parçalarýn collider'ýný birden açýyoruz.
                                                                      // Birbirlenie temas ettikleri için birden patlýyormuþ gibi bir fizik animasyonu oluyor.
                piece.GetComponent<Rigidbody>().isKinematic = false;  // Patlayabilesi için kinematiðini kapatmamýz lazým. Yoksa parþalar statik bir durum sergiler.
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

    private bool hasTriggered = false; // Fonksiyonun sadece 1 kez çalýþmasý için bu deðiþkeni false olarak baþlatýp sonunda true deðerine döndüreceðiz.

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.gameObject.CompareTag("TutorialArea") && gameObject.CompareTag("Player"))
        {
            Variables.firstTouch = 0;
            transform.position = new Vector3(0, 0.6071609f, 57);
            rb.velocity = Vector3.zero;
            rb.freezeRotation = true;
            uimanager.TutorialScreenOpener();

            hasTriggered = true; // Bu fonksiyonun tekrar çalýþmamasýný saðlamak için bu deðiþkeni true yapýyoruz.
        }
    }

    //Restart Ekraný geliþi için kullanýlýyor
    public IEnumerator TimeScaleControl()
    {
        isBallMovingForward = true; // Kameranýn ve topun hareketini durdurmak için bu deðiþkeni oluþturdum.                                
        yield return new WaitForSecondsRealtime(.4f);
        Time.timeScale = .6f; //Oyunun hýzýný yavaþlatmak için
        yield return new WaitForSecondsRealtime(.4f);
        uimanager.RestartScreenActive(); //Restart ekranýný getiriyoruz.
        rb.velocity = Vector3.zero; //Topun hýzýný sýfýrlýyoruz böylece bir daha hareket edemesin
    }
}

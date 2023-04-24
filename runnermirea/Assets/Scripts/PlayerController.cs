using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// \brief LifePlayer
/// 
/// **The script is responsible for collecting coins, for moving the character, for calculating and maintaining a record run time**
/// \code
/// public class PlayerController : MonoBehaviour
///{
///    public Text coinCount;
///float laneOffset;
///float laneChangeSpeed = 15;
///Rigidbody rb;
///Vector3 targetVelocity;
///float pointStart;
///float pointFinish;
///public bool isJump = false;
///bool isMoving = false;
///Coroutine movingCoroutine;
///float jumpPower = 15;
///float jumpGravity = -40;
///float realGravity = -9.8f;
///
///public float timeStart = 0;
///public Text timerText;
///public Text highscoretext;
///int highscore;
///
///bool timerRunning = false;
///
///void Awake() //Вывод стартовых значений интерфейса (время, рекордное время и количество монет на балансе)
///{
///    highscoretext.text = PlayerPrefs.GetFloat("timerText").ToString();
///    timerText.text = timeStart.ToString();
///    coinCount.text = PlayerPrefs.GetInt("coins").ToString();
///}
///
///void Start()
///{
///    laneOffset = MapGenerator.instance.laneOffset;
///    rb = GetComponent<Rigidbody>();
///
///}
///
///
///void Update() //Вызов передвижения и подсчёт рекордного времени
///{
///    if (Input.GetKeyDown(KeyCode.A) && pointFinish > -laneOffset)
///    {
///        MoveHorizontal(-laneChangeSpeed);
///
///    }
///    if (Input.GetKeyDown(KeyCode.D) && pointFinish < laneOffset)
///    {
///        MoveHorizontal(laneChangeSpeed);
///
///    }
///
///
///    if (Input.GetKeyDown(KeyCode.W) && isJump == false)
///    {
///        Jump();
///    }
///
///    if (timerRunning == true)
///    {
///        timeStart += Time.deltaTime;
///        timerText.text = Mathf.Round(timeStart).ToString();
///    }
///
///    highscoretext.text = "Рекорд : " + PlayerPrefs.GetFloat("timerText").ToString();
///    if (PlayerPrefs.GetFloat("timerText") <= timeStart)
///        PlayerPrefs.SetFloat("timerText", timeStart);
///
///    highscoretext.text = "Рекорд : " + PlayerPrefs.GetFloat("timerText").ToString();
///}
///
///void Jump() //логика прыжка
///{
///    isJump = true;
///    rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
///    Physics.gravity = new Vector3(0, jumpGravity, 0);
///    StartCoroutine(StopJumpCoroutine());
///}
///
///IEnumerator StopJumpCoroutine() //логика конца прыжка
///{
///    do
///    {
///        yield return new WaitForSeconds(0.02f);
///    } while (rb.velocity.y != 0);
///    isJump = false;
///    Physics.gravity = new Vector3(0, realGravity, 0);
///}
///
///
///
///void MoveHorizontal(float speed) //логика передвижения
///{
///    pointStart = pointFinish;
///    pointFinish += Mathf.Sign(speed) * laneOffset;
///
///    if (isMoving) { StopCoroutine(movingCoroutine); isMoving = false; }
///    movingCoroutine = StartCoroutine(MoveCoroutine(speed));
///
///}
///
///IEnumerator MoveCoroutine(float VectorX)
///{ //логика передвижения
///    isMoving = true;
///    while (Mathf.Abs(pointStart - transform.position.x) < laneOffset)
///    {
///        yield return new WaitForFixedUpdate();
///
///        rb.velocity = new Vector3(VectorX, rb.velocity.y, 0);
///        float x = Mathf.Clamp(transform.position.x, Mathf.Min(pointStart, pointFinish), Mathf.Max(pointStart, pointFinish));
///        transform.position = new Vector3(x, transform.position.y, transform.position.z);
///    }
///    rb.velocity = Vector3.zero;
///    transform.position = new Vector3(pointFinish, transform.position.y, transform.position.z);
///    isMoving = false;
///}
///
///public void StartGame() //Метод, отвечающий за старт забега
///{
///    timeStart = 0;
///    timerRunning = true;
///    RoadGenerator.instance.StartLevel();
///}
///
///
///public void ResetGame() //Метод, отвечающий за конец забега
///{
///    timerRunning = false;
///    RoadGenerator.instance.ResetLevel();
///    rb.velocity = Vector3.zero;
///    pointStart = 0;
///    pointFinish = 0;
///
///}
///
///private void OnTriggerEnter(Collider other) //Метод, проверяющий контакт персонажа с другими сущностямии и сопутствующая логика
///{
///    if (other.gameObject.tag == "Lose") { ResetGame(); } //контакт с препятствием - конец игры
///    if (other.gameObject.tag == "Gold") //контакт с монеткой - добавление единицы к балансу
///    {
///        int coins = PlayerPrefs.GetInt("coins");
///        PlayerPrefs.SetInt("coins", coins + 1);
///        coinCount.text = (coins + 1).ToString();
///    }
///}
///
///}
/// \endcode
/// </summary>

public class PlayerController : MonoBehaviour
{
    public Text coinCount;
    float laneOffset;
    float laneChangeSpeed = 15;
    Rigidbody rb;
    Vector3 targetVelocity;
    float pointStart;
    float pointFinish;
    public bool isJump = false;
    bool isMoving = false;
    Coroutine movingCoroutine;
    float jumpPower = 15;
    float jumpGravity = -40;
    float realGravity = -9.8f;

    public float timeStart = 0;
    public Text timerText;
    public Text highscoretext;
    int highscore;

    bool timerRunning = false;

    void Awake() //Вывод стартовых значений интерфейса (время, рекордное время и количество монет на балансе)
    {
        highscoretext.text = PlayerPrefs.GetFloat("timerText").ToString(); 
        timerText.text = timeStart.ToString();
        coinCount.text = PlayerPrefs.GetInt("coins").ToString();
    }
    
    void Start() 
    {
        laneOffset = MapGenerator.instance.laneOffset;
        rb = GetComponent<Rigidbody>();

    }

   
    void Update() //Вызов передвижения и подсчёт рекордного времени
    {
        if (Input.GetKeyDown(KeyCode.A) && pointFinish > -laneOffset)
        {
            MoveHorizontal(-laneChangeSpeed);
  
        }
        if (Input.GetKeyDown(KeyCode.D) && pointFinish < laneOffset)
        {
            MoveHorizontal(laneChangeSpeed);

        }


        if (Input.GetKeyDown(KeyCode.W) && isJump == false) 
        {
            Jump();
        }

        if (timerRunning == true)
        {
            timeStart += Time.deltaTime;
            timerText.text = Mathf.Round(timeStart).ToString();
        }

        highscoretext.text = "Рекорд : " + PlayerPrefs.GetFloat("timerText").ToString();
        if (PlayerPrefs.GetFloat("timerText") <= timeStart)
            PlayerPrefs.SetFloat("timerText", timeStart);

        highscoretext.text = "Рекорд : " + PlayerPrefs.GetFloat("timerText").ToString();
    }

    void Jump() //логика прыжка
    {
        isJump = true;
        rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        Physics.gravity = new Vector3(0, jumpGravity, 0);
        StartCoroutine(StopJumpCoroutine());
    } 

   IEnumerator StopJumpCoroutine() //логика конца прыжка
    {
        do {
            yield return new WaitForSeconds(0.02f);
        } while (rb.velocity.y != 0);
        isJump = false;
        Physics.gravity = new Vector3(0, realGravity, 0);
    }



    void MoveHorizontal(float speed) //логика передвижения
    {
        pointStart = pointFinish;
        pointFinish += Mathf.Sign(speed)* laneOffset;

        if (isMoving) { StopCoroutine(movingCoroutine); isMoving = false; }
        movingCoroutine = StartCoroutine(MoveCoroutine(speed));

    }

    IEnumerator MoveCoroutine(float VectorX)
    { //логика передвижения
        isMoving = true;
        while (Mathf.Abs(pointStart - transform.position.x) < laneOffset)
        {
            yield return new WaitForFixedUpdate();

            rb.velocity = new Vector3(VectorX, rb.velocity.y, 0);
            float x = Mathf.Clamp(transform.position.x, Mathf.Min(pointStart, pointFinish), Mathf.Max(pointStart, pointFinish));
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }
        rb.velocity = Vector3.zero;
        transform.position = new Vector3(pointFinish, transform.position.y, transform.position.z);
        isMoving = false;
    }

    public void StartGame() //Метод, отвечающий за старт забега
    {
        timeStart = 0;
        timerRunning = true;
        RoadGenerator.instance.StartLevel();
    }


    public void ResetGame() //Метод, отвечающий за конец забега
    {
        timerRunning = false;
        RoadGenerator.instance.ResetLevel();
        rb.velocity = Vector3.zero;
        pointStart = 0;
        pointFinish = 0;

    }

    private void OnTriggerEnter(Collider other) //Метод, проверяющий контакт персонажа с другими сущностямии и сопутствующая логика
    {
        if (other.gameObject.tag == "Lose") { ResetGame(); } //контакт с препятствием - конец игры
        if (other.gameObject.tag == "Gold") //контакт с монеткой - добавление единицы к балансу
        {
            int coins = PlayerPrefs.GetInt("coins");
            PlayerPrefs.SetInt("coins", coins + 1);
            coinCount.text = (coins + 1).ToString();
        }
    }

}

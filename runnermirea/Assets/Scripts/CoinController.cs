using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



/// <summary>
/// \brief Ётот скрипт отвеч€ает за жизнь так называемой монетки.
/// 
/// 
/// **»тоговый скрипт отвечающий за жизнь монетки(вращение, удаление со сцены после сбора)**
/// \code
///  public class CoinController : MonoBehaviour
///{
///
///    float rotationSpeed = 100;
///
///    void Start()
///    {
///        rotationSpeed += Random.Range(0, rotationSpeed / 4.0f);
///    }
///
///
///    void Update()
///    {
///        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
///    }
///
///    private void OnTriggerEnter(Collider other)
///    {
///        if (other.gameObject.tag == "Player")
///        {
///            transform.gameObject.SetActive(false);
///        }
///    }
///}
/// 
/// \endcode
/// </summary>

public class CoinController : MonoBehaviour
{
   
float rotationSpeed = 100;
  
    void Start()
    {
        rotationSpeed += Random.Range(0, rotationSpeed / 4.0f);
    }

    
    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0); 
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {                
            transform.gameObject.SetActive(false);
        }
    }
}

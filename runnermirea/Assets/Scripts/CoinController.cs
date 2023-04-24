using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinController : MonoBehaviour
{
    //public Text coinCount;
    float rotationSpeed = 100;
    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed += Random.Range(0, rotationSpeed / 4.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0); //вращение монеток для красоты
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {                //при соприкосновении монетки и игрока монетка будет пропадать
          //  int coins = PlayerPrefs.GetInt("coins"); 
           // PlayerPrefs.SetInt("coins", coins + 1);
           // coinCount.text = (coins + 1).ToString();
            transform.gameObject.SetActive(false);
        }
    }
}

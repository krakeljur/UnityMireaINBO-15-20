using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// \brief SHOPScript
/// **The script is responsible for the logic of the purchase of something in the game**
/// \code
/// public class Shop : MonoBehaviour
///{
///    public string objectName;
///public int price, access;
///public GameObject block;
///public Text objectPrice;
///
///
///void Awake()
///{
///    AccessUpdate();
///}
///
///void AccessUpdate() //ѕроверка, достаточно ли средств на балансе игрока и последующа€ покупка
///{
///    access = PlayerPrefs.GetInt(objectName + "Access");
///    objectPrice.text = price.ToString();
///
///    if (access == 1)
///    {
///        block.SetActive(false);
///        objectPrice.gameObject.SetActive(false);
///    }
///}
///
///public void OnButtonDown() //логика по€влени€ нового предмета и вычитани€ денег с баланса после покупки
///{
///    int coins = PlayerPrefs.GetInt("coins");
///
///    if (access == 0)
///    {
///        if (coins >= price)
///        {
///            PlayerPrefs.SetInt(objectName + "Access", 1);
///            PlayerPrefs.SetInt("coins", coins - price);
///            AccessUpdate();
///        }
///    }
///}
///}
/// \endcode
/// </summary>
public class Shop : MonoBehaviour
{
    public string objectName;
    public int price, access;
    public GameObject block;
    public Text objectPrice;


    void Awake()
    {
        AccessUpdate();
    }

    void AccessUpdate() //ѕроверка, достаточно ли средств на балансе игрока и последующа€ покупка
    {
        access = PlayerPrefs.GetInt(objectName + "Access");
        objectPrice.text = price.ToString();

        if (access == 1) {
            block.SetActive(false);
            objectPrice.gameObject.SetActive(false);
        }
    }

    public void OnButtonDown() //логика по€влени€ нового предмета и вычитани€ денег с баланса после покупки
    {
        int coins = PlayerPrefs.GetInt("coins");

        if (access == 0)
        { if (coins >= price) {
                PlayerPrefs.SetInt(objectName + "Access", 1);
                PlayerPrefs.SetInt("coins", coins - price);
                AccessUpdate();
            }
        }
    }
}

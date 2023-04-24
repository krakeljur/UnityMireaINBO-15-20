using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// \brief Скрипт, отвечающий за проведение покупки
/// **Скрипт отвечает за логику проведения покупки чего-либо в игре**
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
///void AccessUpdate() //Проверка, достаточно ли средств на балансе игрока и последующая покупка
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
///public void OnButtonDown() //логика появления нового предмета и вычитания денег с баланса после покупки
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

    void AccessUpdate() //Проверка, достаточно ли средств на балансе игрока и последующая покупка
    {
        access = PlayerPrefs.GetInt(objectName + "Access");
        objectPrice.text = price.ToString();

        if (access == 1) {
            block.SetActive(false);
            objectPrice.gameObject.SetActive(false);
        }
    }

    public void OnButtonDown() //логика появления нового предмета и вычитания денег с баланса после покупки
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

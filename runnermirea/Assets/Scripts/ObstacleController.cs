using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// \brief Скрипт, отвечающий за проигрыш персонажа
/// **Скрипт проверяет препятствие на прикосновение к персонажу. Если препятствие, коснулось персонажа, то игра заканчивается**
/// \code
/// public class ObstacleController : MonoBehaviour
///{
///    private void OnTriggerEnter(Collider other)
///    {
///        if (other.gameObject.tag == "Player")
///        {
///            other.gameObject.GetComponent<PlayerController>().ResetGame();
///        }
///    }
///}
///\endcode
/// </summary>
public class ObstacleController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent< PlayerController >().ResetGame();
        }
    }
}

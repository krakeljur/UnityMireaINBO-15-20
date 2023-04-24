using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// \brief CheckLoseGame
/// **The script checks the obstacle for touching the character. If the obstacle touches the character, then the game ends**
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// \brief MapGenerate(background)
/// **The script is responsible for the generation, movement and subsequent removal of environmental objects (houses, road)**
/// \code
/// public class RoadGenerator : MonoBehaviour
///{
///    public GameObject RoadPrefab;
///private List<GameObject> roads = new List<GameObject>();
///public float maxSpeed = 10;
///public float speed = 0;
///public int maxRoadCount = 5;
///public static RoadGenerator instance;
///void Awake() { instance = this; }
///
///
///void Start()
///{
///    ResetLevel();
///}
///
///
///void Update()
///{
///    if (speed == 0) return;
///
///    foreach (GameObject road in roads)
///    {
///        road.transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
///    }
///
///    if (roads[0].transform.position.z < -30)
///    {
///        Destroy(roads[0]);
///        roads.RemoveAt(0);
///
///        CreateNextRoad();
///    }
///}
///
///private void CreateNextRoad() // ѕровер€ем, сколько объектов среды уже существует, если недостаточно, то добавл€ем новый и удал€ем последний
///{
///    Vector3 pos = Vector3.zero;
///    if (roads.Count > 0) { pos = roads[roads.Count - 1].transform.position + new Vector3(0, 0, 20); }
///    GameObject go = Instantiate(RoadPrefab, pos, Quaternion.identity);
///    go.transform.SetParent(transform);
///    roads.Add(go);
///}
///
///public void StartLevel()
///{
///    speed = maxSpeed;
///
///}
///
///public void ResetLevel()
///{
///    speed = 0;
///    while (roads.Count > 0)
///    {
///        Destroy(roads[0]);
///        roads.RemoveAt(0);
///    }
///    for (int i = 0; i < maxRoadCount; i++)
///    {
///        CreateNextRoad();
///    }
///
///    MapGenerator.instance.ResetMaps();
///}
///}
/// \endcode
/// </summary>
public class RoadGenerator : MonoBehaviour
{
    public GameObject RoadPrefab;
    private List<GameObject> roads = new List<GameObject>();
    public float maxSpeed = 10;
    public float speed = 0;
    public int maxRoadCount = 5;
    public static RoadGenerator instance;
    void Awake() { instance = this; }

  
    void Start()
    {
        ResetLevel();
    }

 
    void Update()
    {
        if (speed == 0) return;

        foreach (GameObject road in roads)
        {
            road.transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
        }

        if (roads[0].transform.position.z < -30) 
        {
            Destroy(roads[0]);
            roads.RemoveAt(0);

            CreateNextRoad();
        }
    }

    private void CreateNextRoad() // ѕровер€ем, сколько объектов среды уже существует, если недостаточно, то добавл€ем новый и удал€ем последний
    {
        Vector3 pos = Vector3.zero;
        if (roads.Count > 0) { pos = roads[roads.Count - 1].transform.position + new Vector3(0, 0, 20); }
        GameObject go = Instantiate(RoadPrefab, pos, Quaternion.identity);
        go.transform.SetParent(transform);
        roads.Add(go);
    }

    public void StartLevel()
    {
        speed = maxSpeed;

    }

    public void ResetLevel()
    {
        speed = 0;
        while (roads.Count > 0) 
        {
            Destroy(roads[0]);
            roads.RemoveAt(0);
        }
        for (int i = 0; i < maxRoadCount; i++)
        {
            CreateNextRoad();
        }
 
        MapGenerator.instance.ResetMaps();
    }
}

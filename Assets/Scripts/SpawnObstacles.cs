using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject player;

    private Vector3 obstaclePosition; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        obstaclePosition = player.transform.position;
        InvokeRepeating("Spawn", 0.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void Spawn()
    {
        obstaclePosition = new Vector3(obstaclePosition.x + Random.Range(20,24), Random.Range(-5.0f,5.0f), Random.Range(-0.75f,0.75f));
        
        GameObject newObstacle = Object.Instantiate(obstaclePrefab);
        newObstacle.transform.position = obstaclePosition;
    }
}

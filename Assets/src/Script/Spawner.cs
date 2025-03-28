using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private Transform hightPos;
    [SerializeField] private Transform lowPos;
    [SerializeField] private Transform centerPos;
    private float timer = 0;
    [SerializeField] private float spawnerRate = 2f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnerRate)
        {
            spawnerObstacles();
            timer = 0;
        }
    }
    private void spawnerObstacles ()
    {
        int index = Random.Range(0,obstacles.Length);
        if(index == 0 || index == 1)
        {
            GameObject obstacle = Instantiate(obstacles[index], lowPos.position, Quaternion.identity);
        } else if (index == 2) 
        {
            GameObject obstacle = Instantiate(obstacles[index], hightPos.position, Quaternion.identity);
        }else if (index == 3)
        {
            GameObject obstacle = Instantiate(obstacles[index], centerPos.position, Quaternion.identity);
        }
    }
}

using UnityEngine;

public class obstacles : MonoBehaviour
{
    public float leftBoundary = -10f;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoverObstacles();
    }
    private void MoverObstacles()
    {
        transform.position += Vector3.left * GameManager.instance.GetGameSpeed() * Time.deltaTime;
        if(transform.position.x < leftBoundary)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            GameManager.instance.GameOver();
        }
    }
}

using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject OneBallPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("AddABall", 1.5f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddABall()
    {
        Instantiate(OneBallPrefab);
    }
}

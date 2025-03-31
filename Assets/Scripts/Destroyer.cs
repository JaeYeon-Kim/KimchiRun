using UnityEngine;

public class Destroyer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 배경을 벗어날 경우 물체 삭제 
        if(transform.position.x < -15) 
        {
            Destroy(gameObject);
        }
    }
}

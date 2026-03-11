using UnityEngine;


public class HurtBox : MonoBehaviour
{
    int health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision){
        Debug.Log(collision.gameObject.name);
        if (collision.collider.CompareTag("Attack")){
            health--;
            Debug.Log("health " + health);
        }
    }
}

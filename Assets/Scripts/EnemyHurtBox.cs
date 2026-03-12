using UnityEngine;


public class EnemyHurtBox : MonoBehaviour
{
    // int health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // void OnCollisionEnter2D(Collision2D collision){
    //     Debug.Log(collision.gameObject.name);
    //     if (collision.collider.CompareTag("Attack")){
    //         health--;
    //         Debug.Log("health " + health);
    //     }
    // }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Attack"))
        {
            EnemyBehaviour.enenmyHealth--;
        //     if (gameObject.CompareTag("Player"))
        //     {
        //         EnemyBehaviour.enenmyHealth--;
        //     }

        //     if (gameObject.CompareTag("Enemy"))
        //     {
        //         PlayerController.playerHealth--;
                
        //     }
        }
        Debug.Log("enemyHealth " + EnemyBehaviour.enenmyHealth);

    }
}

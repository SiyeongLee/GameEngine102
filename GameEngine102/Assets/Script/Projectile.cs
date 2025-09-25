using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    public float lifeTime = 2f;
    public int Weapondamage = 1;
    Enemy enemy;


    void Start()
    {
        Destroy(gameObject, lifeTime);
        enemy = FindObjectOfType<Enemy>();
    }

    
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    { if (other.CompareTag("Enemy"))
        {
            enemy.HitEnemy(Weapondamage);
            Destroy(gameObject);
        }
       
    }

}

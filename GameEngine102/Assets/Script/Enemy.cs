using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    public int enemyHp = 5;

    private Transform player; 
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) 
            return;
        Vector3 PlayerTargetPos = new Vector3(player.position.x, transform.position.y, player.position.z);
        
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
        transform.LookAt(player.position);
    }

    public void HitEnemy(int AttackDamage)
    {
        enemyHp -= AttackDamage;
        if (enemyHp <= 5)
        {
            Destroy(gameObject);
        }
    }
}

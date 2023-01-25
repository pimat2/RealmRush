using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHtPoints = 5;
    int currentHitPoints = 0;
    Enemy enemy;
    // Start is called before the first frame update
    void OnEnable()
    {
        currentHitPoints = maxHtPoints;
    }
    void Start() {
        enemy = GetComponent<Enemy>();     
    }
    void OnParticleCollision(GameObject other) {
          ProcessHit();
    }
    void ProcessHit(){
        currentHitPoints--;
        if(currentHitPoints <= 0){
            gameObject.SetActive(false);
            enemy.RewardGold();
        }  
        
    }
}

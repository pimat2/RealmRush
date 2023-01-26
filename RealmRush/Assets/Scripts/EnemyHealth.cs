using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHtPoints = 5;
    [Tooltip("Adds amount to maxHitPoints when enemy dies")]
    [SerializeField] int difficultyRamp = 1;
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
            maxHtPoints += difficultyRamp;
            enemy.RewardGold();

        }  
        
    }
}

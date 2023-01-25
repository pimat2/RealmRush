using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHtPoints = 5;
    int currentHitPoints = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentHitPoints = maxHtPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnParticleCollision(GameObject other) {
          ProcessHit();
    }
    void ProcessHit(){
        currentHitPoints--;
        if(currentHitPoints <= 0){
            Destroy(gameObject);
        }  
    }
}

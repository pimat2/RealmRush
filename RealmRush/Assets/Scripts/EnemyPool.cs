using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField][Range(0, 50)] int poolSize = 5;
    GameObject[] pool;
    [SerializeField] GameObject enemyRam;
    [SerializeField][Range(0.1f, 30f)] float enemySpawnRate = 1f;
    GameObject enemyPool;
    // Start is called before the first frame update
    void Awake() {
      PopulatePool();  
    }
    void Start()
    {
        StartCoroutine(InstantiateEnemy());
    }
    void PopulatePool(){
        pool = new GameObject[poolSize];
        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyRam, transform);
            pool[i].SetActive(false);
        }
    }
    void EnableObjectInPool(){
        for (int i = 0; i < pool.Length; i++)
        {
            if(pool[i].activeInHierarchy == false){
                pool[i].SetActive(true);
                return;
            }

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator InstantiateEnemy(){
        while(true){
            EnableObjectInPool();
            yield return new WaitForSeconds(Mathf.Abs(enemySpawnRate));
        }
        
    }


}

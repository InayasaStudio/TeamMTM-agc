using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnerTrap : MonoBehaviour
{
    public GameObject trapPrefab;
    public GameObject[] trapsPrefab;
    public float timeToSpawn;
    public int maxTrap;


    private float trapCount;

    void Start()
    {
        MethodA();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MethodA()
    {
        StartCoroutine(cekSpawnTrap(maxTrap));
    }

    private IEnumerator cekSpawnTrap(int maximalTrap)
    {
        
        int maxTrap = maximalTrap;
        trapsPrefab = GameObject.FindGameObjectsWithTag("Trap");
        trapCount = trapsPrefab.Length;
        yield return new WaitForSeconds(timeToSpawn);        
        
        if(trapCount < maxTrap)
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-8,5),1,Random.Range(-1,-6));
            Instantiate(trapPrefab, randomSpawnPosition, Quaternion.identity);
            MethodA();
        }
        
       
    }



}

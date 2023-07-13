using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public GameObject[] coinsPrefab;
    public float time;
    public int maxCoin;


    private float CoinCount;
    private enum CoinSpawnState {Off, On};

    void Start()
    {
        //CoinCount = CalculateCoinCount();
        MethodA();
    }


    void Update()
    {

    }

    public void MethodA()
    {
        StartCoroutine(cekSpawnCoin(maxCoin));
    }


    private int CalculateCoinCount()
    {
        coinsPrefab = GameObject.FindGameObjectsWithTag("Coin");
        return coinsPrefab.Length;
    }

    private IEnumerator cekSpawnCoin(int maximalCoin)
    //private IEnumerator CheckSpawnCoin(int maximalCoin)
    {
        
        int maxCoin = maximalCoin;
        coinsPrefab = GameObject.FindGameObjectsWithTag("Coin");
        CoinCount = coinsPrefab.Length;
        yield return new WaitForSeconds(time);

        /*
        for(i = 0; i < maximalCoin; i++)
        {
            yield new WaitForSeconds
        }
        */
        
        
        if(CoinCount < maxCoin)
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-8,5),1,Random.Range(-1,-6));
            Instantiate(coinPrefab, randomSpawnPosition, Quaternion.identity);
            MethodA();
            //StartSpawnCoin();
        }
        
       
    }

    private void StartSpawnCoin()
    {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-8,5),1,Random.Range(-1,-6));
            Instantiate(coinPrefab, randomSpawnPosition, Quaternion.identity);
            Debug.Log("Spawn Coin");
            //yield return StartCoroutine(cekSpawnCoin(3));
            MethodA();
    }
    

}

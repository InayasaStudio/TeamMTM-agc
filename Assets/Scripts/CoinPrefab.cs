using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPrefab : MonoBehaviour
{
    public GameObject bola;
    public GameObject selfCoin;
    public RandomSpawner randomSpawner;

    public float time;

    //private RandomSpawnerRef randomSpawnerRef;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyWithTime(time));
        randomSpawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<RandomSpawner>();
    }

    // Update is called once per frame
    void Update()
    {

    }

     private void OnTriggerEnter(Collider other)
  { 
    if (other.gameObject.tag == "Bola")
    {
        Debug.Log("Kena Bola");
        
        DestroyAndSpawn();
       
    }
  }

private IEnumerator DestroyWithTime(float time)
{
    yield return new WaitForSeconds(time);
    DestroyAndSpawn();
}

  private void DestroyAndSpawn()
  {
   
    Destroy(selfCoin);
    randomSpawner.MethodA();
  }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPrefab : MonoBehaviour
{
    public GameObject bola;
    public GameObject selfTrap;
    public RandomSpawnerTrap randomSpawnerTrap;

    public float time;

    void Start()
    {
        StartCoroutine(DestroyWithTime(time));
        randomSpawnerTrap = GameObject.FindGameObjectWithTag("Spawner").GetComponent<RandomSpawnerTrap>();
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
   
    Destroy(selfTrap);
    randomSpawnerTrap.MethodA();
  }
}

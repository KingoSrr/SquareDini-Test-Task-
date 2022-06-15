using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawn : MonoBehaviour
{
    private GameObject _Player;
    public bool CanSpawn;
    public GameObject Enemy;
    public void Spawn()
    {
        CanSpawn = false;
        _Player = GameObject.FindGameObjectWithTag("Player");
        int rnd = Random.Range(1, 3);
        for (int i = 1; i <= rnd; i++)
        {
            Instantiate(Enemy, new Vector3(_Player.transform.position.x + Random.insideUnitCircle.x * 2.2f, 
                                           _Player.transform.position.y, 
                                           _Player.transform.position.z + Random.insideUnitCircle.x * 2.2f), Quaternion.identity);
        }
        Debug.Log(GameObject.FindGameObjectsWithTag("Enemy").Length);
    }
}

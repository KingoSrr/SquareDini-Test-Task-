using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameController _GameController;
    private void OnCollisionEnter(Collision collision)
    {
        _GameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        if (collision.collider.tag == "Enemy")
        {
            collision.collider.GetComponent<EnemyController>().Health--;
            if (collision.collider.GetComponent<EnemyController>().Health == 0)
            {
                _GameController.DestroyEnemy(collision);
            }
        }
        Debug.Log(collision.collider.tag);
    }
}

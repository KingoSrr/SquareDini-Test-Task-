using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class GameController : MonoBehaviour
{
    public List<Transform> CheckPoint;
    public CinemachineVirtualCamera Cinemachine;
    public GameObject FinishPlane;
    public GameObject Bullet;
    public GameObject Player;
    public float Power;
    public bool IsWin = false;
    public GameObject EnemySpawnController;
    private EnemySpawn _EnemySpawn;
    private PlayerController _PlayerController;

    private void Start()
    {
        GameObject p = Instantiate(Player, CheckPoint[0].position, Quaternion.identity);
        CheckPoint.Remove(CheckPoint[0]);
        Cinemachine.GetComponent<CinemachineVirtualCamera>().Follow = p.transform;
        Cinemachine.GetComponent<CinemachineVirtualCamera>().LookAt = p.transform;
        _EnemySpawn = EnemySpawnController.GetComponent<EnemySpawn>();
        _PlayerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        FinishPlane.SetActive(false);
        Time.timeScale = 1;
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            GameObject b = Instantiate(Bullet, Camera.main.transform.position, transform.rotation);
            Destroy(b, 3f);
            b.GetComponent<Rigidbody>().AddForce(ray.direction * Power, ForceMode.Impulse);
        }
    }
    public void DestroyEnemy(Collision collision)
    {
        collision.gameObject.GetComponent<EnemyController>().BulletHit();
        List<GameObject> AllEnemy = new List<GameObject>();
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            AllEnemy.Add(item);
        }
        AllEnemy.Remove(collision.gameObject);
        if (AllEnemy.Count == 0)
        {
            CheckPoint.Remove(CheckPoint[0]);
            _EnemySpawn.CanSpawn = true;
            _PlayerController.Anim.SetBool("IsIdle", false);
        }
        if (CheckPoint.Count == 0)
        {
            Time.timeScale = 0;
            IsWin = true;
            FinishPlane.SetActive(true);
        }
    }
}

using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public GameObject EnemySpawnController;
    public GameObject GameController;
    public Animator Anim;
    private NavMeshAgent _AgentPlayer;
    private EnemySpawn _EnemySpawn;
    private GameController _GameController;
    private bool _IsTap;
    private void Start()
    {
        _IsTap = false;
        _AgentPlayer = GetComponent<NavMeshAgent>();
        _EnemySpawn = GameObject.FindGameObjectWithTag("EnemySpawnController").GetComponent<EnemySpawn>();
        _GameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        Anim = GetComponent<Animator>();
        Anim.SetBool("IsIdle", true);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _IsTap == false)
        {
            _IsTap = true;
            Anim.SetBool("IsIdle", false);
        }
        if (_GameController.IsWin == false && _IsTap == true)
        {
            _AgentPlayer.SetDestination(_GameController.CheckPoint[0].position);
            if (Vector3.Distance(_GameController.CheckPoint[0].position, transform.position) <= 0.5f && _EnemySpawn.CanSpawn == true)
            {
                Anim.SetBool("IsIdle", true);
                _EnemySpawn.Spawn();
            }
        }
        
    }
}

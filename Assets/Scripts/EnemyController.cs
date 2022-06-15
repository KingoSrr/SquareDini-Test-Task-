using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public Rigidbody[] AllRigidbody;
    public int Health;
    private TextMeshPro _HealthText;
    void Start()
    {
        _HealthText = GetComponentInChildren<TextMeshPro>();
        Health = Random.Range(1, 3);
        for(int i = 0; i < AllRigidbody.Length; i++)
        {
            AllRigidbody[i].isKinematic = true;
        }
    }
    private void Update()
    {
        _HealthText.transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position, Vector3.up);
        _HealthText.text = "Çהמנמגüו: " + Health;
    }
    public void BulletHit()
    {
        Destroy(gameObject, 0.5f);
        Animator Anim = GetComponent<Animator>();
        Anim.enabled = false;
        for (int i = 0; i < AllRigidbody.Length; i++)
        {
            AllRigidbody[i].isKinematic = false;
        }
    }
}

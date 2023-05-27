using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    private NavMeshAgent navMeshAgent;
    private Transform target;
    public GameObject deathSplash;
    private Animator _animator;
    private bool _canAttack = true;
    private EnemySpawner enemySpawner;
    private AudioSource _audioSource;


    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("DrOdd").transform;
        _animator = GetComponentInChildren<Animator>();
        enemySpawner = GameObject.FindObjectOfType<EnemySpawner>();
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(routine: playRondom());
    }

    IEnumerator playRondom()
    {
        while(true)
        {
            _audioSource.Play();
            yield return new WaitForSeconds(UnityEngine.Random.Range(2,10));

        }
    }

    void Update()
    {

        navMeshAgent.SetDestination(target.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            if (Mathf.Abs(other.attachedRigidbody.velocity.x) > 5f ||
               Mathf.Abs(other.attachedRigidbody.velocity.y) > 5f ||
               Mathf.Abs(other.attachedRigidbody.velocity.z) > 5f)
            {
                Instantiate(deathSplash, transform.position, Quaternion.identity);
                enemySpawner.currentEnemy -= 1;
                GameObject.Destroy(gameObject);
            }
        }
    }

     private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(_canAttack)
            {
                _canAttack = false;
                StartCoroutine(Attack());

            }
        }
    }

    private void AttackPlayer()
    {
        _animator.SetBool("attack", true);
    }

    IEnumerator Attack()
    {
        AttackPlayer();
        yield return new WaitForSeconds(1f) ;
        _canAttack = true;
        _animator.SetBool("attack", false);

    }
}

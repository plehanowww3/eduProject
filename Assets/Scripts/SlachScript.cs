using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlachScript : MonoBehaviour
{
    public float gravityForse = 155;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.transform.GetComponent<NavMeshAgent>().enabled = false;
            other.transform.GetComponent<EnemyMove>().enabled = false;
            var enemyAnim = other.transform.GetComponent<Animator>();
            enemyAnim.SetTrigger("Floating");
            var enemyRigiBody = other.transform.GetComponent<Rigidbody>();
            enemyRigiBody.useGravity = false;
            enemyRigiBody.AddForce(enemyRigiBody.transform.up * gravityForse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

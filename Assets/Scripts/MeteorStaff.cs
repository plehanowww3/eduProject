using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System.Threading.Tasks;


public class MeteorStaff : MonoBehaviour
{
    public float range = 20f;
    public Transform bulletSpawn;
    public Camera _cam;
    public Animator animator;
    private float nextFire = 0f;
    public float force = 155;
    public GameObject slashColider;
    public ParticleSystem slash;
    public bool canActive = true;
    [SerializeField] CoolDownSliderScript coolDownSliderScript;

    // Start is called before the first frame update
    void Start()
    {
        slashColider.SetActive(false);
    }

    void AttackTriggerON()
    {
        canActive = true;
    }

    void AttackTriggerOFF()
    {
        canActive = false;
    }

    public async void Shoot()
    {
        slashColider.SetActive(true);
        await Task.Delay(100);
        slashColider.SetActive(false);
    }

    void Impact()
    {
        slash.Play();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire && canActive == true && coolDownSliderScript.m_staffCooldownClass.m_canAttack == true)
        {
            animator.SetTrigger("Attack");
        }
    }
}

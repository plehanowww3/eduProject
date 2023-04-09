using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpSystem : MonoBehaviour
{
    public int maxHealth;
    public HealthBar healthBar;
    public float currentHealth;
    public Animator animator;
    public Animator deathAnimator;
    public AudioSource damageSource;
    public ParticleSystem healParticle;
    [SerializeField] FirstPersonMovement m_firstPersonMovement;
    [SerializeField] FirstPersonLook m_firstPersonLook;
    [SerializeField] WeaponChange m_weaponChange;
    [SerializeField] Jump m_jump;
    [SerializeField] Crouch m_crouch;
    [SerializeField] Collider m_playerColider;
    [SerializeField] Rigidbody m_playerRigibody;
    [SerializeField] ConeAttack m_coneAttack;
    [SerializeField] ShieldActivated m_shieldActivate;
    [SerializeField] RepulsiveField m_repulsiveField;
    [SerializeField] MeteorStaff m_staff;
    public CheckPoint m_checkPoint;




    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetBarValue(currentHealth, maxHealth);
    }

    void BlockMove()
    {
        m_firstPersonMovement.enabled = false;
        m_firstPersonLook.enabled = false;
        m_weaponChange.enabled = false;
        m_jump.enabled = false;
        m_crouch.enabled = false;
        m_playerRigibody.isKinematic = true;
        m_playerColider.enabled = false;
        m_coneAttack.enabled = false;
        m_shieldActivate.enabled = false;
        m_repulsiveField.enabled = false;
        m_staff.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    void UnblockMove()
    {
        m_firstPersonMovement.enabled = true;
        m_firstPersonLook.enabled = true;
        m_weaponChange.enabled = true;
        m_jump.enabled = true;
        m_crouch.enabled = true;
        m_playerRigibody.isKinematic = false;
        m_playerColider.enabled = true;
        m_coneAttack.enabled = true;
        m_shieldActivate.enabled = true;
        m_repulsiveField.enabled = true;
        m_staff.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void GetDamage(int _count)
    {
        //damageSource.PlayOneShot(deathSound);
        animator.SetTrigger("Damage");
        currentHealth -= _count;
        healthBar.SetBarValue(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            deathAnimator.SetBool("Death", true);
            BlockMove();
        }
    }

    public void Revival()
    {
        UnblockMove();
        deathAnimator.SetBool("Death", false);
        transform.position = m_checkPoint.m_spawnPoint;
        currentHealth = maxHealth;
        healthBar.SetBarValue(currentHealth, maxHealth);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CheckPoint")
        {
            m_checkPoint = other.GetComponent<CheckPoint>();
        }
    }

    public void Heal(int healCount)
    {
        currentHealth += healCount;
        healParticle.Play();

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}

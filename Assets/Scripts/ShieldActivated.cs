using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShieldActivated : MonoBehaviour
{
    [SerializeField] Animator animatorShield;
    [SerializeField] Animator animatorCube;
    [SerializeField] WeaponChange weapon;
    [SerializeField] Rigidbody rb;
    [SerializeField] GroundCheck groundCheck;
    [SerializeField] CoolDownSliderScript coolDownSliderScript;
    public bool canActive = true;
    
    

    // Start is called before the first frame update
    void Start()
    {

    }

    void BlockMoveON()
    {
        rb.isKinematic = true;
        weapon.enabled = false;
        canActive = true;
    }

    void BlockMoveOff()
    {
        rb.isKinematic = false;
        weapon.enabled = true;
        canActive = false;
    }

    

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1") && groundCheck.isGrounded == true && canActive == false && coolDownSliderScript.m_shieldCooldownClass.m_canAttack == true)
        {
            animatorCube.SetTrigger("CubeUse");
            animatorShield.SetTrigger("Apear");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseTheIteam : MonoBehaviour
{

    [SerializeField] GameObject camera;
    [SerializeField] float distance = 15f;
    [SerializeField] HpSystem hp;

    void PickUp()
    {
        RaycastHit hit;

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, distance))
        {
            if (hit.transform.tag == "Heal")
            {
                if (hp.currentHealth < hp.maxHealth)
                {
                    hp.Heal(3);
                    hp.healthBar.SetBarValue(hp.currentHealth, hp.maxHealth);
                    hit.transform.GetComponent<HealDisepear>().HealSphereOff();
                }
                else
                {
                    return;
                }
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PickUp();
        }
    }
}

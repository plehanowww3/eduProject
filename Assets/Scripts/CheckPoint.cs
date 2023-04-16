using UnityEngine;

/// <summary>
/// Точка возрождения
/// </summary>
public class CheckPoint : MonoBehaviour
{
    public GameObject m_point;
    public Vector3 m_spawnPoint;
    public GameObject m_player;
    //public Animator m_deathAnimator;
    public Animator m_checkPointAnimator;

    private void Start()
    {
        m_spawnPoint = m_player.transform.position;
    }

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_checkPointAnimator.SetTrigger("IsActive");
            m_spawnPoint = m_point.transform.position;
        
        }
    }
}

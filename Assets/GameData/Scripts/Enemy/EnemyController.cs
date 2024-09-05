using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour
{   
    [SerializeField] private Transform m_Target;
    [SerializeField] private NavMeshAgent m_Agent;
    [SerializeField] private EnemyAnimator e_animator;
    [SerializeField] private Collider m_Collider;
    [SerializeField] private float m_Distance = 100f;
    [SerializeField] private ParticleSystem DeadParticle;
    [SerializeField] private GameObject diamonds;
    [SerializeField] private Transform coinParent;


    public bool isdead;
    
    private void Awake()
    {
        m_Target = GameObject.FindGameObjectWithTag("Player").transform;
        coinParent = GameObject.FindGameObjectWithTag("Parent").transform;
    }

    void Start()
    {
        isdead = false;
    }

    void Update()
    {
        FollowToPlayer();
    }

    private void FollowToPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, m_Target.position);
        if (distanceToPlayer <= m_Distance)
        {
            if (isdead!=true)
            {
                e_animator.IsEwalk();
                m_Agent.SetDestination(m_Target.position);
            }
        }
        else
        {
            e_animator.IsEidle();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Instantiate(diamonds, transform.position, Quaternion.identity,coinParent);
            DeadParticle.Play();
            isdead = true;
            e_animator.IsEdead();
            m_Agent.enabled = false;
            m_Collider.isTrigger = false;
            Destroy(gameObject,0.8f);
        }
    }

}

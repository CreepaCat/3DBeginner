using UnityEngine;
using UnityEngine.AI;

namespace Beginner.Enemy
{
    public class WaypointPatrol : MonoBehaviour
    {
        [SerializeField] Transform[] waypoints = null;
        NavMeshAgent navMeshAgent = null;
        int m_CurrentWaypointIndex = 0;
        void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            navMeshAgent.SetDestination(waypoints[0].position);
        }

        void Update()
        {
            CheckUpdateAgentTarget();
        }

        private void CheckUpdateAgentTarget()
        {

            if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
            {

                m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
                navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);

            }
        }
    }
}



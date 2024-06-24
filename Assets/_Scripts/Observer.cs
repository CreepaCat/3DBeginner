using Beginner.Game;
using UnityEngine;

namespace Beginner.Enemy
{
    public class Observer : MonoBehaviour
    {

        [SerializeField] Transform player = null;
        [SerializeField] bool isPlayerInRange = false;

        [SerializeField] GameEnding gameEnding = null;
        void Start()
        {

        }

        void Update()
        {
            if (isPlayerInRange)
            {
                //视线检查
                CheckView();
            }
        }

        void CheckView()
        {
            Vector3 viewDirection = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, viewDirection);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.transform == player)
                {
                    //  isPlayerInRange = true;
                    //抓住玩家
                    gameEnding.CaughtPlayer();
                }

            }

        }

        void OnTriggerEnter(Collider other)
        {
            if (other.transform == player)
            {
                isPlayerInRange = true;
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.transform == player)
            {
                isPlayerInRange = false;
            }
        }
    }
}



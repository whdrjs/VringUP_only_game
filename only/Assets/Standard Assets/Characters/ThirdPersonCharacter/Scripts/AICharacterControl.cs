using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof(ThirdPersonCharacter))]

    public class AICharacterControl : MonoBehaviour
    {
        
        public UnityEngine.AI.NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform target;                                    // target to aim for
        public static AICharacterControl instance = null; 

        private void Start()
        {
            
           // if (SceneManager.GetActiveScene().buildIndex == 4)
               agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
                character = GetComponent<ThirdPersonCharacter>();

                agent.updateRotation = false;
                agent.updatePosition = true;
        }

        private void Update()
        {
                if (target != null){
                    agent.SetDestination(target.position);
                if (agent.remainingDistance > agent.stoppingDistance)
                    character.Move(agent.desiredVelocity, false, false);
                }
                else
                    character.Move(Vector3.zero, false, false);
        }


        public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}

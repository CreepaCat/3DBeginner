using UnityEngine;

namespace Beginner.Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        Animator animator;
        Rigidbody playerRB;
        AudioSource footstepAudioSource;
        void Start()
        {
            animator = GetComponentInChildren<Animator>();
            playerRB = GetComponentInChildren<Rigidbody>();
            footstepAudioSource = GetComponentInChildren<AudioSource>();
        }

        void Update()
        {
            Vector3 horizontalVelocity = new Vector3(playerRB.velocity.x, 0, playerRB.velocity.z);

            animator.SetFloat("speed", horizontalVelocity.magnitude);

            if (horizontalVelocity.magnitude > 0.2f)
            {
                if (!footstepAudioSource.isPlaying)
                {
                    footstepAudioSource.Play();
                }
            }
            else
            {
                footstepAudioSource.Stop();
            }
        }
    }
}



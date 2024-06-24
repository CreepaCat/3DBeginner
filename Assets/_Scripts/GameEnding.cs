using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Beginner.Game
{
    public class GameEnding : MonoBehaviour
    {
        [SerializeField] float m_FadeDuration = 2f;
        [SerializeField] GameObject m_PlayerGO = null;
        [SerializeField] CanvasGroup m_ExitBackGroundImageCanvasGroup = null;
        [SerializeField] CanvasGroup m_CaughtBackGroundImageCanvasGroup = null;
        float m_FadeTimer = 0;
        [SerializeField] float m_DisplayImageDuration = 1f;

        [SerializeField] bool m_IsPlayerAtExit = false;
        [SerializeField] bool m_IsPlayerCaught = false;



        [SerializeField] AudioSource exitAudioSource = null;
        [SerializeField] AudioSource caughtAudioSource = null;
        [SerializeField] bool m_HasAudioPlayed = false;




        void Update()
        {
            if (m_IsPlayerAtExit)
            {
                //淡入UI
                EndLevel(m_ExitBackGroundImageCanvasGroup, exitAudioSource);
            }
            else if (m_IsPlayerCaught)
            {
                EndLevel(m_CaughtBackGroundImageCanvasGroup, caughtAudioSource, true);

            }
        }

        public void CaughtPlayer()
        {
            m_IsPlayerCaught = true;
        }


        void EndLevel(CanvasGroup imageCanvasGroup, AudioSource audioSource, bool doRestart = false)
        {

            if (!m_HasAudioPlayed)
            {
                audioSource.Play();
                m_HasAudioPlayed = true;
            }

            m_FadeTimer += Time.deltaTime;
            imageCanvasGroup.alpha = m_FadeTimer / m_FadeDuration;
            if (m_FadeTimer > m_FadeDuration + m_DisplayImageDuration)
            {

                if (doRestart)
                {
                    Restart();
                }
                else
                {
                    QuitGame();
                }

            }
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == m_PlayerGO)
            {
                //游戏结束
                m_IsPlayerAtExit = true;
            }
        }


        void Restart()
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


        private static void QuitGame()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
                //游戏结束
                Application.Quit();
#endif
        }

    }
}



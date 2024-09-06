using System.Collections.Generic;
using GameBlock;
using GameUI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameBasics
{
    public class GameController : MonoBehaviour
    {
        [Range(0f, 1f)]
        public float powerUpProbability = 0.2f;

        [HideInInspector]
        public bool isStarted = false;
        [HideInInspector]
        public bool isPaused = false;
        [HideInInspector]
        public int score = 0;

        private GUIController gUIController;
        private List<TouchManager> blocks = new();

        void Start()
        {
            var scene = SceneManager.GetActiveScene();
            if (scene.buildIndex == 0)
            {
                SaveScore();
            }
            else
            {
                LoadScore();
            }
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPaused = !isPaused;
                
                if (isPaused) PauseGame();
                else UnpauseGame();
            }
        }

        public void RegisterGuiController(GUIController uic)
        {
            gUIController = uic;
        }

        public void RegisterBlock(TouchManager block)
        {
            blocks.Add(block);
        }

        public void UnregisterBlock(TouchManager block)
        {
            blocks.Remove(block);
            if (blocks.Count == 0)
            {
                var scene = SceneManager.GetActiveScene();
                var index = scene.buildIndex + 1;
                if (index >= SceneManager.sceneCountInBuildSettings)
                {
                    WinGame();
                }
                else
                {
                    SaveScore();
                    SceneManager.LoadScene(index);
                }
            }
        }

        private void SaveScore()
        {
            PlayerPrefs.SetInt("score", score);
        }

        private void LoadScore()
        {
            if (PlayerPrefs.HasKey("score"))
            {
                score = PlayerPrefs.GetInt("score", score);
            }
        }

        public void PauseGame()
        {
            Time.timeScale = 0f;
        }

        public void UnpauseGame()
        {
            Time.timeScale = 1f;
        }

        public void WinGame()
        {
            PauseGame();
            gUIController.ShowWinPanel();
        }

        public void LoseGame()
        {
            PauseGame();
            gUIController.ShowLosePanel();
        }

        public void ResetGame()
        {
            UnpauseGame();
            SceneManager.LoadScene(0);
        }

        public void ExitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}

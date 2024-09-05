using GameBasics;
using UnityEngine;

namespace GameUI
{
    public class GUIController : MonoBehaviour
    {
        public GameObject pauseController;

        private GameController gameController;
        private bool lastPauseState = false;        
        
        void Start()
        {
            gameController = FindObjectOfType<GameController>();
            if (gameController == null) Debug.LogWarning("GameController wasn't found in the scene");

            lastPauseState = gameController.isPaused;
            SetState(lastPauseState);
        }

        void Update()
        {
            if (lastPauseState != gameController.isPaused)
            {
                lastPauseState = gameController.isPaused;
                SetState(lastPauseState);
            }
        }

        void SetState(bool state)
        {
            pauseController.SetActive(state);
        }
    }
}

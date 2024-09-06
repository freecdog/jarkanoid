using System;
using GameBasics;
using UnityEngine;
using UnityEngine.UI;

namespace GameUI
{
    public class GUIController : MonoBehaviour
    {
        public GameObject pausePanel;
        public Button pauseResetButton;
        public Button pauseExitButton;
        public GameObject winPanel;
        public Text winScoreText;
        public Button winResetButton;
        public GameObject losePanel;
        public Text loseScoreText;
        public Button loseResetButton;
        
        private GameController gameController;
        private bool lastPauseState = false;        
        
        void Start()
        {
            gameController = FindObjectOfType<GameController>();
            if (gameController == null) Debug.LogWarning("GameController wasn't found in the scene");

            gameController.RegisterGuiController(this);

            pauseExitButton.onClick.AddListener(OnExit);
            pauseResetButton.onClick.AddListener(OnReset);
            winResetButton.onClick.AddListener(OnReset);
            loseResetButton.onClick.AddListener(OnReset);

            HideAllPanels();

            lastPauseState = gameController.isPaused;
            SetPausePanelState(lastPauseState);
        }

        void Update()
        {
            if (lastPauseState != gameController.isPaused)
            {
                lastPauseState = gameController.isPaused;
                SetPausePanelState(lastPauseState);
            }
        }

        public void ShowWinPanel()
        {
            HideAllPanels();
            
            winScoreText.text = $"score: {gameController.score}";

            SetWinPanelState(true);
        }

        public void ShowLosePanel()
        {
            HideAllPanels();
            
            loseScoreText.text = $"score: {gameController.score}";
            
            SetLosePanelState(true);
        }

        private void HideAllPanels()
        {
            SetPausePanelState(false);
            SetWinPanelState(false);
            SetLosePanelState(false);
        }

        void SetPausePanelState(bool state)
        {
            pausePanel.SetActive(state);
        }

        void SetWinPanelState(bool state)
        {
            winPanel.SetActive(state);
        }

        void SetLosePanelState(bool state)
        {
            losePanel.SetActive(state);
        }

        private void OnReset()
        {
            gameController.ResetGame();
        }

        private void OnExit()
        {
            gameController.ExitGame();
        }
    }
}

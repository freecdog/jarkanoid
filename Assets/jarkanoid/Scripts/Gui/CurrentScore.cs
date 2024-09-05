using GameBasics;
using UnityEngine;
using UnityEngine.UI;

namespace GameUI
{
    [RequireComponent(typeof(Text))]
    public class CurrentScore : MonoBehaviour
    {
        private GameController gameController;
        private Text scoreText;
        private int lastScoreState = 0;        
        
        void Start()
        {
            gameController = FindObjectOfType<GameController>();
            if (gameController == null) Debug.LogWarning("GameController wasn't found in the scene");

            scoreText = GetComponent<Text>();

            lastScoreState = gameController.score;
            SetState(lastScoreState);
        }

        void Update()
        {
            if (lastScoreState != gameController.score)
            {
                lastScoreState = gameController.score;
                SetState(lastScoreState);
            }
        }

        void SetState(int state)
        {
            scoreText.text = state.ToString();
        }
    }
}

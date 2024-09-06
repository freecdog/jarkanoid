using GameBasics;
using UnityEngine;

namespace GameFloor
{
    public class GameOver : MonoBehaviour
    {
        private GameController gameController;

        void Start()
        {
            gameController = FindObjectOfType<GameController>();
            if (gameController == null) Debug.LogWarning("GameController wasn't found in the scene");
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.TryGetComponent(typeof(CircleCollider2D), out var circle))
            {
                gameController.LoseGame();
            }
        }
    }
}

using GameBasics;
using UnityEngine;

namespace GameBlock
{
    public class TouchManager : MonoBehaviour
    {
        public int tochesToResist = 1;
        public GameObject PowerUpPrefab;

        private GameController gameController;
        
        void Start()
        {
            gameController = FindObjectOfType<GameController>();
            if (gameController == null) Debug.LogWarning("GameController wasn't found in the scene");
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            tochesToResist--;
            if (tochesToResist <= 0)
            {
                gameController.score += 1;

                if (PowerUpPrefab != null)
                {
                    Instantiate(PowerUpPrefab, transform.position, Quaternion.identity);
                }
                Destroy(this.gameObject);
            }
        }
    }
}

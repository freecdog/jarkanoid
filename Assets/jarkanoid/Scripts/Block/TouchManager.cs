using GameBasics;
using UnityEngine;

namespace GameBlock
{
    public class TouchManager : MonoBehaviour
    {
        public int tochesToResist = 1;
        public GameObject PowerUpPrefab;

        private GameController gameController;
        private SpriteRenderer spriteRenderer;
        
        void Start()
        {
            gameController = FindObjectOfType<GameController>();
            if (gameController == null) Debug.LogWarning("GameController wasn't found in the scene");

            if (PowerUpPrefab == null) Debug.LogWarning("PowerUpPrefab wasn't added to the script");

            spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer == null) Debug.LogWarning("SpriteRenderer wasn't found in the object");

            Register();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            tochesToResist--;

            gameController.score += 1;

            if (tochesToResist <= 0)
            {
                Unregister();

                if (Random.Range(0f, 1f) < gameController.powerUpProbability)
                {
                    var go = Instantiate(PowerUpPrefab, transform.position, Quaternion.identity);
                    go.transform.Rotate(0, 0, 180);
                }

                Destroy(this.gameObject);
            }
            else
            {
                spriteRenderer.color = Random.ColorHSV(0f, 0.1f, 0.5f, 1f, 0.5f, 1f, 1f, 1f);
            }
        }

        void Register()
        {
            gameController.RegisterBlock(this);
        }

        void Unregister()
        {
            gameController.UnregisterBlock(this);
        }
    }
}

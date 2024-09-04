using GameBasics;
using UnityEngine;

namespace GameBall
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class StartImpulse : MonoBehaviour
    {
        public float speed = 5f;

        private GameController gameController;
        private Rigidbody2D rb;
        private bool isLaunched = false;

        void Start()
        {
            gameController = FindObjectOfType<GameController>();
            if (gameController == null) Debug.LogWarning("GameController wasn't found in the scene");

            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            float fire = Input.GetAxis("Fire1");
            float jump = Input.GetAxis("Jump");
            if (!isLaunched && (Mathf.Abs(fire) > 1e-6 || Mathf.Abs(jump) > 1e-6))
            {
                isLaunched = true;
                gameController.isStarted = true;
                // rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                rb.velocity = new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(0f, 1f)).normalized * speed;
            }
        }
    }
}

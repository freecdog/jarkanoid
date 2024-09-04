using GameBall;
using GameBasics;
using UnityEngine;

namespace GamePlatform
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlatformControl : MonoBehaviour
    {
        public float speed = 5f;

        private GameController gameController;
        private StartImpulse ballStartImpulse;
        private Rigidbody2D rb;

        private float platformWidthApprox = 3f;
        private float previousMagnitude = float.MinValue;

        void Start()
        {
            gameController = FindObjectOfType<GameController>();
            if (gameController == null) Debug.LogWarning("GameController wasn't found in the scene");

            ballStartImpulse = FindObjectOfType<StartImpulse>();
            if (ballStartImpulse == null) Debug.LogWarning("StartImpulse wasn't found in the scene");
            else previousMagnitude = ballStartImpulse.speed;

            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            float x = Input.GetAxis("Horizontal");
            if (Mathf.Abs(x) > 1e-6)
            {
                rb.velocity = new Vector2(Mathf.Sign(x) * speed, 0f);
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (!gameController.isStarted) return;
            if (!collision.gameObject.name.ToLowerInvariant().Contains("ball")) return;

            if (collision.gameObject.TryGetComponent<Rigidbody2D>(out var ballRb))
            {
                foreach (ContactPoint2D contactPoint in collision.contacts)
                {
                    float evenMagnitude = previousMagnitude;
                    float rate = previousMagnitude / ballRb.velocity.magnitude;
                    if (0.9f < rate && rate < 1.1f) 
                    {
                        evenMagnitude = ballRb.velocity.magnitude;
                    }

                    var newV = new Vector2(
                        (contactPoint.point.x - transform.position.x)*platformWidthApprox/2f,
                        Mathf.Abs(ballRb.velocity.y))
                        .normalized * evenMagnitude;

                    ballRb.velocity = newV;

                    break;
                }
            }
        }
    }
}

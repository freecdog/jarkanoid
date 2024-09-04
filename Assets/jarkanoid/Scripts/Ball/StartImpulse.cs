using UnityEngine;

namespace GameBall
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class StartImpulse : MonoBehaviour
    {
        public float speed = 5f;

        private Rigidbody2D rb;
        private bool isStarted = false;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            float fire = Input.GetAxis("Fire1");
            float jump = Input.GetAxis("Jump");
            if (!isStarted && (Mathf.Abs(fire) > 1e-6 || Mathf.Abs(jump) > 1e-6))
            {
                isStarted = true;
                rb.constraints = RigidbodyConstraints2D.None;
                // rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                rb.velocity = new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(0f, 1f)).normalized * speed;
            }
        }
    }
}

using UnityEngine;

namespace GameBall
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class VerticalSpeedController : MonoBehaviour
    {
        private Rigidbody2D rb;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void OnCollisionExit2D(Collision2D collision)
        {
            if (Mathf.Abs(rb.velocity.normalized.y) < 0.1f)
            {
                var sign = rb.velocity.y > 0 ? 1f : -1f;
                if (Mathf.Abs(rb.velocity.y) < 1e-6) sign = -1f;
                rb.velocity = new Vector2(
                    rb.velocity.normalized.x * 0.9f,
                    0.1f * sign)
                    .normalized * rb.velocity.magnitude;
            }
        }
    }
}

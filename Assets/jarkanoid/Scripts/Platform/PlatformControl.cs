using UnityEngine;

namespace GamePlatform
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlatformControl : MonoBehaviour
    {
        public float speed = 5f;
        private Rigidbody2D rb;

        void Start()
        {
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
    }
}

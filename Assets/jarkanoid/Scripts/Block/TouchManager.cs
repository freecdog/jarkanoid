using UnityEngine;

namespace GameBlock
{
    public class TouchManager : MonoBehaviour
    {
        public int tochesToResist = 1;
        public GameObject PowerUpPrefab;

        void OnCollisionEnter2D(Collision2D collision)
        {
            tochesToResist--;
            if (tochesToResist <= 0)
            {
                if (PowerUpPrefab != null)
                {
                    Instantiate(PowerUpPrefab, transform.position, Quaternion.identity);
                }
                Destroy(this.gameObject);
            }
        }
    }
}

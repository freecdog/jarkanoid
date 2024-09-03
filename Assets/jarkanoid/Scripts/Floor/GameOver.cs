using UnityEngine;

namespace GameFloor
{
    public class GameOver : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.TryGetComponent(typeof(CircleCollider2D), out var circle))
            {
                Debug.LogWarning("game over");
            }
        }
    }
}

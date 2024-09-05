using UnityEngine;

namespace GameBasics
{
    public class GameController : MonoBehaviour
    {
        [HideInInspector]
        public bool isStarted = false;
        [HideInInspector]
        public bool isPaused = false;
        [HideInInspector]
        public int score = 0;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPaused = !isPaused;
                
                Time.timeScale = isPaused ? 0f : 1f;
            }
        }
    }
}

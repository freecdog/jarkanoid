using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameUI
{
    [RequireComponent(typeof(Text))]
    public class CurrentLevel : MonoBehaviour
    {
        void Start()
        {
            var scene = SceneManager.GetActiveScene();
            GetComponent<Text>().text = $"Level: {scene.buildIndex}";
        }
    }
}

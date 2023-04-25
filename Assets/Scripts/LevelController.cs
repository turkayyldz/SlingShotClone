using UnityEngine;
using UnityEngine.SceneManagement;

namespace SlingShot
{
    public class LevelController : MonoBehaviour
    {
        private static int nextLevelIndex = 1;
        private Enemy[] enemies;


        private void OnEnable()
        {
            enemies = FindObjectsOfType<Enemy>();
        }
        private void Update()
        {
            foreach (Enemy enemy in enemies)
            {
                if (enemy != null)
                {
                    return;
                }
            }
            nextLevelIndex++;
            string nextLevelName = "Level" + nextLevelIndex;
            SceneManager.LoadScene(nextLevelName);
        }
    }

}

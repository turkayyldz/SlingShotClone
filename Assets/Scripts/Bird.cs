using UnityEngine;
using UnityEngine.SceneManagement;


namespace SlingShot
{
    public class Bird : MonoBehaviour
    {
        private Vector3 initialPosition;
        private bool birdWasLaunched;
        private float timeSittingAround;

        [SerializeField] private float _laubchPower = 500;


        private void Awake()
        {
            initialPosition = transform.position;
        }
        private void Update()
        {
            GetComponent<LineRenderer>().SetPosition(0, transform.position);
            GetComponent<LineRenderer>().SetPosition(1, initialPosition);

            if (birdWasLaunched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
            {
                timeSittingAround += Time.deltaTime;
            }
            if (transform.position.y > 20 || transform.position.y < -20 || transform.position.x > 20 || transform.position.x < -20 || timeSittingAround > 3)
            {
                string currentSceneName = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(currentSceneName);
            }

        }
        private void OnMouseDown()
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            GetComponent<LineRenderer>().enabled = true;
        }

        private void OnMouseUp()
        {
            GetComponent<SpriteRenderer>().color = Color.white;

            Vector2 directionToInitialPosition = initialPosition - transform.position;
            GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _laubchPower);
            GetComponent<Rigidbody2D>().gravityScale = 1;
            birdWasLaunched = true;
            GetComponent<LineRenderer>().enabled = false;
        }
        private void OnMouseDrag()
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(newPosition.x, newPosition.y);
        }
    }

}

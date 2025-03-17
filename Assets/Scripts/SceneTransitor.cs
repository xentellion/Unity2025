using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitor : MonoBehaviour
{
    [SerializeField] private string scene;

    private void OnTriggerEnter(Collider other)
    {
        // менорхлюкэмн
        if (other.gameObject.GetComponent<Player>() != null)
        {
            SceneManager.LoadScene(scene);
        }
    }
}

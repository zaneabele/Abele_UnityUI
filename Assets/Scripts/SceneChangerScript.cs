using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerScript : MonoBehaviour
{
   public void LoadWithDelay(string name) {
        StartCoroutine(LoadSceneAfterDelay(name));
    }

    private IEnumerator LoadSceneAfterDelay(string name) {
        yield return new WaitForSeconds(1.5f);
        // Ielādē ainu pēc tās nosaukuma
       SceneManager.LoadScene(name, LoadSceneMode.Single);

        // Ielādē ainu pēc tās indeksa
        // SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void QuitApplication() {
        Application.Quit();
    }
}

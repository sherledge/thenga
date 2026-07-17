using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SplashController : MonoBehaviour
{
    [SerializeField] private CanvasGroup logoGroup;
    [SerializeField] private AudioSource jingleSound;
    [SerializeField] private float fadeInTime = 0.6f;
    [SerializeField] private float holdTime = 1.2f;
    [SerializeField] private float fadeOutTime = 0.6f;
    [SerializeField] private string nextSceneName = "Home";

    private void Start()
    {
        logoGroup.alpha = 0f;
        jingleSound.Play();
        StartCoroutine(PlaySplash());
    }

    private IEnumerator PlaySplash()
    {
        yield return Fade(0f, 1f, fadeInTime);
        yield return new WaitForSeconds(holdTime);
        yield return Fade(1f, 0f, fadeOutTime);
        SceneManager.LoadScene(nextSceneName);
    }

    private IEnumerator Fade(float from, float to, float duration)
    {
        float t = 0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            logoGroup.alpha = Mathf.Lerp(from, to, t / duration);
            yield return null;
        }
        logoGroup.alpha = to;
    }
}
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;   // ← ADD THIS LINE

public class GameCardUI : MonoBehaviour
{
    [SerializeField] private Image thumbnailImage;
    [SerializeField] private TMP_Text nameText; // use TMP_Text if using TextMeshPro
    [SerializeField] private Button cardButton;
    [SerializeField] private AudioSource clickSound;

    private GameEntry data;

    public void Setup(GameEntry entry)
    {
        data = entry;
        if (thumbnailImage != null && entry.thumbnail != null)
       thumbnailImage.sprite = entry.thumbnail;
        nameText.text = entry.gameName;
        cardButton.onClick.RemoveAllListeners();
        cardButton.onClick.AddListener(OnCardClicked);
    }

    private void OnCardClicked()
    {
        if (clickSound != null) clickSound.Play();
        StartCoroutine(LoadWithDelay());
    }

    private System.Collections.IEnumerator LoadWithDelay()
    {
        // small delay so click sound is audible before scene unloads
        yield return new WaitForSeconds(0.15f);
        SceneManager.LoadScene(data.sceneName);
    }
}
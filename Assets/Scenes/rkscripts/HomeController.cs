using UnityEngine;
using System.Collections.Generic;

public class HomeController : MonoBehaviour
{
    [SerializeField] private List<GameEntry> games; // drag your ScriptableObjects here
    [SerializeField] private GameCardUI cardPrefab;
    [SerializeField] private Transform gridParent;   // the Content object with Grid Layout Group

    private void Start()
    {
        foreach (var game in games)
        {
            GameCardUI card = Instantiate(cardPrefab, gridParent);
            card.Setup(game);
        }
    }
}
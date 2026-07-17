using UnityEngine;

[CreateAssetMenu(fileName = "NewGameEntry", menuName = "PartyHub/Game Entry")]
public class GameEntry : ScriptableObject
{
    public string gameName;
    public Sprite thumbnail;
    public string sceneName;   // exact scene name as in Build Settings
    [TextArea] public string description;
}
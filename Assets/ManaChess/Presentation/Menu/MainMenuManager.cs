using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] PlayerProfile playerProfile;

    [SerializeField] Button profileBtn;

    void Start()
    {
        profileBtn.onClick.AddListener(playerProfile.TransitionToProfileUI);
    }
}

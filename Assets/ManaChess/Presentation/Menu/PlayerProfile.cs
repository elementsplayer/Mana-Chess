using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProfile : MonoBehaviour
{
    [SerializeField] GameObject mainMenuWrapper;

    [SerializeField] Button modifyBtn;
    [SerializeField] TMP_InputField nameField;
    [SerializeField] Sprite confirmIcon;

    Sprite modifyIcon;
    Image modifyBtnIcon;
    bool isConfirmed = false;

    void Start()
    {
        modifyBtn.onClick.AddListener(SwitchModifyState);
    }

    public void TransitionToProfileUI()
    {
        mainMenuWrapper.SetActive(false);
        gameObject.SetActive(true);
    }

    void SwitchModifyState()
    {
        if (!isConfirmed)
        {
            ModifyName();
            isConfirmed = true;
        }
        else
        {
            ConfirmName();
            isConfirmed = false;
        }
    }

    void ModifyName()
    {
        nameField.interactable = true;
        modifyBtnIcon = modifyBtn.GetComponent<Image>();
        modifyIcon = modifyBtn.GetComponent<Image>().sprite;
        modifyBtnIcon.sprite = confirmIcon;
    }

    void ConfirmName()
    {
        nameField.interactable = false;
        modifyBtnIcon.sprite = modifyIcon;
    }
}

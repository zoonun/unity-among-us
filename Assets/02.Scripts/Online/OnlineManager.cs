using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UIElements.Button;

public class OnlineManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField nickNameInputField;
    [SerializeField] private GameObject roomMakeUI;
    
    private UIDocument _doc;
    private VisualElement _root;

    private Button _backBtn;
    
    [SerializeField]
    private GameObject _menuObj;
    [SerializeField]
    private GameObject _onlineObj;

    private void OnEnable()
    {
        try
        {
            _doc = GetComponent<UIDocument>();
            _root = _doc.rootVisualElement;

            _backBtn = _root.Q<Button>("btn__back");
            _backBtn.clicked += OnClickBack;
        }
        catch (Exception e)
        {
            Debug.LogError(e + " " + e.Message);
        }
    }

    private void OnClickBack()
    {
        if (_menuObj != null && _onlineObj != null)
        {
            _menuObj.SetActive(true);
            _onlineObj.SetActive(false);
        }
    }

    public void OnClickCreateRoomButton()
    {
        if (nickNameInputField.text != "")
        {
            nickNameInputField.text = PlayerSetting.nickname;
            roomMakeUI.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            nickNameInputField.GetComponent<Animator>().SetTrigger("on");
        }
    }
}
using System;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuManager : MonoBehaviour
{
    private UIDocument _doc;
    private VisualElement _root;
    private VisualElement _rootContainer;
    [SerializeField]
    private GameObject _menuObj;
    [SerializeField]
    private GameObject _onlineObj;

    // Setting
    private VisualElement _settingContainer;
    private Button _settingBtn;
    private Button _settingCloseBtn;
    private Button _settingMouseBtn;
    private Button _settingKeyboardMouseBtn;

    // Game Control
    private Button _onlineBtn;
    private Button _endBtn;

    // Start is called before the first frame update
    private void OnEnable()
    {
        try
        {
            _doc = GetComponent<UIDocument>();
            _root = _doc.rootVisualElement;
            _rootContainer = _root.Q<VisualElement>("root_container");
            
            // Settings UI
            _settingContainer = _root.Q<VisualElement>("setting_container");
            _settingContainer.style.scale = new StyleScale(new Scale(new Vector2(0, 0)));
            _settingBtn = _root.Q<Button>("btn__setting");
            _settingBtn.clicked += OnClickSetting;
            _settingCloseBtn = _root.Q<Button>("btn__setting__close");
            _settingCloseBtn.clicked += OnClickSettingClose;
            
            // 세팅 창 외의 영역을 클릭하면 닫히도록 설정
            // _rootContainer.RegisterCallback<ClickEvent>(evt =>
            // {
            //     Debug.Log(evt.currentTarget.ToString());
            //     OnClickSettingClose();
            // });

            // Settings Control
            _settingMouseBtn = _root.Q<Button>("btn__setting__mouse");
            _settingMouseBtn.clicked += OnclickMouseSetting;
            _settingKeyboardMouseBtn = _root.Q<Button>("btn__setting__keyboard__mouse");
            _settingKeyboardMouseBtn.clicked += OnClickKeyboardMouseSetting;
            
            // Game Control
            _onlineBtn = _root.Q<Button>("btn__online");
            _onlineBtn.clicked += OnClickOnline;
            _endBtn = _root.Q<Button>("btn__end");
            _endBtn.clicked += OnClickEnd;
            
            switch (PlayerSetting.controlType)
            {
                case EControlType.Mouse:
                    _settingMouseBtn.style.color = Color.green;
                    _settingKeyboardMouseBtn.style.color = Color.white;
                    break;
            
                case EControlType.KeyboardMouse:
                    _settingMouseBtn.style.color = Color.white;
                    _settingKeyboardMouseBtn.style.color = Color.green;
                    break;
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e + " " + e.Message);
        }
    }

    private void OnClickSetting()
    {
        _settingContainer.style.opacity = 1;
        _settingContainer.style.scale = new StyleScale(new Scale(new Vector2(1, 1)));
        
    }
    private void OnClickSettingClose()
    {
        _settingContainer.style.scale = new StyleScale(new Scale(new Vector2(0, 0)));
    }
    private void OnclickMouseSetting()
    {
        SetControlMode(0);
    }
    private void OnClickKeyboardMouseSetting()
    {
        SetControlMode(1);
    }
    
    public void SetControlMode(int controlType)
    {
        PlayerSetting.controlType = (EControlType)controlType;
        
        switch (PlayerSetting.controlType)
        {
            case EControlType.Mouse:
                _settingMouseBtn.style.color = Color.green;
                _settingKeyboardMouseBtn.style.color = Color.white;
                break;
            
            case EControlType.KeyboardMouse:
                _settingMouseBtn.style.color = Color.white;
                _settingKeyboardMouseBtn.style.color = Color.green;
                break;
        }
    }

    public void OnClickOnline()
    {
        if (_menuObj != null && _onlineObj != null)
        {
            _menuObj.SetActive(false);
            _onlineObj.SetActive(true);
        }
    }
    public void OnClickEnd()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();        
#endif
    }
}

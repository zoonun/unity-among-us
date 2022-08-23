using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuManager : MonoBehaviour
{
    private UIDocument _doc;
    private VisualElement _root;

    // Setting
    private VisualElement _settingContainer;
    private Button _settingBtn;
    private Button _settingCloseBtn;
    private Button _settingMouseBtn;
    private Button _settingKeyboardMouseBtn;
    
    
    // Start is called before the first frame update
    private void OnEnable()
    {
        try
        {
            _doc = GetComponent<UIDocument>();
            _root = _doc.rootVisualElement;
            
            // Settings UI
            _settingContainer = _root.Q<VisualElement>("setting_container");
            _settingContainer.style.scale = new StyleScale(new Scale(new Vector2(0, 0)));
            _settingBtn = _root.Q<Button>("btn__setting");
            _settingBtn.clicked += SettingClick;
            _settingCloseBtn = _root.Q<Button>("btn__setting__close");
            _settingCloseBtn.clicked += SettingCloseClick;
            
            // Settings Control
            _settingMouseBtn = _root.Q<Button>("btn__setting__mouse");
            _settingMouseBtn.clicked += SettingMouseClick;
            _settingKeyboardMouseBtn = _root.Q<Button>("btn__setting__keyboard__mouse");
            _settingKeyboardMouseBtn.clicked += SettingKeyboardMouseClick;
            
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

    private void SettingClick()
    {
        _settingContainer.style.scale = new StyleScale(new Scale(new Vector2(1, 1)));
    } 
    
    private void SettingCloseClick()
    {
        _settingContainer.style.scale = new StyleScale(new Scale(new Vector2(0, 0)));
    }
    private void SettingMouseClick()
    {   
        SetControlMode(0);
    }
    private void SettingKeyboardMouseClick()
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
}

using UnityEngine;
using UnityEngine.InputSystem;

public class InputManagerLR : MonoBehaviour
{
    static InputManagerLR m_instance;

    // あとでInspectorのActionAsset欄にInput Actionを代入する
    [SerializeField]
    InputActionAsset m_actionAsset;

    InputActionMap m_ActionMap;
    InputAction m_PrimaryButtonR;
    InputAction m_PrimaryButtonL;
    InputAction m_SecondaryButtonR;
    InputAction m_SecondaryButtonL;

    InputAction m_TriggerPressR;

    InputAction m_TriggerPressL;
    private void Awake()
    {
        m_instance = this;
        // InputActionマネージャーをシーンから破棄しないようにする
        GameObject.DontDestroyOnLoad(gameObject);
        // Action Mapsの名前を入れる
        m_ActionMap = m_actionAsset.FindActionMap("Test");
        // Actionsの名前をすべて入れる
        m_PrimaryButtonR = m_ActionMap.FindAction("PrimaryButtonR", throwIfNotFound: true);
        m_PrimaryButtonL = m_ActionMap.FindAction("PrimaryButtonL", throwIfNotFound: true);
        m_SecondaryButtonR = m_ActionMap.FindAction("SecondaryButtonR", throwIfNotFound: true);
        m_SecondaryButtonL = m_ActionMap.FindAction("SecondaryButtonL", throwIfNotFound: true);
        m_TriggerPressR = m_ActionMap.FindAction("TriggerPressR", throwIfNotFound: true);
        m_TriggerPressL = m_ActionMap.FindAction("TriggerPressL", throwIfNotFound: true);
    }

    private void OnEnable()
    {
        m_ActionMap?.Enable();
    }

    private void OnDisable()
    {
        m_ActionMap?.Disable();
    }

    public static bool PrimaryButtonR()
    {
        if (m_instance == null) { Debug.LogError("InputManagerLR instance not found."); return false; }
        return m_instance.m_PrimaryButtonR.IsPressed();
    }

    public static bool PrimaryButtonR_OnPress()
    {
        if (m_instance == null) { Debug.LogError("InputManagerLR instance not found."); return false; }
        return m_instance.m_PrimaryButtonR.WasPressedThisFrame();
    }

    public static bool PrimaryButtonR_OnRelease()
    {
        if (m_instance == null) { Debug.LogError("InputManagerLR instance not found."); return false; }
        return m_instance.m_PrimaryButtonR.WasReleasedThisFrame();
    }

    public static bool SecondaryButtonR()
    {
        if (m_instance == null) { Debug.LogError("InputManagerLR instance not found."); return false; }
        return m_instance.m_SecondaryButtonR.IsPressed();
    }

    public static bool SecondaryButtonR_OnPress()
    {
        if (m_instance == null) { Debug.LogError("InputManagerLR instance not found."); return false; }
        return m_instance.m_SecondaryButtonR.WasPressedThisFrame();
    }

    public static bool SecondaryButtonR_OnRelease()
    {
        if (m_instance == null) { Debug.LogError("InputManagerLR instance not found."); return false; }
        return m_instance.m_SecondaryButtonR.WasReleasedThisFrame();
    }

    public static bool PrimaryButtonL()
    {
        if (m_instance == null) { Debug.LogError("InputManagerLR instance not found."); return false; }
        return m_instance.m_PrimaryButtonL.IsPressed();
    }

    public static bool PrimaryButtonL_OnPress()
    {
        if (m_instance == null) { Debug.LogError("InputManagerLR instance not found."); return false; }
        return m_instance.m_PrimaryButtonL.WasPressedThisFrame();
    }

    public static bool PrimaryButtonL_OnRelease()
    {
        if (m_instance == null) { Debug.LogError("InputManagerLR instance not found."); return false; }
        return m_instance.m_PrimaryButtonL.WasReleasedThisFrame();
    }

    public static bool SecondaryButtonL()
    {
        if (m_instance == null) { Debug.LogError("InputManagerLR instance not found."); return false; }
        return m_instance.m_SecondaryButtonL.IsPressed();
    }

    public static bool SecondaryButtonL_OnPress()
    {
        if (m_instance == null) { Debug.LogError("InputManagerLR instance not found."); return false; }
        return m_instance.m_SecondaryButtonL.WasPressedThisFrame();
    }

    public static bool SecondaryButtonL_OnRelease()
    {
        if (m_instance == null) { Debug.LogError("InputManagerLR instance not found."); return false; }
        return m_instance.m_SecondaryButtonL.WasReleasedThisFrame();
    }

    public static bool WasTriggerPressedR()
    {
        if (m_instance == null) { Debug.LogError("InputManagerLR instance not found."); return false; }
        return m_instance.m_TriggerPressR.WasPressedThisFrame();
    }

    public static bool IsTriggerPressR()
    {
        if (m_instance == null) { Debug.LogError("InputManagerLR instance not found."); return false; }
        return m_instance.m_TriggerPressR.IsPressed();
    }

    public static bool WasTriggerPressedL()
    {
        if (m_instance == null) { Debug.LogError("InputManagerLR instance not found."); return false; }
        return m_instance.m_TriggerPressL.WasPressedThisFrame();
    }

    public static bool IsTriggerPressL()
    {
        if (m_instance == null) { Debug.LogError("InputManagerLR instance not found."); return false; }
        return m_instance.m_TriggerPressL.IsPressed();
    }
}
using UnityEngine;


[RequireComponent(typeof(UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable))]
public class EraserController : MonoBehaviour
{
    [Header("Eraser Properties")]
    [SerializeField] private SphereCollider m_EraserCollider; // 消しゴムの判定用コライダー

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable m_GrabInteractable;
    private bool m_IsErasing = false;

    private void Awake()
    {
        m_GrabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        if (m_EraserCollider == null)
        {
            m_EraserCollider = GetComponentInChildren<SphereCollider>();
        }
        // コライダーをトリガーとして設定
        if (m_EraserCollider != null)
        {
            m_EraserCollider.isTrigger = true;
        }
        else
        {
            Debug.LogError("Eraser Collider is not assigned and could not be found in children.", this);
        }
    }

    private void Update()
    {
        // 消しゴムが掴まれていて、かつ左右どちらかのトリガーが引かれているか
        bool isTriggerPressed = InputManagerLR.IsTriggerPressR() || InputManagerLR.IsTriggerPressL();
        
        if (m_GrabInteractable.isSelected && isTriggerPressed)
        {
            m_IsErasing = true;
        }
        else
        {
            m_IsErasing = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // 消去モード中でなければ何もしない
        if (!m_IsErasing) return;

        // 接触したオブジェクトにLineRendererコンポーネントがあるか確認
        if (other.gameObject.GetComponent<LineRenderer>() != null)
        {
            // 線オブジェクトを破壊する
            Destroy(other.gameObject);
        }
    }
}

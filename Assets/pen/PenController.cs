using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable))]
public class PenController : MonoBehaviour
{
    [Header("Pen Properties")]
    [SerializeField] private Transform m_PenTip; // ペン先のTransform
    [SerializeField] private Material m_LineMaterial; // 線のマテリアル
    [SerializeField] private float m_LineWidth = 0.005f;
    [SerializeField] private Color m_LineColor = Color.white;
    [SerializeField] private float m_MinDrawDistance = 0.001f; // 最小描画距離

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable m_GrabInteractable;
    private LineRenderer m_CurrentLine;
    private List<Vector3> m_CurrentLinePositions = new List<Vector3>();
    private bool m_IsDrawing = false;

    private void Awake()
    {
        m_GrabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
    }

    private void OnEnable()
    {
        // ペンが掴まれた時と離された時のイベントにリスナーを登録
        m_GrabInteractable.selectExited.AddListener(OnRelease);
    }

    private void OnDisable()
    {
        m_GrabInteractable.selectExited.RemoveListener(OnRelease);
    }

    private void Update()
    {
        // ペンが掴まれているか確認
        if (m_GrabInteractable.isSelected)
        {
            // トリガーが引かれているか確認
            if (InputManagerLR.IsTriggerPressR() || InputManagerLR.IsTriggerPressL())
            {
                // 描画中でなければ描画を開始
                if (!m_IsDrawing)
                {
                    StartDrawing();
                }
                // 描画中にペン先を更新
                UpdateDrawing();
            }
            else
            {
                // トリガーが離されたら描画を終了
                if (m_IsDrawing)
                {
                    StopDrawing();
                }
            }
        }
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        // ペンを離したら描画を強制終了
        if (m_IsDrawing)
        {
            StopDrawing();
        }
    }

    private void StartDrawing()
    {
        m_IsDrawing = true;

        // 新しい線オブジェクトを作成
        GameObject lineObject = new GameObject("Line");
        m_CurrentLine = lineObject.AddComponent<LineRenderer>();

        // 線に当たり判定を追加するためのMeshCollider
        var meshCollider = lineObject.AddComponent<MeshCollider>();
        // Rigidbodyも追加（IsKinematicにして物理演算の影響をなくす）
        var rigidBody = lineObject.AddComponent<Rigidbody>();
        rigidBody.isKinematic = true;


        // LineRendererの設定
        m_CurrentLine.material = m_LineMaterial;
        m_CurrentLine.startWidth = m_LineWidth;
        m_CurrentLine.endWidth = m_LineWidth;
        m_CurrentLine.startColor = m_LineColor;
        m_CurrentLine.endColor = m_LineColor;
        m_CurrentLine.positionCount = 0;
        m_CurrentLine.useWorldSpace = true; // ワールド空間で描画

        // 最初の点を2つ同じ位置に追加して、長さ0の線から始める
        m_CurrentLinePositions.Clear();
        AddPoint(m_PenTip.position);
        AddPoint(m_PenTip.position);
    }

    private void UpdateDrawing()
    {
        if (m_CurrentLine == null || m_PenTip == null) return;

        // 最後の点を常にペン先の位置に更新する
        m_CurrentLinePositions[m_CurrentLinePositions.Count - 1] = m_PenTip.position;
        m_CurrentLine.SetPositions(m_CurrentLinePositions.ToArray());

        // 最後から2番目の点との距離を測り、十分な距離があれば新しい点を追加する
        if (m_CurrentLinePositions.Count >= 2)
        {
            float distance = Vector3.Distance(m_CurrentLinePositions[m_CurrentLinePositions.Count - 2], m_PenTip.position);
            if (distance > m_MinDrawDistance)
            {
                // 新しい点を追加する前に、MeshColliderを更新
                UpdateMeshCollider();
                AddPoint(m_PenTip.position);
            }
        }
    }

    private void StopDrawing()
    {
        // 描画終了時にもMeshColliderを更新
        UpdateMeshCollider();
        m_IsDrawing = false;
        m_CurrentLine = null;
        m_CurrentLinePositions.Clear();
    }

    private void AddPoint(Vector3 position)
    {
        m_CurrentLinePositions.Add(position);
        m_CurrentLine.positionCount = m_CurrentLinePositions.Count;
        m_CurrentLine.SetPositions(m_CurrentLinePositions.ToArray());
    }

    private void UpdateMeshCollider()
    {
        if (m_CurrentLine != null && m_CurrentLine.positionCount > 1)
        {
            var meshCollider = m_CurrentLine.GetComponent<MeshCollider>();
            if (meshCollider != null)
            {
                var mesh = new Mesh();
                m_CurrentLine.BakeMesh(mesh, true);
                meshCollider.sharedMesh = mesh;
            }
        }
    }
}

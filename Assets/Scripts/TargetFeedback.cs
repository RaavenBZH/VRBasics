using UnityEngine;

public class TargetFeedback : MonoBehaviour
{
    [SerializeField] private Renderer targetRenderer;
    [SerializeField] private Color firstColor = new Color(0.25f, 0.55f, 0.9f);
    [SerializeField] private Color secondColor = new Color(0.9f, 0.45f, 0.2f);
    [SerializeField] private Color hoverColor = new Color(1f, 0.85f, 0.3f);

    private Material m_MaterialInstance;
    private bool m_IsHovered;
    private bool m_UseSecondColor;

    private void Awake()
    {
        m_MaterialInstance = targetRenderer.material;
        UpdateAppearance();
    }

    private void OnDestroy()
    {
        if (m_MaterialInstance != null)
            Destroy(m_MaterialInstance);
    }

    public void BeginHover()
    {
        m_IsHovered = true;
        UpdateAppearance();
    }

    public void EndHover()
    {
        m_IsHovered = false;
        UpdateAppearance();
    }

    public void ToggleColor()
    {
        m_UseSecondColor = !m_UseSecondColor;
        UpdateAppearance();
    }

    private void UpdateAppearance()
    {
        if (m_IsHovered)
            m_MaterialInstance.color = hoverColor;
        else
            m_MaterialInstance.color = m_UseSecondColor ? secondColor : firstColor;
    }
}

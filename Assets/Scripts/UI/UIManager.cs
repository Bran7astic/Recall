using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private Label interactionLabel;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        // Get UI root & the prompt label
        var root = GetComponent<UIDocument>().rootVisualElement;
        interactionLabel = root.Q<Label>("interactionPrompt");

        HideInteractionText();
    }

    public void ShowInteractionText(string message)
    {
        interactionLabel.text = message;
        interactionLabel.style.display = DisplayStyle.Flex;
    }

    public void ShowInteractionText(string message, float duration)
    {
        ShowInteractionText(message);
        CancelInvoke(nameof(HideInteractionText));
        Invoke(nameof(HideInteractionText), duration);
    }


    public void HideInteractionText()
    {
        interactionLabel.style.display = DisplayStyle.None;
    }
}

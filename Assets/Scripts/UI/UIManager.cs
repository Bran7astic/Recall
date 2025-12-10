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
        Debug.Log("Removing container-hidden...");
        interactionLabel.RemoveFromClassList("container-hidden");
    }

    public void ShowInteractionText(string message, float duration)
    {
        ShowInteractionText(message);
        CancelInvoke(nameof(HideInteractionText));
        Invoke(nameof(HideInteractionText), duration);
    }


    public void HideInteractionText()
    {
        interactionLabel.AddToClassList("container-hidden");
    }
}

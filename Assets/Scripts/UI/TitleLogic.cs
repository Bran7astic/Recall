using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TitleLogic : MonoBehaviour
{

    private VisualElement root;
    public float ampltiude = 5f;
    public float frequency = 2f;

    public Label titleLabel;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        var doc = GetComponent<UIDocument>();
        root = doc.rootVisualElement;
        titleLabel = root.Q<Label>("title");
        startPos = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (titleLabel == null) return;
        
        float offset = Mathf.Sin(Time.time * frequency);
        titleLabel.style.translate = new Translate(0, offset * ampltiude, 0);
        
    }
}

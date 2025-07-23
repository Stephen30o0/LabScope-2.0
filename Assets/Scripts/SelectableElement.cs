using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SelectableElement : MonoBehaviour
{
    private ElementSelected elementSelected;

    private void Start()
    {
        elementSelected = GameObject.Find("Controller").GetComponent<ElementSelected>();
        
        // Check if this is a periodic table element or an atom
        if (transform.parent != null && transform.parent.name == "PeriodicTable")
        {
            // This is a periodic table element
            var interactable = GetComponent<XRSimpleInteractable>();
            if (interactable == null)
            {
                interactable = gameObject.AddComponent<XRSimpleInteractable>();
            }
            interactable.selectEntered.AddListener(OnSelect);
        }
    }

    private void OnSelect(SelectEnterEventArgs args)
    {
        // For periodic table elements, pass the button that was selected
        elementSelected.selected(gameObject);
    }

    // Alternative method for direct button press (fallback)
    public void OnButtonPress()
    {
        elementSelected.selected(gameObject);
    }
}

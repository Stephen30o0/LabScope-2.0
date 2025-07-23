using UnityEngine;
using System.Reflection;

public class InworldSetup : MonoBehaviour
{
    public static void Execute()
    {
        Debug.Log("Setting up Inworld configuration...");
        
        // Find the InworldController
        GameObject inworldController = GameObject.Find("InworldController");
        if (inworldController == null)
        {
            Debug.LogError("InworldController not found in scene!");
            return;
        }
        
        // Check all components on InworldController
        Component[] components = inworldController.GetComponents<Component>();
        foreach (Component comp in components)
        {
            Debug.Log($"Component: {comp.GetType().Name}");
            
            if (comp.GetType().Name.Contains("InworldClient"))
            {
                // Check if API credentials are set
                var apiKeyField = comp.GetType().GetField("aPIKey", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
                var apiSecretField = comp.GetType().GetField("aPISecret", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
                var sceneField = comp.GetType().GetField("sceneFullName", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
                
                if (apiKeyField != null)
                {
                    string apiKey = apiKeyField.GetValue(comp) as string;
                    Debug.Log($"API Key set: {!string.IsNullOrEmpty(apiKey)}");
                }
                
                if (apiSecretField != null)
                {
                    string apiSecret = apiSecretField.GetValue(comp) as string;
                    Debug.Log($"API Secret set: {!string.IsNullOrEmpty(apiSecret)}");
                }
                
                if (sceneField != null)
                {
                    string scene = sceneField.GetValue(comp) as string;
                    Debug.Log($"Scene configured: {!string.IsNullOrEmpty(scene)} - {scene}");
                }
            }
        }
        
        // List available microphones
        string[] devices = Microphone.devices;
        Debug.Log($"Available microphone devices ({devices.Length}):");
        for (int i = 0; i < devices.Length; i++)
        {
            Debug.Log($"  {i}: {devices[i]}");
        }
        
        // Check if microphone permissions
        if (devices.Length == 0)
        {
            Debug.LogWarning("No microphone devices found! Check microphone permissions.");
        }
        
        // Check character configuration
        GameObject labAssistant = GameObject.Find("lab_assistant_default-jcyratoyovljpj0fpqt5oq");
        if (labAssistant != null)
        {
            Debug.Log("Lab assistant found!");
            Component[] assistantComponents = labAssistant.GetComponents<Component>();
            foreach (Component comp in assistantComponents)
            {
                Debug.Log($"Assistant Component: {comp.GetType().Name}");
            }
        }
        else
        {
            Debug.LogError("Lab assistant not found in scene!");
        }
        
        Debug.Log("Inworld setup analysis completed!");
    }
}
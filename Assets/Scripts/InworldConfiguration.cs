using UnityEngine;
using System.Reflection;

public class InworldConfiguration : MonoBehaviour
{
    public static void Execute()
    {
        Debug.Log("Configuring Inworld AI Assistant...");
        
        // Find the InworldController
        GameObject inworldController = GameObject.Find("InworldController");
        if (inworldController == null)
        {
            Debug.LogError("InworldController not found!");
            return;
        }
        
        // Get all components and find the ones we need
        Component[] allComponents = inworldController.GetComponents<Component>();
        Component inworldClient = null;
        Component inworldControllerComp = null;
        Component audioCapture = null;
        
        foreach (Component comp in allComponents)
        {
            string typeName = comp.GetType().Name;
            if (typeName.Contains("InworldClient"))
            {
                inworldClient = comp;
                Debug.Log("✅ Found InworldClient component");
            }
            else if (typeName.Contains("InworldController"))
            {
                inworldControllerComp = comp;
                Debug.Log("✅ Found InworldController component");
            }
            else if (typeName.Contains("InworldAECAudioCapture"))
            {
                audioCapture = comp;
                Debug.Log("✅ Found Audio capture component");
            }
        }
        
        if (inworldClient == null)
        {
            Debug.LogError("InworldClient component not found!");
            return;
        }
        
        // Set the Bearer token
        string bearerToken = "Bearer V29Qc25RdHpGejNWNmhUdG5ZdVBHNG1wZHBzbDE3MzI6bUtYMWdxUzhtaHN5d3k0YnZhVEZ3R0hQNlUwNFZjeU40UURQeXluQ3UycnlEd2FZSUpNOE1wam5oN1RZRHZsaA==";
        
        // Configure InworldClient
        System.Type clientType = inworldClient.GetType();
        
        var customTokenField = clientType.GetField("customToken");
        if (customTokenField != null)
        {
            customTokenField.SetValue(inworldClient, bearerToken);
            Debug.Log("✅ Custom token configured");
        }
        else
        {
            Debug.LogWarning("Custom token field not found, trying alternatives...");
            // Try other possible field names
            var tokenField = clientType.GetField("token");
            var authTokenField = clientType.GetField("authToken");
            if (tokenField != null)
            {
                tokenField.SetValue(inworldClient, bearerToken);
                Debug.Log("✅ Token configured (alternative field)");
            }
            else if (authTokenField != null)
            {
                authTokenField.SetValue(inworldClient, bearerToken);
                Debug.Log("✅ Auth token configured (alternative field)");
            }
        }
        
        // Set the scene name
        var sceneField = clientType.GetField("sceneFullName");
        if (sceneField != null)
        {
            string sceneName = "workspaces/unitytest/scenes/transform";
            sceneField.SetValue(inworldClient, sceneName);
            Debug.Log($"✅ Scene configured: {sceneName}");
        }
        
        // Configure InworldController
        if (inworldControllerComp != null)
        {
            System.Type controllerType = inworldControllerComp.GetType();
            var controllerSceneField = controllerType.GetField("sceneFullName");
            if (controllerSceneField != null)
            {
                controllerSceneField.SetValue(inworldControllerComp, "workspaces/unitytest/scenes/transform");
                Debug.Log("✅ Controller scene configured");
            }
        }
        
        // Check audio capture configuration
        if (audioCapture != null)
        {
            // Check if microphone is available
            string[] devices = Microphone.devices;
            if (devices.Length > 0)
            {
                Debug.Log($"✅ Microphone available: {devices[0]}");
            }
            else
            {
                Debug.LogWarning("⚠️ No microphone devices found. Check microphone permissions.");
            }
        }
        
        // Check character setup
        GameObject labAssistant = GameObject.Find("lab_assistant_default-jcyratoyovljpj0fpqt5oq");
        if (labAssistant != null)
        {
            Debug.Log("✅ Lab assistant character found");
            
            // Ensure character has AudioSource
            AudioSource audioSource = labAssistant.GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = labAssistant.AddComponent<AudioSource>();
                Debug.Log("✅ Added AudioSource to character");
            }
            
            // Configure AudioSource for 3D audio
            audioSource.spatialBlend = 1.0f; // 3D audio
            audioSource.maxDistance = 10.0f;
            audioSource.rolloffMode = AudioRolloffMode.Logarithmic;
            
            Debug.Log("✅ Character audio configured");
        }
        
        Debug.Log("=== INWORLD CONFIGURATION COMPLETE ===");
        Debug.Log("Next steps:");
        Debug.Log("1. Make sure your Inworld workspace 'unitytest' exists");
        Debug.Log("2. Verify your scene 'transform' is created in Inworld Studio");
        Debug.Log("3. Ensure your character is assigned to the scene");
        Debug.Log("4. Grant microphone permissions if prompted");
        Debug.Log("5. Try speaking to the assistant!");
    }
}
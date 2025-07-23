using UnityEngine;
using System.Reflection;
using System;

public class InworldRuntimeSetup : MonoBehaviour
{
    void Start()
    {
        // Wait a moment for other components to initialize
        Invoke("ConfigureInworld", 1.0f);
    }
    
    void ConfigureInworld()
    {
        Debug.Log("=== CONFIGURING INWORLD AT RUNTIME ===");
        
        // Decoded credentials from the Bearer token
        string apiKey = "WoPsnQtzFz3V6hTtnYuPG4mpdpsl1732";
        string apiSecret = "mKX1gqS8mhsywy4bvaTFwGHP6U04VcyN4QDPyynCu2ryDwaYIJM8Mpjnh7TYDvlh";
        string sceneName = "workspaces/unitytest/scenes/transform";
        
        // Find the InworldController
        GameObject inworldController = GameObject.Find("InworldController");
        if (inworldController == null)
        {
            Debug.LogError("InworldController not found!");
            return;
        }
        
        // Get all components and configure them
        Component[] allComponents = inworldController.GetComponents<Component>();
        
        foreach (Component comp in allComponents)
        {
            string typeName = comp.GetType().Name;
            
            // Configure InworldClient
            if (typeName.Contains("InworldClient"))
            {
                // Set API credentials
                SetFieldValue(comp, "aPIKey", apiKey);
                SetFieldValue(comp, "m_APIKey", apiKey);
                SetFieldValue(comp, "aPISecret", apiSecret);
                SetFieldValue(comp, "m_APISecret", apiSecret);
                
                // Set scene name
                SetFieldValue(comp, "sceneFullName", sceneName);
                SetFieldValue(comp, "m_SceneFullName", sceneName);
                
                Debug.Log("✅ InworldClient configured with API credentials and scene");
                
                // Try to restart the client
                try
                {
                    var restartMethod = comp.GetType().GetMethod("Reconnect", BindingFlags.Public | BindingFlags.Instance);
                    if (restartMethod != null)
                    {
                        restartMethod.Invoke(comp, null);
                        Debug.Log("✅ Inworld client restarted");
                    }
                    else
                    {
                        // Try other restart methods
                        var initMethod = comp.GetType().GetMethod("Init", BindingFlags.Public | BindingFlags.Instance);
                        if (initMethod != null)
                        {
                            initMethod.Invoke(comp, null);
                            Debug.Log("✅ Inworld client initialized");
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.LogWarning($"Could not restart client: {e.Message}");
                }
            }
            
            // Configure InworldController
            else if (typeName.Contains("InworldController"))
            {
                SetFieldValue(comp, "sceneFullName", sceneName);
                SetFieldValue(comp, "m_SceneFullName", sceneName);
                
                Debug.Log("✅ InworldController scene configured");
            }
        }
        
        // Check microphone
        string[] devices = Microphone.devices;
        if (devices.Length > 0)
        {
            Debug.Log($"✅ Microphone detected: {devices[0]}");
        }
        else
        {
            Debug.LogWarning("⚠️ No microphone found! Voice input won't work.");
        }
        
        Debug.Log("=== RUNTIME CONFIGURATION COMPLETE ===");
        Debug.Log("The AI assistant should now be properly configured!");
        Debug.Log("Try speaking to the lab assistant now!");
    }
    
    void SetFieldValue(Component component, string fieldName, object value)
    {
        System.Type type = component.GetType();
        
        // Try public field
        var field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
        if (field != null)
        {
            field.SetValue(component, value);
            Debug.Log($"Set {fieldName} = {value}");
            return;
        }
        
        // Try private field
        field = type.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
        if (field != null)
        {
            field.SetValue(component, value);
            Debug.Log($"Set private {fieldName} = {value}");
            return;
        }
        
        // Try property
        var property = type.GetProperty(fieldName, BindingFlags.Public | BindingFlags.Instance);
        if (property != null && property.CanWrite)
        {
            property.SetValue(component, value);
            Debug.Log($"Set property {fieldName} = {value}");
            return;
        }
        
        // Try private property
        property = type.GetProperty(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
        if (property != null && property.CanWrite)
        {
            property.SetValue(component, value);
            Debug.Log($"Set private property {fieldName} = {value}");
            return;
        }
    }
}
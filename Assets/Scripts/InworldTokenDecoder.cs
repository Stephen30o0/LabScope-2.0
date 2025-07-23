using UnityEngine;
using System;
using System.Text;
using System.Reflection;

public class InworldTokenDecoder : MonoBehaviour
{
    public static void Execute()
    {
        Debug.Log("=== DECODING INWORLD TOKEN ===");
        
        // Your Bearer token
        string bearerToken = "Bearer V29Qc25RdHpGejNWNmhUdG5ZdVBHNG1wZHBzbDE3MzI6bUtYMWdxUzhtaHN5d3k0YnZhVEZ3R0hQNlUwNFZjeU40UURQeXluQ3UycnlEd2FZSUpNOE1wam5oN1RZRHZsaA==";
        
        // Remove "Bearer " prefix and decode the base64
        string base64Token = bearerToken.Replace("Bearer ", "");
        
        try
        {
            // Decode base64
            byte[] data = Convert.FromBase64String(base64Token);
            string decodedToken = Encoding.UTF8.GetString(data);
            
            Debug.Log($"Decoded token: {decodedToken}");
            
            // Split by colon to get API key and secret
            string[] parts = decodedToken.Split(':');
            if (parts.Length == 2)
            {
                string apiKey = parts[0];
                string apiSecret = parts[1];
                
                Debug.Log($"API Key: {apiKey}");
                Debug.Log($"API Secret: {apiSecret.Substring(0, 10)}..."); // Only show first 10 chars for security
                
                // Now set these in the InworldClient
                GameObject inworldController = GameObject.Find("InworldController");
                if (inworldController != null)
                {
                    Component[] components = inworldController.GetComponents<Component>();
                    
                    foreach (Component comp in components)
                    {
                        if (comp.GetType().Name.Contains("InworldClient"))
                        {
                            // Set API Key
                            SetFieldValue(comp, "aPIKey", apiKey);
                            SetFieldValue(comp, "m_APIKey", apiKey);
                            SetFieldValue(comp, "apiKey", apiKey);
                            
                            // Set API Secret
                            SetFieldValue(comp, "aPISecret", apiSecret);
                            SetFieldValue(comp, "m_APISecret", apiSecret);
                            SetFieldValue(comp, "apiSecret", apiSecret);
                            
                            Debug.Log("✅ API credentials configured!");
                            break;
                        }
                    }
                }
            }
            else
            {
                Debug.LogError("Invalid token format. Expected format: apikey:apisecret");
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to decode token: {e.Message}");
        }
        
        Debug.Log("=== TOKEN DECODING COMPLETE ===");
    }
    
    static void SetFieldValue(Component component, string fieldName, object value)
    {
        System.Type type = component.GetType();
        
        // Try public field
        var field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
        if (field != null)
        {
            field.SetValue(component, value);
            Debug.Log($"✅ Set {fieldName}");
            return;
        }
        
        // Try private field
        field = type.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
        if (field != null)
        {
            field.SetValue(component, value);
            Debug.Log($"✅ Set private {fieldName}");
            return;
        }
        
        // Try property
        var property = type.GetProperty(fieldName, BindingFlags.Public | BindingFlags.Instance);
        if (property != null && property.CanWrite)
        {
            property.SetValue(component, value);
            Debug.Log($"✅ Set property {fieldName}");
            return;
        }
    }
}
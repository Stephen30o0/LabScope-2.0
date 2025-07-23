using UnityEngine;

public class AtomSetup : MonoBehaviour
{
    public static void Execute()
    {
        Debug.Log("Setting up atoms...");

        // Set up Hydrogen atom
        SetupAtom("GameObject 1 Variant/Hydrogen", "GameObject 1 Variant/Hydrogen/Sphere");
        
        // Set up Helium atom
        SetupAtom("GameObject 1 Variant/Helium", "GameObject 1 Variant/Helium/Proton");
        
        // Set up Lithium atom
        SetupAtom("GameObject 1 Variant/Lithium", "GameObject 1 Variant/Lithium/Proton");
        
        // Set up Beryllium atom
        SetupAtom("GameObject 1 Variant/Beryllium", "GameObject 1 Variant/Beryllium/Proton");

        Debug.Log("Atom setup completed!");
    }

    private static void SetupAtom(string atomPath, string centerObjectPath)
    {
        GameObject atom = GameObject.Find(atomPath);
        GameObject centerObject = GameObject.Find(centerObjectPath);
        
        if (atom != null && centerObject != null)
        {
            // Ensure the atom is initially inactive
            atom.SetActive(false);
            
            // Set up Ring_Rotation components for electrons
            Ring_Rotation[] rotationComponents = atom.GetComponentsInChildren<Ring_Rotation>();
            
            foreach (Ring_Rotation rotation in rotationComponents)
            {
                // Use reflection to set the atom reference
                var field = typeof(Ring_Rotation).GetField("atom", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                if (field != null)
                {
                    field.SetValue(rotation, centerObject);
                }
            }
            
            // Make sure the atom's rigidbody is set up correctly
            Rigidbody rb = atom.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.useGravity = false;
                rb.isKinematic = true; // Make it kinematic to prevent physics issues
            }
        }
    }
}
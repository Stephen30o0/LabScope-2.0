using UnityEngine;

public class PeriodicTableSetup : MonoBehaviour
{
    public static void Execute()
    {
        // Find the Controller and set up the atoms array
        GameObject controller = GameObject.Find("Controller");
        if (controller != null)
        {
            Atoms atomsScript = controller.GetComponent<Atoms>();
            if (atomsScript != null)
            {
                // Find the atom GameObjects
                GameObject[] atoms = new GameObject[4];
                atoms[0] = GameObject.Find("GameObject 1 Variant/Hydrogen");
                atoms[1] = GameObject.Find("GameObject 1 Variant/Helium");
                atoms[2] = GameObject.Find("GameObject 1 Variant/Lithium");
                atoms[3] = GameObject.Find("GameObject 1 Variant/Beryllium");
                
                // Set the atoms array using reflection
                var field = typeof(Atoms).GetField("atoms", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                if (field != null)
                {
                    field.SetValue(atomsScript, atoms);
                }
                
                // Deactivate all atoms initially
                for (int i = 0; i < atoms.Length; i++)
                {
                    if (atoms[i] != null)
                    {
                        atoms[i].SetActive(false);
                    }
                }
            }
        }
        
        // Remove duplicate ElementSelected components from periodic table elements
        for (int i = 1; i <= 118; i++)
        {
            GameObject element = GameObject.Find("GameObject 1 Variant/PeriodicTable/" + i);
            if (element != null)
            {
                ElementSelected elementSelected = element.GetComponent<ElementSelected>();
                if (elementSelected != null)
                {
                    UnityEngine.Object.DestroyImmediate(elementSelected);
                }
            }
        }
        
        Debug.Log("Periodic table setup completed!");
    }
}
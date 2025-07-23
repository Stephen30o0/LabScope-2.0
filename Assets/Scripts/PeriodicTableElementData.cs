using UnityEngine;

public class PeriodicTableElementData : MonoBehaviour
{
    [System.Serializable]
    public class ElementData
    {
        public int atomicNumber;
        public string symbol;
        public string name;
        public float atomicWeight;
    }

    private static ElementData[] elements = new ElementData[]
    {
        new ElementData { atomicNumber = 1, symbol = "H", name = "Hydrogen", atomicWeight = 1.008f },
        new ElementData { atomicNumber = 2, symbol = "He", name = "Helium", atomicWeight = 4.003f },
        new ElementData { atomicNumber = 3, symbol = "Li", name = "Lithium", atomicWeight = 6.94f },
        new ElementData { atomicNumber = 4, symbol = "Be", name = "Beryllium", atomicWeight = 9.012f },
        new ElementData { atomicNumber = 5, symbol = "B", name = "Boron", atomicWeight = 10.81f },
        new ElementData { atomicNumber = 6, symbol = "C", name = "Carbon", atomicWeight = 12.01f },
        new ElementData { atomicNumber = 7, symbol = "N", name = "Nitrogen", atomicWeight = 14.01f },
        new ElementData { atomicNumber = 8, symbol = "O", name = "Oxygen", atomicWeight = 16.00f },
        new ElementData { atomicNumber = 9, symbol = "F", name = "Fluorine", atomicWeight = 19.00f },
        new ElementData { atomicNumber = 10, symbol = "Ne", name = "Neon", atomicWeight = 20.18f },
        new ElementData { atomicNumber = 11, symbol = "Na", name = "Sodium", atomicWeight = 22.99f },
        new ElementData { atomicNumber = 12, symbol = "Mg", name = "Magnesium", atomicWeight = 24.31f },
        new ElementData { atomicNumber = 13, symbol = "Al", name = "Aluminum", atomicWeight = 26.98f },
        new ElementData { atomicNumber = 14, symbol = "Si", name = "Silicon", atomicWeight = 28.09f },
        new ElementData { atomicNumber = 15, symbol = "P", name = "Phosphorus", atomicWeight = 30.97f },
        new ElementData { atomicNumber = 16, symbol = "S", name = "Sulfur", atomicWeight = 32.07f },
        new ElementData { atomicNumber = 17, symbol = "Cl", name = "Chlorine", atomicWeight = 35.45f },
        new ElementData { atomicNumber = 18, symbol = "Ar", name = "Argon", atomicWeight = 39.95f },
        new ElementData { atomicNumber = 19, symbol = "K", name = "Potassium", atomicWeight = 39.10f },
        new ElementData { atomicNumber = 20, symbol = "Ca", name = "Calcium", atomicWeight = 40.08f },
        new ElementData { atomicNumber = 21, symbol = "Sc", name = "Scandium", atomicWeight = 44.96f },
        new ElementData { atomicNumber = 22, symbol = "Ti", name = "Titanium", atomicWeight = 47.87f },
        new ElementData { atomicNumber = 23, symbol = "V", name = "Vanadium", atomicWeight = 50.94f },
        new ElementData { atomicNumber = 24, symbol = "Cr", name = "Chromium", atomicWeight = 51.996f },
        new ElementData { atomicNumber = 25, symbol = "Mn", name = "Manganese", atomicWeight = 54.94f },
        new ElementData { atomicNumber = 26, symbol = "Fe", name = "Iron", atomicWeight = 55.85f },
        new ElementData { atomicNumber = 27, symbol = "Co", name = "Cobalt", atomicWeight = 58.93f },
        new ElementData { atomicNumber = 28, symbol = "Ni", name = "Nickel", atomicWeight = 58.69f },
        new ElementData { atomicNumber = 29, symbol = "Cu", name = "Copper", atomicWeight = 63.55f },
        new ElementData { atomicNumber = 30, symbol = "Zn", name = "Zinc", atomicWeight = 65.38f },
        new ElementData { atomicNumber = 31, symbol = "Ga", name = "Gallium", atomicWeight = 69.72f },
        new ElementData { atomicNumber = 32, symbol = "Ge", name = "Germanium", atomicWeight = 72.63f },
        new ElementData { atomicNumber = 33, symbol = "As", name = "Arsenic", atomicWeight = 74.92f },
        new ElementData { atomicNumber = 34, symbol = "Se", name = "Selenium", atomicWeight = 78.97f },
        new ElementData { atomicNumber = 35, symbol = "Br", name = "Bromine", atomicWeight = 79.90f },
        new ElementData { atomicNumber = 36, symbol = "Kr", name = "Krypton", atomicWeight = 83.80f },
        new ElementData { atomicNumber = 37, symbol = "Rb", name = "Rubidium", atomicWeight = 85.47f },
        new ElementData { atomicNumber = 38, symbol = "Sr", name = "Strontium", atomicWeight = 87.62f },
        new ElementData { atomicNumber = 39, symbol = "Y", name = "Yttrium", atomicWeight = 88.91f },
        new ElementData { atomicNumber = 40, symbol = "Zr", name = "Zirconium", atomicWeight = 91.22f },
        new ElementData { atomicNumber = 41, symbol = "Nb", name = "Niobium", atomicWeight = 92.91f },
        new ElementData { atomicNumber = 42, symbol = "Mo", name = "Molybdenum", atomicWeight = 95.95f },
        new ElementData { atomicNumber = 43, symbol = "Tc", name = "Technetium", atomicWeight = 98.0f },
        new ElementData { atomicNumber = 44, symbol = "Ru", name = "Ruthenium", atomicWeight = 101.07f },
        new ElementData { atomicNumber = 45, symbol = "Rh", name = "Rhodium", atomicWeight = 102.91f },
        new ElementData { atomicNumber = 46, symbol = "Pd", name = "Palladium", atomicWeight = 106.42f },
        new ElementData { atomicNumber = 47, symbol = "Ag", name = "Silver", atomicWeight = 107.87f },
        new ElementData { atomicNumber = 48, symbol = "Cd", name = "Cadmium", atomicWeight = 112.41f },
        new ElementData { atomicNumber = 49, symbol = "In", name = "Indium", atomicWeight = 114.82f },
        new ElementData { atomicNumber = 50, symbol = "Sn", name = "Tin", atomicWeight = 118.71f },
        new ElementData { atomicNumber = 51, symbol = "Sb", name = "Antimony", atomicWeight = 121.76f },
        new ElementData { atomicNumber = 52, symbol = "Te", name = "Tellurium", atomicWeight = 127.60f },
        new ElementData { atomicNumber = 53, symbol = "I", name = "Iodine", atomicWeight = 126.90f },
        new ElementData { atomicNumber = 54, symbol = "Xe", name = "Xenon", atomicWeight = 131.29f },
        new ElementData { atomicNumber = 55, symbol = "Cs", name = "Cesium", atomicWeight = 132.91f },
        new ElementData { atomicNumber = 56, symbol = "Ba", name = "Barium", atomicWeight = 137.33f },
        new ElementData { atomicNumber = 57, symbol = "La", name = "Lanthanum", atomicWeight = 138.91f },
        new ElementData { atomicNumber = 58, symbol = "Ce", name = "Cerium", atomicWeight = 140.12f },
        new ElementData { atomicNumber = 59, symbol = "Pr", name = "Praseodymium", atomicWeight = 140.91f },
        new ElementData { atomicNumber = 60, symbol = "Nd", name = "Neodymium", atomicWeight = 144.24f },
        new ElementData { atomicNumber = 61, symbol = "Pm", name = "Promethium", atomicWeight = 145.0f },
        new ElementData { atomicNumber = 62, symbol = "Sm", name = "Samarium", atomicWeight = 150.36f },
        new ElementData { atomicNumber = 63, symbol = "Eu", name = "Europium", atomicWeight = 151.96f },
        new ElementData { atomicNumber = 64, symbol = "Gd", name = "Gadolinium", atomicWeight = 157.25f },
        new ElementData { atomicNumber = 65, symbol = "Tb", name = "Terbium", atomicWeight = 158.93f },
        new ElementData { atomicNumber = 66, symbol = "Dy", name = "Dysprosium", atomicWeight = 162.50f },
        new ElementData { atomicNumber = 67, symbol = "Ho", name = "Holmium", atomicWeight = 164.93f },
        new ElementData { atomicNumber = 68, symbol = "Er", name = "Erbium", atomicWeight = 167.26f },
        new ElementData { atomicNumber = 69, symbol = "Tm", name = "Thulium", atomicWeight = 168.93f },
        new ElementData { atomicNumber = 70, symbol = "Yb", name = "Ytterbium", atomicWeight = 173.05f },
        new ElementData { atomicNumber = 71, symbol = "Lu", name = "Lutetium", atomicWeight = 174.97f },
        new ElementData { atomicNumber = 72, symbol = "Hf", name = "Hafnium", atomicWeight = 178.49f },
        new ElementData { atomicNumber = 73, symbol = "Ta", name = "Tantalum", atomicWeight = 180.95f },
        new ElementData { atomicNumber = 74, symbol = "W", name = "Tungsten", atomicWeight = 183.84f },
        new ElementData { atomicNumber = 75, symbol = "Re", name = "Rhenium", atomicWeight = 186.21f },
        new ElementData { atomicNumber = 76, symbol = "Os", name = "Osmium", atomicWeight = 190.23f },
        new ElementData { atomicNumber = 77, symbol = "Ir", name = "Iridium", atomicWeight = 192.22f },
        new ElementData { atomicNumber = 78, symbol = "Pt", name = "Platinum", atomicWeight = 195.08f },
        new ElementData { atomicNumber = 79, symbol = "Au", name = "Gold", atomicWeight = 196.97f },
        new ElementData { atomicNumber = 80, symbol = "Hg", name = "Mercury", atomicWeight = 200.59f },
        new ElementData { atomicNumber = 81, symbol = "Tl", name = "Thallium", atomicWeight = 204.38f },
        new ElementData { atomicNumber = 82, symbol = "Pb", name = "Lead", atomicWeight = 207.2f },
        new ElementData { atomicNumber = 83, symbol = "Bi", name = "Bismuth", atomicWeight = 208.98f },
        new ElementData { atomicNumber = 84, symbol = "Po", name = "Polonium", atomicWeight = 209.0f },
        new ElementData { atomicNumber = 85, symbol = "At", name = "Astatine", atomicWeight = 210.0f },
        new ElementData { atomicNumber = 86, symbol = "Rn", name = "Radon", atomicWeight = 222.0f },
        new ElementData { atomicNumber = 87, symbol = "Fr", name = "Francium", atomicWeight = 223.0f },
        new ElementData { atomicNumber = 88, symbol = "Ra", name = "Radium", atomicWeight = 226.0f },
        new ElementData { atomicNumber = 89, symbol = "Ac", name = "Actinium", atomicWeight = 227.0f },
        new ElementData { atomicNumber = 90, symbol = "Th", name = "Thorium", atomicWeight = 232.04f },
        new ElementData { atomicNumber = 91, symbol = "Pa", name = "Protactinium", atomicWeight = 231.04f },
        new ElementData { atomicNumber = 92, symbol = "U", name = "Uranium", atomicWeight = 238.03f },
        new ElementData { atomicNumber = 93, symbol = "Np", name = "Neptunium", atomicWeight = 237.0f },
        new ElementData { atomicNumber = 94, symbol = "Pu", name = "Plutonium", atomicWeight = 244.0f },
        new ElementData { atomicNumber = 95, symbol = "Am", name = "Americium", atomicWeight = 243.0f },
        new ElementData { atomicNumber = 96, symbol = "Cm", name = "Curium", atomicWeight = 247.0f },
        new ElementData { atomicNumber = 97, symbol = "Bk", name = "Berkelium", atomicWeight = 247.0f },
        new ElementData { atomicNumber = 98, symbol = "Cf", name = "Californium", atomicWeight = 251.0f },
        new ElementData { atomicNumber = 99, symbol = "Es", name = "Einsteinium", atomicWeight = 252.0f },
        new ElementData { atomicNumber = 100, symbol = "Fm", name = "Fermium", atomicWeight = 257.0f },
        new ElementData { atomicNumber = 101, symbol = "Md", name = "Mendelevium", atomicWeight = 258.0f },
        new ElementData { atomicNumber = 102, symbol = "No", name = "Nobelium", atomicWeight = 259.0f },
        new ElementData { atomicNumber = 103, symbol = "Lr", name = "Lawrencium", atomicWeight = 262.0f },
        new ElementData { atomicNumber = 104, symbol = "Rf", name = "Rutherfordium", atomicWeight = 267.0f },
        new ElementData { atomicNumber = 105, symbol = "Db", name = "Dubnium", atomicWeight = 268.0f },
        new ElementData { atomicNumber = 106, symbol = "Sg", name = "Seaborgium", atomicWeight = 271.0f },
        new ElementData { atomicNumber = 107, symbol = "Bh", name = "Bohrium", atomicWeight = 272.0f },
        new ElementData { atomicNumber = 108, symbol = "Hs", name = "Hassium", atomicWeight = 277.0f },
        new ElementData { atomicNumber = 109, symbol = "Mt", name = "Meitnerium", atomicWeight = 276.0f },
        new ElementData { atomicNumber = 110, symbol = "Ds", name = "Darmstadtium", atomicWeight = 281.0f },
        new ElementData { atomicNumber = 111, symbol = "Rg", name = "Roentgenium", atomicWeight = 282.0f },
        new ElementData { atomicNumber = 112, symbol = "Cn", name = "Copernicium", atomicWeight = 285.0f },
        new ElementData { atomicNumber = 113, symbol = "Nh", name = "Nihonium", atomicWeight = 286.0f },
        new ElementData { atomicNumber = 114, symbol = "Fl", name = "Flerovium", atomicWeight = 289.0f },
        new ElementData { atomicNumber = 115, symbol = "Mc", name = "Moscovium", atomicWeight = 290.0f },
        new ElementData { atomicNumber = 116, symbol = "Lv", name = "Livermorium", atomicWeight = 293.0f },
        new ElementData { atomicNumber = 117, symbol = "Ts", name = "Tennessine", atomicWeight = 294.0f },
        new ElementData { atomicNumber = 118, symbol = "Og", name = "Oganesson", atomicWeight = 294.0f }
    };

    public static void Execute()
    {
        Debug.Log("Setting up periodic table element data...");

        for (int i = 1; i <= 118; i++)
        {
            GameObject element = GameObject.Find("GameObject 1 Variant/PeriodicTable/" + i);
            if (element != null)
            {
                // Get element data (use index i-1 since array is 0-based)
                ElementData data = null;
                if (i <= elements.Length)
                {
                    data = elements[i - 1];
                }
                else
                {
                    // For elements beyond our data, use placeholder data
                    data = new ElementData 
                    { 
                        atomicNumber = i, 
                        symbol = "E" + i, 
                        name = "Element" + i, 
                        atomicWeight = i * 2.0f 
                    };
                }

                // Set atomic number
                Transform atomicNumberChild = element.transform.Find("AtomicNumber");
                if (atomicNumberChild != null)
                {
                    TextMesh atomicNumberText = atomicNumberChild.GetComponent<TextMesh>();
                    if (atomicNumberText != null)
                    {
                        atomicNumberText.text = data.atomicNumber.ToString();
                    }
                }

                // Set element symbol
                Transform symbolChild = element.transform.Find("ElementSymbol");
                if (symbolChild != null)
                {
                    TextMesh symbolText = symbolChild.GetComponent<TextMesh>();
                    if (symbolText != null)
                    {
                        symbolText.text = data.symbol;
                    }
                }

                // Set element name
                Transform nameChild = element.transform.Find("ElementName");
                if (nameChild != null)
                {
                    TextMesh nameText = nameChild.GetComponent<TextMesh>();
                    if (nameText != null)
                    {
                        nameText.text = data.name;
                    }
                }

                // Set atomic weight
                Transform weightChild = element.transform.Find("AtomicWeight");
                if (weightChild != null)
                {
                    TextMesh weightText = weightChild.GetComponent<TextMesh>();
                    if (weightText != null)
                    {
                        weightText.text = data.atomicWeight.ToString("F2");
                    }
                }
            }
        }

        Debug.Log("Periodic table element data setup completed!");
    }
}
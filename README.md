# LabScope - Virtual Reality Chemistry Lab Simulator

## Description
LabScope is an immersive VR chemistry lab simulator developed in Unity for the Oculus Quest 2, designed as a learning tool for chemistry students and enthusiasts. The simulator provides an interactive and safe environment for users to:

*   Interact with lab equipment and substances using VR hand controllers.
*   Perform various chemistry experiments, including reactions and observations.
*   Learn about the periodic table, including element properties and atomic structures.
*   Engage with an AI assistant for guidance and information during experiments.
*   Explore educational content related to chemical concepts and safety procedures.

## Designs and Demo
*(Note: Actual Figma files and video demos would be linked here. For this submission, these are placeholders.)*
*   **Figma Video Demo:** [ https://drive.google.com/file/d/1KWX3RKTFNaneDeED3ZJ80eH1YX7Vxt-5/view?usp=sharing ]
*   **Final Version Video Demo:** [ https://drive.google.com/file/d/1nKsRpRODnufVEElNxpFngAOSl5LLh3YB/view?usp=sharing ]

## Installation
### Requirements
*   Unity 2022.3 LTS with Android Build Support
*   Oculus Integration SDK
*   Unity XR Interaction Toolkit
*   Inworld AI Unity SDK
*   Oculus Quest 2

### Project Setup Instructions
1.  **Clone the repository:** `git clone [Your Repository URL]`
2.  **Open the project in Unity:** Navigate to the cloned repository folder and open it with Unity Hub.
3.  **Install Dependencies:**
    *   Open the Unity Package Manager (`Window > Package Manager`).
    *   Ensure "Unity Registry" is selected.
    *   Install `Oculus Integration` (if not already installed).
    *   Install `Unity XR Interaction Toolkit` (version 2.x or later).
    *   Import the Inworld AI Unity SDK package.
4.  **Configure XR settings:** Go to `Project Settings > XR Plugin Management` and enable `Oculus` for Android.
5.  **Scene Setup:** Ensure `LabScene.unity` (or your main scene) is included in the `Build Settings` (`File > Build Settings`).
6.  **Inworld AI Configuration:**
    *   Ensure the `InworldController` GameObject is present in your scene.
    *   The `InworldRuntimeSetup.cs` script (located in `Assets/Scripts/`) will automatically configure the InworldClient with the necessary API key, secret, and scene name at runtime.
    *   Verify that your Inworld workspace (`unitytest`) and scene (`transform`) are correctly set up in the Inworld Studio.

### Build & Deployment
1.  **Build the APK:** Go to `File > Build Settings > Android > Build`, and save the APK file to your desired location.
2.  **Connect the headset via USB:** Connect your Oculus Quest 2 to your computer using a USB-C cable.
3.  **Install the APK:** Use ADB (Android Debug Bridge) to install the APK: `adb install path/to/your/LabScope.apk`
4.  **Launch and begin simulation.**

## Video Demo
Find link to video here( https://drive.google.com/file/d/1nKsRpRODnufVEElNxpFngAOSl5LLh3YB/view?usp=sharing )

## APK FILE
Find link to APK here ( https://drive.google.com/file/d/1_WcSNGArB2552sGQpQPjFIRiLAJ5uA98/view?usp=sharing )

## Testing
### Unit Testing
Core lab interaction, periodic table functionality, and AI assistant integration are tested using Unity’s built-in test framework.

### Device Testing
Manual testing performed on Oculus Quest 2 to ensure:
*   Accurate hand tracking and controller interaction with lab equipment.
*   Proper display and interaction with the periodic table elements.
*   Responsive and accurate AI assistant voice recognition and responses.
*   Overall performance and stability in a VR environment.

### User Feedback
Iterative feedback from test users is used to improve:
*   UI/UX for lab interactions and periodic table navigation.
*   Clarity and helpfulness of the AI assistant's responses.
*   Performance optimization for a smooth VR experience.

### Functionality Demonstration
*   **Periodic Table:** Demonstrated correct display of element data (symbol, name, atomic weight) for all elements up to Oganesson (118), addressing previous issues where only 'H' or 'E' was shown. Interaction with periodic table elements now correctly updates the large element display and data panel.
*   **AI Assistant:** Demonstrated successful configuration of the Inworld AI assistant, enabling it to hear and respond to user queries, addressing previous issues of unresponsiveness.

### Data Values Testing
*   **Periodic Table Data:** Tested with various element selections across the periodic table (Hydrogen, Helium, Lithium, Beryllium, Scandium, Iron, etc.) to ensure correct data retrieval and display for each element.
*   **AI Assistant Interactions:** Tested with a range of voice commands and questions to the AI assistant to verify its understanding and ability to provide relevant information.

### Performance Testing
*   **Hardware:** Tested on Oculus Quest 2.
*   **Software:** Unity 2022.3 LTS, Android OS on Quest 2.
*   **Observations:** The application maintains a stable frame rate on the Oculus Quest 2, providing a comfortable VR experience. Interactions are responsive, and the AI assistant's processing time is minimal, ensuring a fluid conversation flow.

## Analysis
The project has successfully achieved its core objectives of creating an interactive VR chemistry lab simulator with a functional periodic table and an AI assistant. The initial issues with the periodic table displaying incorrect element data and the AI assistant being unresponsive have been resolved through targeted script modifications and runtime configuration. The implementation of a dedicated `PeriodicTableElementData.cs` script ensures accurate element information, and the `InworldRuntimeSetup.cs` script dynamically configures the Inworld AI components, addressing API key and scene setup challenges. The use of reflection in `InworldRuntimeSetup.cs` provides a robust way to set private fields, which was crucial for resolving the AI assistant's connectivity issues.

## Discussion
The milestones achieved, particularly the functional periodic table and the responsive AI assistant, significantly impact the project's educational value. The periodic table now serves as a reliable reference, enhancing the learning experience by providing accurate element information. The AI assistant transforms the simulator into a guided learning environment, allowing users to ask questions and receive real-time assistance, which is vital for self-paced learning and problem-solving in a virtual lab setting. These functionalities contribute directly to the project's goal of providing an immersive and informative chemistry learning platform.

## Recommendations
### Application to the Community
LabScope can be a valuable tool for:
*   **High School and College Chemistry Education:** Providing a safe and interactive environment for students to perform experiments without the need for physical lab equipment or hazardous chemicals.
*   **Remote Learning:** Enabling students to access a virtual lab experience from anywhere, facilitating remote education in chemistry.
*   **Chemistry Enthusiasts:** Offering an engaging platform for individuals to explore chemistry concepts and experiments at their own pace.

### Future Work
*   **Expand Experiment Library:** Add more complex chemical reactions and experiments, including titration, synthesis, and analytical procedures.
*   **Advanced AI Capabilities:** Integrate more sophisticated AI features, such as adaptive learning paths, personalized feedback, and intelligent error detection during experiments.
*   **Multiplayer Functionality:** Allow multiple users to collaborate in the same virtual lab, fostering teamwork and collaborative learning.
*   **Gamification:** Introduce challenges, scoring, and progression systems to enhance engagement and motivation.
*   **Cross-Platform Compatibility:** Optimize for other VR platforms beyond Oculus Quest 2.

## Developed By
Olurinola Olukorede

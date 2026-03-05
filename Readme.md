# AI Automotive Configurator (Unity + Generative AI)

An interactive AI-powered automotive configurator built using Unity and Generative AI.  
The application allows users to explore car customization options in a 3D environment while receiving AI-generated configuration suggestions based on style preferences.

This prototype demonstrates how Generative AI can enhance product exploration experiences in XR and immersive product configurators.

---

## Project Overview

This project simulates a 3D car customization experience where users can:

- Inspect a car model in a virtual showroom
- Rotate the car interactively
- Change colors and wheel styles
- Receive AI-generated customization suggestions based on a theme input

The system integrates Unity (frontend) with a FastAPI backend service that calls the Gemini Generative AI API to generate customization recommendations.

---

## Key Features

### 1. Interactive 3D Car Viewer

Users can interact with the car model in real time.

Features include:

- Mouse drag rotation of the car
- Ability to inspect the model from multiple angles
- Simple virtual showroom environment

This simulates a basic automotive configurator similar to those used on real automotive websites and XR showrooms.

---

### 2. Manual Customization Controls

Users can manually change the car configuration using UI controls.

Available options include:

Car Colors
- Red
- Black
- Blue

Wheel Styles
- Sport
- Luxury
- Classic

The customization is applied instantly to the 3D model so users can visually explore different combinations.

---

### 3. Generative AI Customization Suggestions

The main feature of this project is the AI-powered suggestion system.

Users can enter a theme describing the desired style of the car, such as:

sporty  
luxury  
minimal  
classic  

The application sends this theme to a backend service that communicates with the Gemini Generative AI API.

The AI generates three car configuration suggestions. For example:

Red + Sport Wheels  
Black + Luxury Wheels  
Blue + Classic Wheels  

Clicking one of these suggestions automatically applies the configuration to the car.

This demonstrates how AI can assist users in quickly exploring product variations without manually trying every option.

---

## Generative AI Integration

The AI system returns structured configuration data rather than free-text suggestions.

Example response from the AI backend:

[
 {"color":"red","wheel":"sport"},
 {"color":"black","wheel":"luxury"},
 {"color":"blue","wheel":"classic"}
]

Unity parses this JSON response and dynamically applies the configuration to the car.

This approach ensures:

- Reliable AI outputs
- Consistent customization logic
- Easy integration between AI and the 3D environment

---

## System Architecture

User Input (Unity UI)  
        │  
        ▼  
Unity Application (C# Scripts)  
        │  
        │ HTTP Request  
        ▼  
FastAPI Backend Service  
        │  
        │ Request to Gemini API  
        ▼  
Gemini Generative AI  
        │  
        ▼  
JSON Configuration Response  
        │  
        ▼  
Unity Applies Car Customization  

---

## Project Structure

ai-automotive-configurator  
│  
├── Assets/                     # Unity assets, scripts, and scene files  
├── Packages/  
├── ProjectSettings/  
│  
├── ai-config-backend/          # Backend service for AI suggestions  
│   ├── main.py  
│   ├── requirements.txt  
│   └── .env.example  
│  
├── AI-Car-Configurator.app     # Compiled Unity application  
│  
└── README.md  

---

## Technologies Used

Frontend
- Unity
- C#
- Unity UI System
- Unity Input System

Backend
- Python
- FastAPI
- Uvicorn

AI
- Google Gemini Generative AI API

---

## How to Run the Project

### 1. Start the Backend Server

Navigate to the backend folder:

cd ai-config-backend

Install dependencies:

pip install -r requirements.txt

Create an environment file named `.env` and add your API key:

GEMINI_API_KEY=your_api_key_here

Run the backend server:

uvicorn main:app --reload

The API will run at:

http://127.0.0.1:8000

---

### 2. Run the Unity Application

Launch the compiled Unity build:

AI-Car-Configurator.app

Alternatively, open the Unity project in the Unity Editor and run the main scene.

---

## How to Use the Application

1. Enter a theme describing the desired car style.
2. Click **Generate AI Suggestions**.
3. The application sends the theme to the AI backend.
4. Three AI-generated configuration options appear.
5. Click any suggestion to apply it to the car.
6. Rotate the car with mouse drag to inspect the design.

---

## Example Workflow

Example interaction:

User enters theme:

sporty

AI generates suggestions:

Red + Sport Wheels  
Black + Luxury Wheels  
Blue + Classic Wheels  

User selects one of the options and the car updates instantly with the selected configuration.

---

## Potential Use Cases

This concept can be applied to:

- Automotive product configurators
- Virtual showrooms
- XR retail experiences
- Interactive product customization tools
- AI-assisted design exploration systems

---

## Future Improvements

Possible enhancements include:

- Multiple car models
- Interior customization
- Advanced materials and textures
- Realistic lighting and reflections
- AR/VR deployment
- Cloud-hosted AI backend
- AI-generated environment themes

---

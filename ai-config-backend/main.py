from fastapi import FastAPI
from pydantic import BaseModel
import google.generativeai as genai
import os
from dotenv import load_dotenv
import json


load_dotenv()

genai.configure(api_key=os.getenv("GEMINI_API_KEY"))

app = FastAPI()

class ThemeRequest(BaseModel):
    theme: str

# @app.post("/suggest")
# def suggest_config(req: ThemeRequest):

#     prompt = f"""
# Suggest 3 car customization configurations for theme: {req.theme}.

# Return ONLY valid JSON.

# Allowed colors: red, blue, black
# Allowed wheels: sport, luxury, classic

# Example format:

# [
#  {{"color":"red","wheel":"sport"}},
#  {{"color":"blue","wheel":"luxury"}},
#  {{"color":"black","wheel":"classic"}}
# ]
# """

#     model = genai.GenerativeModel("gemini-2.5-flash")

#     response = model.generate_content(prompt)

#     text = response.text

#     # Remove markdown formatting
#     text = text.replace("```json", "").replace("```", "").strip()

#     return text


@app.post("/suggest")
def suggest_config(req: ThemeRequest):

    prompt = f"""
Suggest 3 car customization configurations for theme: {req.theme}.

Return ONLY valid JSON.

Allowed colors: red, blue, black
Allowed wheels: sport, luxury, classic

Example format:

[
 {{"color":"red","wheel":"sport"}},
 {{"color":"blue","wheel":"luxury"}},
 {{"color":"black","wheel":"classic"}}
]
"""

    model = genai.GenerativeModel("gemini-2.5-flash")

    response = model.generate_content(prompt)

    text = response.text
    text = text.replace("```json", "").replace("```", "").strip()

    return json.loads(text)
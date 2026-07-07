# Blood Pressure Calculator

An ASP.NET Core web app for calculating and categorizing blood pressure readings, built with a full testing, CI/CD pipeline around it and deployed to azure web apps.

## What it does

Takes systolic/diastolic input and returns the corresponding blood pressure category, based on standard clinical ranges.

## Testing & Quality

This project isn't just the app - it's built around a complete testing 
strategy:

- **Unit tests** (`BPCalculator-UnitTest`) — core calculation logic
- **BDD tests** (`BPCalculator-BDDTest`) — Gherkin-based behavior specs
- **End-to-end tests** (`BPCalculator-E2ETest`) — full user-flow validation
- **Performance tests** (`perf-tests-k6`) — load testing with k6
- **Code quality** — SonarCloud static analysis integrated via `.sonarcloud.properties`

## CI/CD

Automated via GitHub Actions ([workflows](.github/workflows)) — 
[describe what triggers on push/PR: build, test suite execution, 
SonarCloud scan, deployment to GitHub Pages, etc. — check the workflow 
YAML if you don't remember the exact steps]

## Stack

C# / ASP.NET Core · Gherkin (BDD) · k6 · SonarCloud · GitHub Actions

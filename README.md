# Revit BIM Tunnel to FEM Geometry Export Plugin

## Overview
A Revit add-in to extract tunnel geometry from BIM models and export it for FEM analysis via GMSH, targeting FEMIX.

This Revit add-in automates the process of exporting tunnel geometry from a BIM model and converting it into a format suitable for finite element method (FEM) analysis. The plugin leverages the Autodesk Revit API to extract tunnel geometry, processes the data, and generates mesh files ready for analysis in FEMIX using the open-source GMSH meshing tool.

Tunnel projects in particular impose complex geometric and modeling requirements. This plugin enables designers and engineers to quickly move from 3D BIM data to robust FEM analysis with minimal manual data transfer, improving speed, accuracy, and integration.

## Features
- Extracts tunnel alignment and cross-section data from Revit
- Prepares data for meshing with GMSH
- Exports mesh compatible with FEMIX FEM solver

## Requirements
- Autodesk Revit (2019+)
- .NET Framework 4.7.2 or higher
- GMSH ([download here](https://gmsh.info))
- FEMIX (for FEM analysis [https://www.civil.uminho.pt/composites/Software.htm])

## Installation
1. Build the solution in Visual Studio.
2. Copy the compiled DLL into the Revit Addins folder.
3. Launch Revit; access the plugin from the Add-ins tab.

## Usage
1. Open your tunnel BIM model in Revit.
2. Select the tunnel object.
3. Run the add-in via Add-ins tab.
4. Follow the prompts to export geometry for FEM analysis.

## Workflow

- User interaction: Select tunnel in Revit and run the add-in.
- Geometry extraction: Retrieves tunnel axis, cross-sections, and geotechnical metadata.
- Data processing: Formats data for meshing; defines boundaries and attributes.
- Mesh generation: Calls GMSH to generate mesh (can be automated).
- Export: Mesh is saved in the FEMIX-compatible format for analysis.

## License
This project is licensed under the MIT License.

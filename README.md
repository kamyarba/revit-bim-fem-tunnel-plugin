# Revit BIM Tunnel to FEM Geometry Export Plugin

## Overview
A Revit add-in to extract tunnel geometry from BIM models and export it for FEM analysis via GMSH, targeting FEMIX.

## Features
- Extracts tunnel alignment and cross-section data from Revit
- Prepares data for meshing with GMSH
- Exports mesh compatible with FEMIX FEM solver

## Requirements
- Autodesk Revit (2019+)
- .NET Framework 4.7.2 or higher
- GMSH ([download here](https://gmsh.info))
- FEMIX (for FEM analysis)

## Installation
1. Build the solution in Visual Studio.
2. Copy the compiled DLL into the Revit Addins folder.
3. Launch Revit; access the plugin from the Add-ins tab.

## Usage
1. Open your tunnel BIM model in Revit.
2. Select the tunnel object.
3. Run the add-in via Add-ins tab.
4. Follow the prompts to export geometry for FEM analysis.

## License
MIT License (see LICENSE file)
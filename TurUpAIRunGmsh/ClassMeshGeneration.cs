using GmshNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TurUpAIRunGmsh
{
    public class ClassMeshGeneration
    {
        public string run_GMSH_exe(string Geo_filepath)
        {
            //, double clmin, double clmax
            //gmsh.exe simple.geo -1 -2 -3 -o k.msh -format msh
            //-clmin 0.1 -clmax 0.5

            string filename = Path.GetDirectoryName(Geo_filepath) + @"\" + Path.GetFileNameWithoutExtension(Geo_filepath);

            //filepathtorun = filepathtorun.Remove(filepathtorun.Length - 3);
            //filepathtorun = "-version";

            //string filepathtorun = $"\"{filename}.geo\" -clmin {clmin} -clmax {clmax} -1 -2 -3 -o \"{filename}.msh\" -format msh ";
            string filepathtorun = $"\"{filename}.geo\" -1 -2 -3 -o \"output_mesh.msh\" -format msh ";

            string output = "";
            //Process.Start(@"FemixExe\Prefemix.exe", filepathtorun);

            //int ProcID;
            System.Diagnostics.Process myProcess = new Process();

            //myProcess.StartInfo.FileName = @"cmd.exe";
             //= AppDomain.CurrentDomain.BaseDirectory;
            string baseDirectory=Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            myProcess.StartInfo.FileName = baseDirectory+"\\gmsh.exe";
            myProcess.StartInfo.Arguments = filepathtorun;
            myProcess.StartInfo.UseShellExecute = false;
            myProcess.StartInfo.RedirectStandardOutput = true;

            //myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            myProcess.Start();


            ////ProcID = myProcess.Id;
            //Thread.Sleep(500);

            //////AppActivate();
            //SendKeys.SendWait("{ENTER}");
            //SendKeys.SendWait(@"GMSH\gmsh.exe " + filepathtorun);
            //SendKeys.SendWait("{ENTER}");
            ////SendKeys.SendWait("exit");

            output += myProcess.StandardOutput.ReadToEnd();
            myProcess.WaitForExit();
            output += "\n" + myProcess.ExitTime;

            return output;
            ////Console.WriteLine(myProcess.ExitTime)

        }

        public void generateMesh(string geometryFile)
        {
            // Initialize GMSH
            Gmsh.Initialize();

            // Load the .geo file
            try
            {
            Gmsh.Open(geometryFile);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // Set mesh options
            //double min_size = 0.1;
            //double max_size = 1;

            //Gmsh.Model.Mesh.SetSize(Gmsh.Model.GetEntities(0), min_size);
            //Gmsh.Model.Mesh.SetSize(Gmsh.Model.GetEntities(1), max_size);

            // Generate the mesh
            //Gmsh.Model.Mesh.Generate(1);// 1D mesh
            //Gmsh.Model.Mesh.Generate(2);// 2 for 2D mesh
            //Gmsh.Model.Mesh.Generate(3);// 3D mesh

            // Save the mesh
            //Gmsh.Write(meshDir + "\\mesh.msh");
            //Gmsh.Write(meshDir + "\\mesh.vtk");

            // Finalize GMSH
            Gmsh.Finalize();

        }
    }
   
}

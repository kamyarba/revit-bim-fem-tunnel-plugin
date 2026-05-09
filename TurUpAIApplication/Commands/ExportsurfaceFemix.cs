using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using Nice3point.Revit.Toolkit.External;
using System.Reflection;

namespace TurUpAIApplication.Commands
{
    /// <summary>
    ///     External command entry point invoked from the Revit interface
    /// </summary>
    [UsedImplicitly]
    [Transaction(TransactionMode.Manual)]
    public class ExportsurfaceFemix : ExternalCommand
    {
        public override void Execute()
        {
            UIDocument uidoc = UiDocument;
            try
            {
                TurUpAIExportSurfaceToFemix.ClassExportToFemix classExportToFemix =
                    new TurUpAIExportSurfaceToFemix.ClassExportToFemix(uidoc);

                classExportToFemix.exportSelectedFaces();

            }
            catch (Exception ex)
            {
                TaskDialog.Show("Error", $"Error: {ex.Message}");
            }
        }
    }
}
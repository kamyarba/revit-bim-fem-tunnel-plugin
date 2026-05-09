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
    public class About : ExternalCommand
    {
        public override void Execute()
        {
            TurUpAIAbout.frmAbout aboutWindow = new TurUpAIAbout.frmAbout();
            aboutWindow.ShowDialog();
        }
    }
}
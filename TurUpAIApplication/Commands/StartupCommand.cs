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
    public class StartupCommand : ExternalCommand
    {
        public override void Execute()
        {
            TaskDialog.Show("Alert", "This is template");
            
            //var viewModel = new module1.ViewModels.module1ViewModel();
            //var view = new module1.Views.module1View(viewModel);
            ////view.ShowDialog();
            //view.Show(UiApplication.MainWindowHandle);

            //moduleexe.class2 class2 = new moduleexe.class2();
            //class2.Execute();
        }
    }
}
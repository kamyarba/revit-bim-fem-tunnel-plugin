using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using Nice3point.Revit.Toolkit.External;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurUpAIApplication.Commands
{
    [UsedImplicitly]
    [Transaction(TransactionMode.Manual)]


    public class Linesegment : ExternalCommand
    {
        public override void Execute()
        {

            //var title = Document.Title;
            //var viewName = ActiveView.Name;
            //var username = Application.Username;
            //var selection = UiDocument.Selection;
            //var doc = UiDocument.Document;
            //var windowHandle = UiApplication.MainWindowHandle;
            UIDocument uidoc = UiDocument;
            //Document document = uidoc.Document;
            //View view = document.ActiveView;
            //string path = document.PathName;

            try
            {
                TurUpAILinesegmentation.ClassSegmentation classSegmentation = 
                    new TurUpAILinesegmentation.ClassSegmentation(uidoc);

                classSegmentation.setEdgeElementNumber();

            }
            catch (Exception ex)
            {
                TaskDialog.Show("Error", $"Error: {ex.Message}");
            }

        }
    }
}

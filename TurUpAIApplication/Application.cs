using Autodesk.Revit.UI;
using Nice3point.Revit.Toolkit.External;
using System.Reflection;
using TurUpAIApplication.Commands;

namespace TurUpAIApplication
{
    /// <summary>
    ///     Application entry point
    /// </summary>
    [UsedImplicitly]
    public class Application : ExternalApplication
    {
        public override void OnStartup()
        {
            CreateRibbon();
        }

        private void CreateRibbon()
        {
            var panel = Application.CreatePanel( "TurUpAI");//"Commands",

            //panel.AddPushButton<StartupCommand>("Execute")
            //    .SetImage("/TurUpAIApplication;component/Resources/Icons/RibbonIcon16.png")
            //    .SetLargeImage("/TurUpAIApplication;component/Resources/Icons/RibbonIcon32.png");

            // Create the main pulldown button
            var pulldownButtonData = new PulldownButtonData("ExportFemixButton", "Export to Femix");
            var pulldownButton = panel.AddItem(pulldownButtonData) as PulldownButton;

            // Set the icons for the pulldown button
            pulldownButton.Image = new System.Windows.Media.Imaging.BitmapImage(new Uri("pack://application:,,,/TurUpAIApplication;component/Resources/Icons/RibbonIcon16.png"));
            pulldownButton.LargeImage = new System.Windows.Media.Imaging.BitmapImage(new Uri("pack://application:,,,/TurUpAIApplication;component/Resources/Icons/RibbonIcon32.png"));
            pulldownButton.ToolTip = "This is tooltip 1";
            // Create and add push buttons to the pulldown button
            var exportSetting = new PushButtonData("exportSetting", "Export Setting",
                Assembly.GetExecutingAssembly().Location, typeof(TurUpAIApplication.Commands.Exportsetting).FullName)
            {
                ToolTip = "Export Setting",
            };
            var LineSegmentation = new PushButtonData("LineSegmentation", "Line Segmentation",
                Assembly.GetExecutingAssembly().Location, typeof(TurUpAIApplication.Commands.Linesegment).FullName);
            var ExportSurfaceToFemix = new PushButtonData("ExportSurfaceToFemix", "Export Surface to Femix",
                Assembly.GetExecutingAssembly().Location, typeof(TurUpAIApplication.Commands.ExportsurfaceFemix).FullName);
            var aboutButton = new PushButtonData("About", "About",
                Assembly.GetExecutingAssembly().Location, typeof(TurUpAIApplication.Commands.About).FullName);

            // Add the push buttons to the pulldown button
            pulldownButton.AddPushButton(exportSetting);
            pulldownButton.AddPushButton(LineSegmentation);
            pulldownButton.AddPushButton(ExportSurfaceToFemix);
            pulldownButton.AddPushButton(aboutButton);

        }
    }
}
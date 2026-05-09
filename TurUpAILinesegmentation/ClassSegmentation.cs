using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TurUpAILinesegmentation
{
    public partial class ClassSegmentation
    {
        private UIDocument uidoc;
        public ClassSegmentation(UIDocument _uidoc)
        {
            uidoc = _uidoc;
        }


        public void setEdgeElementNumber()
        {
            IList<Reference> references = uidoc.Selection.PickObjects(ObjectType.Edge, "Select curves to specify the number of nodes");

            frmSegmentnumber frmsgment = new frmSegmentnumber();
            int nPoints = 0;
            double vProgression = 1;
            if (frmsgment.ShowDialog() == true) // Show the dialog and check if OK was clicked
            {
                nPoints = int.Parse(frmsgment.nPoints);
                vProgression = double.Parse(frmsgment.vProgression);
            }


            foreach (Reference reference in references)
            {
                ElementId elementId = reference.ElementId;
                GeometryObject geometryObject = uidoc.Document.GetElement(reference).GetGeometryObjectFromReference(reference);

                Edge edge = geometryObject as Edge;
                Curve edgeLine = edge.AsCurve();

                string uniqElementEdgeID = $"e{elementId}c{geometryObject.Id}";

                //if (userInput > 1)
                //{
                AssignCustomId(uniqElementEdgeID, nPoints, vProgression);

                //TaskDialog.Show("k", $"{GetCustomId(uniqElementEdgeID).Item1.ToString()}\n " +
                //    $"{GetCustomId(uniqElementEdgeID).Item2.ToString()}" );
                //TaskDialog.Show("all", string.Join("\n", StartupCommand.edgeElementNumber.Select(kvp => $"{kvp.Key}: {kvp.Value}")));
                //foreach (var item in edgeElementNumber)
                //{
                //    Console.WriteLine($"{item.Key}: Int = {item.Value.IntValue}, Double = {item.Value.DoubleValue}");
                //}


                // GetCustomId()
                // Create the text note at the midpoint of the edge
                XYZ midPoint = (edgeLine.GetEndPoint(0) + edgeLine.GetEndPoint(1)) / 2;

                DisplayCustomIdOnEdge(midPoint, $"n:{nPoints},p:{vProgression}", uidoc, uidoc.Document);
                //}

                String length = edge.ApproximateLength.ToMeters().ToString("0.00");

                //TaskDialog.Show("element id", $"element id: {elementId}\n geometry object:{geometryObject.Id}");
                //String fileName = $"e{elementId}f{geometryObject.Id}";

            }


        }

        private bool areCoordinatesEqual(XYZ Point1, XYZ Point2)
        {
            if (Math.Round(Point1.X) == Math.Round(Point2.X) &&
                    Math.Round(Point1.Y) == Math.Round(Point2.Y) &&
                    Math.Round(Point1.Z) == Math.Round(Point2.Z))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public static (int,double) GetCustomId(string uniqElementEdgeID)
        {
            if (segments.edgeElementNumber.ContainsKey(uniqElementEdgeID))
            {
                return segments.edgeElementNumber[uniqElementEdgeID];
            }
            return (0,1);
        }
        public void AssignCustomId(string uniqElementEdgeID, int nPoints, double vProgress)
        {
            if (!segments.edgeElementNumber.ContainsKey(uniqElementEdgeID))
            {
                segments.edgeElementNumber.Add(uniqElementEdgeID, (nPoints, vProgress));
            }
            else
            {
                segments.edgeElementNumber[uniqElementEdgeID] = (nPoints, vProgress);
            }
        }
        public void DisplayCustomIdOnEdge(XYZ midPoint, string customId, UIDocument uidoc, Document doc)
        {

            // Retrieve a valid TextNoteType from the document
            // Get a text note type from the document
            TextNoteType textNoteType = new FilteredElementCollector(doc)
                                           .OfClass(typeof(TextNoteType))
                                           .FirstOrDefault() as TextNoteType;

            if (textNoteType == null)
            {
                throw new Exception("No valid TextNoteType found in the document.");
            }



            // Create TextNoteOptions using the valid TextNoteType
            TextNoteOptions opts = new TextNoteOptions()
            {
                TypeId = textNoteType.Id
            };

            // Now create the text note at the desired position
            double textSizeInFeet = 15 / 304.8; // convert mm to ft

            using (Transaction tx = new Transaction(uidoc.Document, "note"))
            {
                tx.Start();
                //Parameter textSizeParam = textNoteType.get_Parameter(BuiltInParameter.TEXT_SIZE);
                //if (textSizeParam != null && !textSizeParam.IsReadOnly)
                //{
                //    // Set the text size (input is in feet, 1 ft = 304.8 mm)
                //    textSizeParam.Set(textSizeInFeet);
                //}


                TextNote textNote = TextNote.Create(doc, doc.ActiveView.Id, midPoint, customId, opts);
                tx.Commit();
            }


        }




    }
}

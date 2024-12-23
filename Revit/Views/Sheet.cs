using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Revit.Elements;
using Revit.Elements.Views;
using RevitServices.Persistence;

namespace TouchNode.Revit.Views
{
    /// <summary>
    /// Wrapper class for the Sheet
    /// </summary>
    public class Sheet
    {
        private Sheet() { }

        /// <summary>
        /// Get all placed views on a sheet
        /// </summary>
        /// <param name="sheet"></param>
        /// <returns></returns>
        public static List<global::Revit.Elements.Views.View> GetAllPlacedViews(global::Revit.Elements.Views.Sheet sheet)
        {
            Autodesk.Revit.DB.Document doc = DocumentManager.Instance.CurrentDBDocument;
            // Get the internal element
            ViewSheet viewSheet = sheet.InternalElement as ViewSheet;

            var placedViewIds = viewSheet.GetAllPlacedViews();

            // our list to host our views to output
            var placedViews = new List<global::Revit.Elements.Views.View>();

            foreach (ElementId viewId in placedViewIds)
            {
                var internalView = doc.GetElement(viewId);
                var element = viewSheet.Document.GetElement(viewId);
                var view = element.ToDSType(true) as global::Revit.Elements.Views.View;
                placedViews.Add(view);
            }

            return placedViews;
        }


        /// <summary>
        /// Set the input sheet number
        /// </summary>
        /// <param name="sheet">The sheet to modify</param>
        /// <param name="sheetNumber">The new sheet number</param>
        /// <returns></returns>
        public static global::Revit.Elements.Views.Sheet SetSheetNumber(global::Revit.Elements.Views.Sheet sheet, string sheetNumber)
        {
            Autodesk.Revit.DB.Document doc = DocumentManager.Instance.CurrentDBDocument;
            // Get the internal element
            ViewSheet viewSheet = sheet.InternalElement as ViewSheet;
            using (Transaction t = new Transaction(doc, "Set Sheet Number"))
            {
                t.Start();
                try
                {
                    viewSheet.SheetNumber = sheetNumber;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                
                t.Commit();
            }
            return sheet;
        }


    }
}

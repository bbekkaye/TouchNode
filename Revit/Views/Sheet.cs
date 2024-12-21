using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;

namespace TouchNode.Revit.Views.Sheet
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
        public static int GetAllPlacedViews(global::Revit.Elements.Views.Sheet sheet)
        {
            // Get the internal element
            ViewSheet viewSheet = sheet.InternalElement as ViewSheet;

            var placedViews = viewSheet.GetAllPlacedViews();

            return placedViews.Count;
        }
    }
}

using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Utils;

namespace Common
{
    public static class ResourcesGridControl
    {
        public static void GetSetByDefaultGridView(GridView gvMain)
        {
            for (int i = 0; i < gvMain.Columns.Count; i++)
            {
                gvMain.Columns[i].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                gvMain.Columns[i].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                gvMain.Columns[i].OptionsColumn.AllowEdit = false;
                gvMain.Columns[i].OptionsColumn.FixedWidth = true;
            }

            

            gvMain.OptionsBehavior.AlignGroupSummaryInGroupRow = DefaultBoolean.False;
            gvMain.OptionsBehavior.AllowAddRows = DefaultBoolean.False;
            gvMain.OptionsBehavior.AllowDeleteRows = DefaultBoolean.False;
            gvMain.OptionsBehavior.AllowFixedGroups = DefaultBoolean.False;
            
            gvMain.OptionsCustomization.AllowColumnMoving = false;
            gvMain.OptionsCustomization.AllowFilter = false;
            gvMain.OptionsCustomization.AllowGroup = false;
            gvMain.OptionsCustomization.AllowQuickHideColumns = false;
            gvMain.OptionsCustomization.AllowRowSizing = false;
            gvMain.OptionsCustomization.AllowSort = false;

            gvMain.OptionsFilter.AllowColumnMRUFilterList = false;
            gvMain.OptionsFilter.AllowFilterEditor = false;
            gvMain.OptionsFilter.AllowFilterIncrementalSearch = false;
            gvMain.OptionsFilter.AllowMRUFilterList = false;
            gvMain.OptionsFilter.AllowMultiSelectInCheckedFilterPopup = false;

            gvMain.OptionsMenu.ShowConditionalFormattingItem = true;
            gvMain.OptionsMenu.ShowSplitItem = false;

            gvMain.OptionsView.ShowAutoFilterRow = true;
            gvMain.OptionsView.ShowGroupPanel = false;
            gvMain.OptionsView.ShowFooter = false;

            int r = -1;
            gvMain.OptionsSelection.MultiSelect = false;
            gvMain.ClearSelection();
            gvMain.FocusedRowHandle = r;
            gvMain.OptionsSelection.MultiSelect = true;
            gvMain.SelectRow(r);


        }

        public static string GetValueGridView(GridControl gc, string nameCol)
        {
            string value = string.Empty;
            int[] selRows = ((GridView)gc.MainView).GetSelectedRows();
            DataRowView selRow = (DataRowView)(((GridView)gc.MainView).GetRow(selRows[0]));
            value = selRow[nameCol].ToString();
            return value;

        }
    }
}

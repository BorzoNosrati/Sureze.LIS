using Blazorise.DataGrid;
using System;
using System.Collections.Generic;

namespace Sureze.LIS.Blazor.Extensions;

public static class DataGridExtensions
{
    public static void MapFilters(this IEnumerable<DataGridColumnInfo> columns, object obj,
        Action<DataGridColumnInfo>? behav=null)
    {
        var type = obj.GetType();
        foreach (DataGridColumnInfo column in columns)
        {
            type.GetProperty(column.Field)?.SetValue(obj, column.SearchValue);
            behav?.Invoke(column);
        }
    }
}
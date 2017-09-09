namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class DataHelper
    {
        internal static void AddParameterWithValue(this DbCommand command, string parameterName, object parameterValue)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = parameterName;
            parameter.Value = parameterValue;
            command.Parameters.Add(parameter);
        }
    }
}

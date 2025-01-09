using System.Globalization;
using TechTalk.SpecFlow;

namespace PlaywrightSpecFlow.Helpers
{
    [Binding]
    public class TableArgumentTransformation
    {
        private const string Today = "@today";

        private const string Tomorrow = "@tomorrow";

        [StepArgumentTransformation]
        public Table SubstituteTableCellValues(Table table)
        {
            foreach (var row in table.Rows)
            {
                foreach (var substitution in GetTableRowSubstitutions(row))
                {
                    row[substitution.Key] = substitution.Value;
                }
            }

            return table;
        }

        private List<KeyValuePair<string, string>> GetTableRowSubstitutions(
            IEnumerable<KeyValuePair<string, string>> pairs)
        {
            var substitutions = new List<KeyValuePair<string, string>>();

            foreach (var (key, value) in pairs)
            {
                switch (value)
                {
                    case Today:
                        substitutions.Add(new KeyValuePair<string, string>(key,
                            DateTimeOffset.UtcNow.ToString(DateFormats.Date, CultureInfo.InvariantCulture)));
                        break;
                    case Tomorrow:
                        substitutions.Add(new KeyValuePair<string, string>(key,
                            DateTimeOffset.UtcNow.AddDays(1).ToString(DateFormats.Date, CultureInfo.InvariantCulture)));
                        break;
                }
            }

            return substitutions;
        }
    }
}

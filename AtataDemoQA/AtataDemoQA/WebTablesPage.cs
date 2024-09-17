using _ = AtataDemoQA.WebTablesPage;

namespace AtataDemoQA
{
    [Url("webtables")]
    internal class WebTablesPage : Page<_>
    {
        [ControlDefinition("div", ContainingClass = "rt-table")]
        public Table<PeopleTableRow, _> People { get; private set; }

        [ControlDefinition("div", ContainingClass = "rt-tr")]
        public class PeopleTableRow : TableRow<_>
        {
            [FindByXPath("//*[contains(@class,'rt-tr')]//*[@class='rt-td'][1]")]
            public Text<_> FirstName { get; private set; }

            [FindByXPath("//*[contains(@class,'rt-tr')]//*[@class='rt-td'][1]")]
            public Text<_> LastName { get; private set; }
            
            [FindByXPath("//*[contains(@class,'rt-tr')]//*[@class='rt-td'][1]")]
            public Button<_> Delete { get; private set; }

        }
    }
}

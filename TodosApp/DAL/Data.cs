
namespace TodosApp.DAL
{
    // קלאס שמטפל בגישה לנתונים
    public class Data
    {
        // מחרוזת חיבור למסד הנתונים
        string ConnectionString = "server = DANIEL\\SQLEXPRESS; initial catalog = todos; user id = sa; password = 1234;TrustServerCertificate=Yes";

        // משתנה סטטי יחיד של הקלאס
        static Data? _data;

        // קונסטרוקטור פרטי שמבצע אינסטנציה ל-DataLayer
        private Data()
        {
            DataLayer = new DataLayer(ConnectionString);
        }

        // משתנה שמחזיק את שכבת הנתונים
        private DataLayer DataLayer;

        // מאפיין סטטי שמחזיר את שכבת הנתונים
        public static DataLayer Get
        {
            get
            {
                // אם אין אינסטנציה של הקלאס, מייצר אחת חדשה
                if (_data == null) _data = new Data();

                // מחזיר את שכבת הנתונים
                return _data.DataLayer;
            }
        }
    }
}

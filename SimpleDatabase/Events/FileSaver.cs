using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDatabase.Events
{
    public class FileSaver
    {
        public delegate void AfterSave();

        public event AfterSave afterSaveEvent;

        public FileSaver()
        {

        }

        public void SaveToFile()
        {
            if (afterSaveEvent != null)
                afterSaveEvent();
            Console.WriteLine("zapisałem do pliku");
        }
    }
}

using System.Collections.Generic;
using System.IO;

namespace WEB_Scraper
{
    class Data<T>
        where T : class
    {

        public void StorageData(string path, IEnumerable<T> data)
        {
            if (data == null)
                return;

            StreamWriter streamWriter = new StreamWriter(path, true, System.Text.Encoding.UTF8);
            foreach (var item in data)
                streamWriter.WriteLine(item);

            streamWriter.Close();
        }
    }
}

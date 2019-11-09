using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace WEB_Scraper
{
    class ViewModel
    {
        ViewModel()
        {

        }


        
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }
        public string Tag
        {
            get { return _tag; }
            set { _tag = value; }
        }

        private string _url;
        private string _tag;
    }
}

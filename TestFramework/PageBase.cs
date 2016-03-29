using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework
{
    public abstract class PageBase
    {
        private string _host;
        private string _relativeUrl;
        private string _fullUrl;

        protected PageBase(string host, string relativeUrl)
        {
            _host = host;
            _relativeUrl = relativeUrl;
            _fullUrl = _host + _relativeUrl;
        }

        public void GoTo()
        {
            Browser.GoTo(_fullUrl);
        }

        public abstract bool IsAt();
    }
}

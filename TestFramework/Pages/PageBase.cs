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
        protected string FullUrl;

        protected PageBase(string host, string relativeUrl)
        {
            _host = host;
            _relativeUrl = relativeUrl;
            FullUrl = _host + _relativeUrl;
        }

        public void GoTo()
        {
            Browser.GoTo(FullUrl);
        }

        public abstract bool IsAt();
    }
}

using System.Net;
using System.Windows.Forms;

namespace Twitty.Kernel
{
    public class DataReader: IDataReader
    {
        public string Data
        {
            get; set;
        }

        public void ShowDialog()
        {
            throw new System.NotImplementedException();
        }
    }
}
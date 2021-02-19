using System;

namespace SP_Ganeev_11
{
    class MyException:Exception
    {
        private string fExtension;
        public string FileEx { get => fExtension; set => fExtension = value; }


        public MyException()
        {

        }

        public MyException(string aMessage, string file) : base(aMessage)
        {
            FileEx = file;
        }

    }
}

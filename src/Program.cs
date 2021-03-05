using System;

namespace multiple_CTRL_H
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1 - we read the properties
            Properties properties = ReaderWriter.ReadProperties();

            // 2 - we convert the file
            ReaderWriter.Convert(properties);
        }
    }
}

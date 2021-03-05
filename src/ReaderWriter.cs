using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace multiple_CTRL_H
{
    public static class ReaderWriter
    {
        private static string PATH_CONFIG = @"../../../config/config.json";

        private static string PATH_FILE(Properties properties) => @"../../../config/" + properties.fileFullName;

        /**
         * Reads the properties from the config file 
         * <returns>A Properties object</returns>
         */
        public static Properties ReadProperties()
        {
            // We check if the config file exists
            if (!File.Exists(PATH_CONFIG))
            {
                // We display an error message
                CONSOLE.WriteLine(ConsoleColor.Red, "ERROR : the config.json file could not be found !");

                // We end the program
                System.Environment.Exit(0);
            }

            // We read the json
            string json = System.IO.File.ReadAllText(PATH_CONFIG);

            // We deserialize the properties
            Properties properties = Properties.Deserialize(json);

            // We return the properties
            return properties;
        }


        /**
         * Converts the file's text, according to the properties
         */
        public static void Convert(Properties properties)
        {
            // We check if the config file exists
            if (!File.Exists(PATH_FILE(properties)))
            {
                // We display an error message
                CONSOLE.WriteLine(ConsoleColor.Red, "ERROR : the file could not be found !");

                // We end the program
                System.Environment.Exit(0);
            }

            // We initialize the list of strings
            List<string> linesRead = System.IO.File.ReadAllLines(PATH_FILE(properties)).ToList();

            // We initialize the list of strings
            List<string> linesToWrite = new List<string>();

            int cpt = 0;

            // We iterate through the lines
            linesRead.ForEach(line => {
                string s = line;

                // In each line, we make all the changes
                properties.changes.ForEach(change => line = line.Replace(change.from, change.to));

                linesToWrite.Add(line);
            });


            // We write all the lines in the file
            File.WriteAllLines(PATH_FILE(properties), linesToWrite);
        }
    }
}

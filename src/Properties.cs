using Newtonsoft.Json;
using System.Collections.Generic;


namespace multiple_CTRL_H
{
    public class Properties
    {
        // FIELDS
        private string _fileFullName;
        private List<Change> _changes;


        // CONSTRUCTORS

        /// <summary>
        /// Creates a default instance of Properties
        /// </summary>
        public Properties()
        {
            fileFullName = "";
            changes = new List<Change>();
        }


        /// <summary>
        /// Creates a new instance of Properties with according parameters
        /// </summary>
        /// <param name="fileFullName">Full name of the file to edit</param>
        /// <param name="changes">Changes to make</param>
        public Properties(string fileFullName, List<Change> changes)
        {
            this.fileFullName = fileFullName;
            this.changes = changes;
        }


        // SERIALIZATION

        /// <summary>
        /// Return a JSON string representing the instance
        /// </summary>
        /// <returns>A JSON string representing the instance</returns>
        public string Serialize()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }


        /// <summary>
        /// Returns a Properties instance from a JSON string
        /// </summary>
        /// <param name="json">String containing the instance data (from a JSON syntax)</param>
        /// <returns>A Properties instance from a JSON string</returns>
        public static Properties Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<Properties>(json);
        }


        // GETTER - SETTER
        public string fileFullName { get => _fileFullName; set => _fileFullName = value; }
        public List<Change> changes { get => _changes; set => _changes = value; }



        public class Change
        {
            // FIELDS
            private string _from;
            private string _to;

            // CONSTRUCTORS

            /// <summary>
            /// Creates a default instance of Change
            /// </summary>
            public Change()
            {
                from = "";
                to = "";
            }


            /// <summary>
            /// Creates a new instance of Change with according parameters
            /// </summary>
            /// <param name="from">Version to change in the input file</param>
            /// <param name="to">Version changed in the output file</param>
            public Change(string from, string to)
            {
                this.from = from;
                this.to = to;
            }


            // SERIALIZATION

            /// <summary>
            /// Return a JSON string representing the instance
            /// </summary>
            /// <returns>A JSON string representing the instance</returns>
            public string Serialize()
            {
                return JsonConvert.SerializeObject(this, Formatting.Indented);
            }


            /// <summary>
            /// Returns a Change instance from a JSON string
            /// </summary>
            /// <param name="json">String containing the instance data (from a JSON syntax)</param>
            /// <returns>A Properties instance from a JSON string</returns>
            public static Change Deserialize(string json)
            {
                return JsonConvert.DeserializeObject<Change>(json);
            }


            // GETTER - SETTER
            public string from { get => _from; set => _from = value; }
            public string to { get => _to; set => _to = value; }
        }
    }
}
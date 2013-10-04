using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace EditorServices.DataContracts
{
    [DataContract]
    public class Image
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public String Description { get; set; }

        [DataMember]
        public String Author { get; set; }

        [DataMember]
        public Bitmap Bitmap { get; set; }
    }
}
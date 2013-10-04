using System;
using System.Drawing;

namespace EditorDomain
{
/*    [MetadataType()]*/

    public class Image
    {
        public int Id { get; set; }
        /*[Required]
        [MinLength(5, ErrorMessageResourceType = typeof (Resources), ErrorMessageResourceName = "Image_Description_Description_must_be_greater_than_5")]
        [MaxLength(20, ErrorMessageResourceType = typeof (Resources), ErrorMessageResourceName = "Image_Description_Description_must_be_less_than_20")]
*/        public String Description { get; set; }
        public String Author { get; set; }
        public Bitmap Bitmap { get; set; }
/*        public bool IsPrivate { get; set; }*/
    }
}

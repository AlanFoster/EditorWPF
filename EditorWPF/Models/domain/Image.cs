using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using EditorWPF.Properties;

namespace EditorWPF.Models.domain
{
/*    [MetadataType()]*/

    public class Image
    {
        public int Id { get; set; }
        [Required]
        [MinLength(5, ErrorMessageResourceType = typeof (Resources), ErrorMessageResourceName = "Image_Description_Description_must_be_greater_than_5")]
        [MaxLength(20, ErrorMessageResourceType = typeof (Resources), ErrorMessageResourceName = "Image_Description_Description_must_be_less_than_20")]
        public String Description { get; set; }
        public String Author { get; set; }
        public Bitmap Bitmap { get; set; }
/*        public bool IsPrivate { get; set; }*/
    }
}

using System.Collections.Generic;
using System.ServiceModel;
using EditorServices.DataContracts;

namespace EditorServices.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IEditorService
    {
        [OperationContract]
        int AddImage(Image image);

        [OperationContract]
        List<Image> GetImages();

        [OperationContract]
        void RemoveImage(int id);
    }
}
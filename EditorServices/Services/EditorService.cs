using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading;
using EditorServices.DataContracts;

namespace EditorServices.Services
{
    /// <summary>
    /// Singly instantiated service
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class EditorService : IEditorService
    {
        private int _counter; 
        private readonly ConcurrentBag<Image> _images = new ConcurrentBag<Image>(); 

        public void AddImage(Image image)
        {
            image.Id = Interlocked.Increment(ref _counter);
            _images.Add(image);
        }

        public List<Image> GetImages()
        {
            return _images.ToList();
        }

        public void RemoveImage(int id)
        {
            // ReSharper disable once RedundantAssignment
            var image = _images.FirstOrDefault(_ => _.Id == id);
            _images.TryTake(out image);
        }
    }
}

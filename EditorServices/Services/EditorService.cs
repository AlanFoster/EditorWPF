using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Threading;
using Image = EditorServices.DataContracts.Image;

namespace EditorServices.Services
{
    /// <summary>
    ///     Singly instantiated service
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class EditorService : IEditorService
    {
        private readonly ConcurrentBag<Image> _images = new ConcurrentBag<Image>();
        private int _counter;

        public EditorService()
        {
            var randomBitmap = new Func<int, Bitmap>(i =>
            {
                var bitmap = new Bitmap(100, 100);
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    var randomColor = Color.FromKnownColor(((KnownColor[]) Enum.GetValues(typeof (KnownColor)))[i]);
                    using (var brush = new SolidBrush(randomColor))
                    {
                        graphics.FillRectangle(brush, 0, 0, 100, 100);
                    }
                }
                return bitmap;
            });


            foreach (var i in Enumerable.Range(1, 20))
            {
                AddImage(new Image
                {
                    Author = "Alan",
                    Description = string.Format("Image #{0}", i),
                    Bitmap = randomBitmap(i)
                });
            }
        }

        public int AddImage(Image image)
        {
            var id = Interlocked.Increment(ref _counter);
            image.Id = id;
            _images.Add(image);
            return id;
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
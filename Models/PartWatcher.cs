using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JetBrains.Annotations;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Handlers;

namespace Orchard.Patrocinadores.Models
{
    public interface IPartWatcher : IDependency
    {
        void Watch<T>(T part) where T : IContent;
        IEnumerable<T> Get<T>() where T : IContent;
        IContent CurrentPage();
    }

    public class PartWatcher : IPartWatcher
    {
        readonly HashSet<IContent> _parts = new HashSet<IContent>();
        private IContent _page = null;

        public void Watch<T>(T part) where T : IContent
        {
            _parts.Add(part);
        }

        public IEnumerable<T> Get<T>() where T : IContent
        {
            return _parts.Where(p => p.Is<T>()).Select(p => p.As<T>());
        }

        public IContent CurrentPage()
        {
            if (_page == null)
            {
                _page = _parts.FirstOrDefault<IContent>(p => p.ContentItem != null && p.ContentItem.ContentType == "Page");
            }

            return _page;
        }
    }

    [UsedImplicitly]
    public class PartWatcherHandler : ContentHandler
    {
        public PartWatcherHandler(IPartWatcher service)
        {
            OnGetDisplayShape<IContent>((ctx, part) => service.Watch<IContent>(part));
        }
    }
}
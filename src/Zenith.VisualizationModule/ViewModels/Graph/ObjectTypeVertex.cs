using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zenith.VisualizationModule.ViewModel
{
    public class ObjectTypeVertex
    {
        string _title = "";
        object _tag = null;
        ObjectTypeVertex _parent = null;

        public ObjectTypeVertex(string title)
        {
            this._title = title;
        }

        public ObjectTypeVertex(string title, object tag)
        {
            this._title = title;
            this._tag = tag;
        }

        public ObjectTypeVertex(string title, object tag, ObjectTypeVertex parent)
        {
            this._title = title;
            this._tag = tag;
            this._parent = parent;
        }

        public string Title
        {
            get { return _title; }
        }

        public object Tag
        {
            get { return _tag; }
        }

        public ObjectTypeVertex Parent
        {
            get
            {
                return _parent;
            }
        }
    }
}

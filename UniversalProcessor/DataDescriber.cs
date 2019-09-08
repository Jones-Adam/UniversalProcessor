using System;
using System.Collections.Generic;
using System.Text;

namespace UniversalProcessor
{
    public abstract class DataDescriber
    {
        public abstract bool CanProcess(object data);

        public abstract List<SDDDataViewDefinition> GenerateViews(object data);

        public DataDescriber()
        {

        }

        public DataDescriber(DataDescriber parent)
        {
            ParentNode = parent;
            Children = new List<DataDescriber>();
        }

        #region TreeSupport
        public int Depth
        {
            get { return (Parent == null ? 0 : Parent.Depth + 1); }
        }

        public DataDescriber ParentNode { get; private set; }

        public DataDescriber Parent
        {
            get { return ParentNode; }
            set { SetParent(value, true); }
        }

        public void SetParent(DataDescriber node, bool updateChildNodes = true)
        {
            if (node == Parent)
                return;

            // update the backing field
            ParentNode = node;

            // add this node to its new parent's children
            if (ParentNode != null && updateChildNodes)
            {
                ParentNode.Children.Add(this);
            }

        }

        public DataDescriber Root
        {
            get { return (Parent == null) ? this : Parent.Root; }
        }

        public List<DataDescriber> Children { get; } = new List<DataDescriber>();

        public IEnumerable<DataDescriber> ChildNodes
        {
            get
            {
                foreach (DataDescriber node in Children)
                    yield return node;

                yield break;
            }
        }

        public IEnumerable<DataDescriber> Descendants
        {
            get
            {
                foreach (DataDescriber node in ChildNodes)
                {
                    yield return node;

                    foreach (DataDescriber descendant in node.Descendants)
                        yield return descendant;
                }

                yield break;
            }
        }

        public IEnumerable<DataDescriber> Subtree
        {
            get
            {
                yield return this;

                foreach (DataDescriber node in Descendants)
                    yield return node;

                yield break;
            }
        }

        public IEnumerable<DataDescriber> Ancestors
        {
            get
            {
                if (Parent == null)
                    yield break;

                yield return Parent;

                foreach (DataDescriber node in Parent.Ancestors)
                    yield return node;

                yield break;
            }
        }

        #endregion

    }
}

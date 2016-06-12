
namespace LinkedList
{
    public class Element<T>
    {
        private object _Data;
        private Element<T> _Next;
        private Element<T> _Prev;
        public object Value
        {
            get { return _Data; }
            set { _Data = value; }
        }
        public Element(object Data)
        {
            this._Data = Data;
        }
        public Element<T> Next
        {
            get { return this._Next; }
            set { this._Next = value; }
        }
        public Element<T> Prev
        {
            get { return this._Prev; }
            set { this._Prev = value; }
        }
    }
}

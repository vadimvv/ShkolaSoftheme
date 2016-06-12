
namespace LinkedList
{
    public class Element
    {
        private object _Data;
        private Element _Next;
        private Element _Prev;
        public object Value
        {
            get { return _Data; }
            set { _Data = value; }
        }
        public Element(object Data)
        {
            this._Data = Data;
        }
        public Element Next
        {
            get { return this._Next; }
            set { this._Next = value; }
        }
        public Element Prev
        {
            get { return this._Prev; }
            set { this._Prev = value; }
        }
    }
}

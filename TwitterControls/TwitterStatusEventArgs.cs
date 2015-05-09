namespace TwitterControls
{
    public class TwitterStatusEventArgs
    {
        public TwitterStatusEventArgs(long id) { Id=id;
        }
        public long Id { get; private set; }
    }
}
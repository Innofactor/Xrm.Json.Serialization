namespace Akvache.Dynamics.Structure
{
    internal class GetObjectResult<T>
    {
        #region Public Properties

        public string Key
        {
            get;
            set;
        }

        public T Object
        {
            get;
            set;
        }

        #endregion Public Properties
    }
}
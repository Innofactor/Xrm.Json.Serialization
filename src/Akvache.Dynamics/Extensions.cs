namespace AkavacheLite.Dynamics
{
    using System;
    using AkavacheLite.Dynamics.Interfaces;

    public static class Extensions
    {
        #region Public Methods

        public static string GenerateKey(this IBlobCache cache) =>
            Guid.NewGuid().ToString("N");

        #endregion Public Methods
    }
}
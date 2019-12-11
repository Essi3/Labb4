using System;
namespace Labb4.Model
{
    /// <summary>
    /// This model object represents a single country
    /// </summary>
    public class Country
    {
        public string PictureUrl { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public int Population { get; set; }
        public string Description { get; set; }
    }
}

using Microsoft.AspNet.Identity;

namespace WebApplication.Core
{
    public class Role : IRole<int>
    {

        public Role()
        {

        }

        /// <summary>
        /// Constructor that takes names as argument 
        /// </summary>
        /// <param name="name"></param>
        public Role(string name)
            : this()
        {
            Name = name;
        }

        public Role(string name, int id)
        {
            Name = name;
            Id = id;
        }

        /// <summary>
        /// Role ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Role name
        /// </summary>
        public string Name { get; set; }
    }
}

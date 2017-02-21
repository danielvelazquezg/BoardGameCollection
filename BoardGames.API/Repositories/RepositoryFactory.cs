using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoardGames.API.Repositories
{
    internal static class RepositoryFactory
    {
        public static IBoardGameRepository Repository {
            get
            {
                //Enter here the conditions to implement the factory. In this case only Xml will be used.
                return new XmlRepository();
            }
        }
    }
}
using BoardGames.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.API.Repositories
{
    interface IBoardGameRepository
    {
        BoardGame Create();

        List<BoardGame> Retrieve();

        BoardGame Save(BoardGame boardGame);

        BoardGame Save(Guid id, BoardGame boardGame);

        bool Delete(Guid id);
    }
}

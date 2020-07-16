using System;
using System.Collections.Generic;
using fullstack_gregslist.Models;
using fullstack_gregslist.Repositories;

namespace fullstack_gregslist.Services
{
    public class CarFavoritesService
    {
        private readonly CarFavoritesRepository _repo;

        public CarFavoritesService(CarFavoritesRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<ViewModelCarFavorite> Get(string user)
        {
            return _repo.GetByUser(user);
        }

        internal DTOCarFavorite Create(DTOCarFavorite fav)
        {
            if (_repo.hasRelationship(fav))
            {
                throw new Exception("you already have that fav");
            }
            return _repo.Create(fav);
        }
        private DTOCarFavorite GetById(int id)
        {
            var found = _repo.GetById(id);
            if (found == null)
            {
                throw new Exception("Invalid Id");
            }
            return found;
        }

        internal DTOCarFavorite Delete(string user, int id)
        {
            var found = GetById(id);
            if (found.User != user)
            {
                throw new UnauthorizedAccessException("This is not your favorite!");
            }
            if (_repo.Delete(id, user))
            {
                return found;
            }
            throw new Exception("Somethin bad happened");
        }


    }
}